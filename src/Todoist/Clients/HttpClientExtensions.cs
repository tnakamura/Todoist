using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Todoist.Models;

namespace Todoist;

internal static class HttpClientExtensions
{
    public static async ValueTask<HttpResponseMessage> GetAsync(
        this HttpMessageInvoker client,
        string requestUri,
        IDictionary<string, string?>? queryParameters,
        CancellationToken cancellationToken = default)
    {
        var request = NewRequest(
            method: HttpMethod.Get,
            requestUri: BuildUri(requestUri, queryParameters));
        return await client.SendAsync(request, cancellationToken)
            .ConfigureAwait(false);
    }

    public static async ValueTask<HttpResponseMessage> GetAsync(
        this HttpMessageInvoker client,
        string requestUri,
        CancellationToken cancellationToken = default)
    {
        var request = NewRequest(
            method: HttpMethod.Get,
            requestUri: requestUri);
        return await client.SendAsync(request, cancellationToken)
            .ConfigureAwait(false);
    }

    public static async ValueTask<T> DeserializeAsync<T>(
        this HttpResponseMessage response,
        CancellationToken cancellationToken = default)
    {
        if (!response.IsSuccessStatusCode)
        {
            var responseBody = await response.Content.ReadAsStringAsync()
                .ConfigureAwait(false);
            throw new TodoistException(responseBody, response.StatusCode);
        }

#if DEBUG
        var debugBody = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
        Debug.WriteLine(debugBody);
#endif

        var responseStream = await response.Content.ReadAsStreamAsync()
            .ConfigureAwait(false);
        var result = await JsonSerializer.DeserializeAsync<T>(responseStream, cancellationToken: cancellationToken)
            .ConfigureAwait(false);
        return result!;
    }

    public static async ValueTask<PagedResult<T>> DeserializePageAsync<T>(
        this HttpResponseMessage response,
        CancellationToken cancellationToken = default)
    {
        var items = await response.DeserializeAsync<IReadOnlyList<T>>(cancellationToken)
            .ConfigureAwait(false);
        return new PagedResult<T>(items, response.GetNextCursorFromLinkHeader());
    }

    public static async ValueTask<HttpResponseMessage> PostAsync<TArgs>(
        this HttpMessageInvoker client,
        string requestUri,
        TArgs payload,
        string? requestId = null,
        CancellationToken cancellationToken = default)
    {
        var request = NewRequest(
            method: HttpMethod.Post,
            requestUri: requestUri,
            requestId: requestId);
        if (payload != null)
        {
            if (payload is FormUrlEncodedContent formContent)
            {
                request.Content = formContent;
            }
            else
            {
#if DEBUG
                var requestBody = JsonSerializer.Serialize(payload);
                Debug.WriteLine(requestBody);
#endif

                var requestBytes = JsonSerializer.SerializeToUtf8Bytes(payload);
                var requestContent = new ByteArrayContent(requestBytes);
                requestContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                request.Content = requestContent;
            }
        }

        return await client.SendAsync(request, cancellationToken)
            .ConfigureAwait(false);
    }

    public static async ValueTask<HttpResponseMessage> DeleteAsync(
        this HttpMessageInvoker client,
        string requestUri,
        string? requestId = null,
        CancellationToken cancellationToken = default)
    {
        var request = NewRequest(
            method: HttpMethod.Delete,
            requestUri: requestUri,
            requestId: requestId);
        return await client.SendAsync(request, cancellationToken)
            .ConfigureAwait(false);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static HttpRequestMessage NewRequest(
        HttpMethod method,
        string requestUri,
        string? requestId = null)
    {
        var request = new HttpRequestMessage(method, requestUri);

        if (!string.IsNullOrEmpty(requestId))
        {
            request.Headers.Add("X-Request-Id", requestId);
        }

        return request;
    }

    private static string BuildUri(string baseUri, IDictionary<string, string?>? queryParameters)
    {
        if (queryParameters is null || queryParameters.Count == 0)
        {
            return baseUri;
        }

        var query = string.Join(
            "&",
            queryParameters
                .Where(x => !string.IsNullOrEmpty(x.Value))
                .Select(x => $"{System.Uri.EscapeDataString(x.Key)}={System.Uri.EscapeDataString(x.Value!)}"));

        return string.IsNullOrEmpty(query) ? baseUri : $"{baseUri}?{query}";
    }

    private static string? GetNextCursorFromLinkHeader(this HttpResponseMessage response)
    {
        if (!response.Headers.TryGetValues("Link", out var values))
        {
            return null;
        }

        var link = values.FirstOrDefault();
        if (string.IsNullOrEmpty(link) || !link.Contains("rel=\"next\""))
        {
            return null;
        }

        var cursorIndex = link.IndexOf("cursor=", System.StringComparison.OrdinalIgnoreCase);
        if (cursorIndex < 0)
        {
            return null;
        }

        var start = cursorIndex + "cursor=".Length;
        var end = link.IndexOfAny(new[] { '&', '>', '"' }, start);
        var rawCursor = end >= 0 ? link.Substring(start, end - start) : link.Substring(start);
        return System.Uri.UnescapeDataString(rawCursor);
    }
}
