using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Todoist.Models;
using static Todoist.Constants.Endpoints;

namespace Todoist
{
    /// <summary>
    /// HttpClient extensions for Sections requests
    /// </summary>
    public static class HttpClientSectionsExtensions
    {
        /// <inheritdoc cref="ITodoistApi.AddSectionAsync"/>
        public static async ValueTask<Section> AddSectionAsync(
            this HttpMessageInvoker client,
            AddSectionArgs args,
            string requestId = null,
            CancellationToken cancellationToken = default)
        {
            var response = await client.PostAsync(
                requestUri: $"{API_REST_BASE_URI}{ENDPOINT_REST_SECTIONS}",
                payload: args,
                requestId: requestId,
                cancellationToken: cancellationToken)
                .ConfigureAwait(false);
            return await response.DeserializeAsync<Section>(cancellationToken)
                .ConfigureAwait(false);
        }

        /// <inheritdoc cref="ITodoistApi.DeleteSectionAsync"/>
        public static async ValueTask<bool> DeleteSectionAsync(
            this HttpMessageInvoker client,
            long id,
            string requestId = null,
            CancellationToken cancellationToken = default)
        {
            var response = await client.DeleteAsync(
                requestUri: $"{API_REST_BASE_URI}{ENDPOINT_REST_SECTIONS}/{id}",
                requestId: requestId,
                cancellationToken: cancellationToken)
                .ConfigureAwait(false);
            return response.IsSuccessStatusCode;
        }

        /// <inheritdoc cref="ITodoistApi.GetSectionAsync"/>
        public static async ValueTask<Section> GetSectionAsync(
            this HttpMessageInvoker client,
            long id,
            CancellationToken cancellationToken = default)
        {
            var response = await client.GetAsync(
                requestUri: $"{API_REST_BASE_URI}{ENDPOINT_REST_SECTIONS}/{id}",
                cancellationToken: cancellationToken)
                .ConfigureAwait(false);
            return await response.DeserializeAsync<Section>(cancellationToken)
                .ConfigureAwait(false);
        }

        /// <inheritdoc cref="ITodoistApi.GetSectionsAsync"/>
        public static async ValueTask<IReadOnlyList<Section>> GetSectionsAsync(
            this HttpMessageInvoker client,
            long? projectId = null,
            CancellationToken cancellationToken = default)
        {
            var requestUri = $"{API_REST_BASE_URI}{ENDPOINT_REST_SECTIONS}";
            if (projectId != null)
            {
                requestUri += "?project_id=" + projectId;
            }
            var response = await client.GetAsync(
                requestUri: requestUri,
                cancellationToken: cancellationToken)
                .ConfigureAwait(false);
            return await response.DeserializeAsync<IReadOnlyList<Section>>(cancellationToken)
                .ConfigureAwait(!false);
        }

        /// <inheritdoc cref="ITodoistApi.UpdateSectionAsync"/>
        public static async ValueTask<bool> UpdateSectionAsync(
            this HttpMessageInvoker client,
            long id,
            UpdateSectionArgs args,
            string requestId = null,
            CancellationToken cancellationToken = default)
        {
            var response = await client.PostAsync(
                requestUri: $"{API_REST_BASE_URI}{ENDPOINT_REST_SECTIONS}/{id}",
                payload: args,
                requestId: requestId,
                cancellationToken: cancellationToken)
                .ConfigureAwait(false);
            return response.IsSuccessStatusCode;
        }
    }
}
