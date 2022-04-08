using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Todoist.Models;
using static Todoist.Constants.Endpoints;

namespace Todoist
{
    /// <summary>
    /// HttpClient extensions for Labels requests
    /// </summary>
    public static class HttpClientLabelsExtensions
    {
        /// <inheritdoc cref="ITodoistApi.AddLabelAsync"/>
        public static async ValueTask<Label> AddLabelAsync(
            this HttpMessageInvoker client,
            AddLabelArgs args,
            string requestId = null,
            CancellationToken cancellationToken = default)
        {
            var response = await client.PostAsync(
                requestUri: $"{API_REST_BASE_URI}{ENDPOINT_REST_LABELS}",
                payload: args,
                requestId: requestId,
                cancellationToken: cancellationToken)
                .ConfigureAwait(false);
            return await response.DeserializeAsync<Label>(cancellationToken)
                .ConfigureAwait(false);
        }

        /// <inheritdoc cref="ITodoistApi.DeleteLabelAsync"/>
        public static async ValueTask<bool> DeleteLabelAsync(
            this HttpMessageInvoker client,
            long id,
            string requestId = null,
            CancellationToken cancellationToken = default)
        {
            var response = await client.DeleteAsync(
                requestUri: $"{API_REST_BASE_URI}{ENDPOINT_REST_LABELS}/{id}",
                requestId: requestId,
                cancellationToken: cancellationToken)
                .ConfigureAwait(false);
            return response.IsSuccessStatusCode;
        }

        /// <inheritdoc cref="ITodoistApi.GetLabelAsync"/>
        public static async ValueTask<Label> GetLabelAsync(
            this HttpMessageInvoker client,
            long id,
            CancellationToken cancellationToken = default)
        {
            var response = await client.GetAsync(
                requestUri: $"{API_REST_BASE_URI}{ENDPOINT_REST_LABELS}/{id}",
                cancellationToken: cancellationToken)
                .ConfigureAwait(false);
            return await response.DeserializeAsync<Label>(cancellationToken)
                .ConfigureAwait(false);
        }

        /// <inheritdoc cref="ITodoistApi.GetLabelsAsync"/>
        public static async ValueTask<IReadOnlyList<Label>> GetLabelsAsync(
            this HttpMessageInvoker client,
            CancellationToken cancellationToken = default)
        {
            var response = await client.GetAsync(
                requestUri: $"{API_REST_BASE_URI}{ENDPOINT_REST_LABELS}",
                cancellationToken: cancellationToken)
                .ConfigureAwait(false);
            return await response.DeserializeAsync<IReadOnlyList<Label>>(cancellationToken)
                .ConfigureAwait(false);
        }

        /// <inheritdoc cref="ITodoistApi.UpdateLabelAsync"/>
        public static async ValueTask<bool> UpdateLabelAsync(
            this HttpMessageInvoker client,
            long id,
            UpdateLabelArgs args,
            string requestId = null,
            CancellationToken cancellationToken = default)
        {
            var response = await client.PostAsync(
                requestUri: $"{API_REST_BASE_URI}{ENDPOINT_REST_LABELS}/{id}",
                payload: args,
                requestId: requestId,
                cancellationToken: cancellationToken)
                .ConfigureAwait(false);
            return response.IsSuccessStatusCode;
        }
    }
}
