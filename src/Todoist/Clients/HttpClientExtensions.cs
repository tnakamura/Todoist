using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace Todoist
{
    internal static class HttpClientExtensions
    {
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
                throw new TodoistException(responseBody);
            }

#if DEBUG
            var debugBody = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            Debug.WriteLine(debugBody);
#endif

            var responseStream = await response.Content.ReadAsStreamAsync()
                .ConfigureAwait(false);
            return await JsonSerializer.DeserializeAsync<T>(responseStream, cancellationToken: cancellationToken)
                .ConfigureAwait(false);
        }

        public static async ValueTask<HttpResponseMessage> PostAsync<TArgs>(
            this HttpMessageInvoker client,
            string requestUri,
            TArgs payload,
            string requestId = null,
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
            string requestId = null,
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
            string requestId = null)
        {
            var request = new HttpRequestMessage(method, requestUri);

            if (!string.IsNullOrEmpty(requestId))
            {
                request.Headers.Add("X-Request-Id", requestId);
            }

            return request;
        }
    }
}
