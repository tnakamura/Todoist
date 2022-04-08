using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Todoist.Models;
using static Todoist.Constants.Endpoints;

namespace Todoist
{
    /// <summary>
    /// HttpClient extensions for Projects requests
    /// </summary>
    public static class HttpClientProjectsExtensions
    {
        /// <inheritdoc cref="ITodoistApi.AddProjectAsync"/>
        public static async ValueTask<Project> AddProjectAsync(
            this HttpMessageInvoker client,
            AddProjectArgs args,
            string requestId = null,
            CancellationToken cancellationToken = default)
        {
            var response = await client.PostAsync(
                requestUri: $"{API_REST_BASE_URI}{ENDPOINT_REST_PROJECTS}",
                payload: args,
                requestId: requestId,
                cancellationToken: cancellationToken)
                .ConfigureAwait(false);
            return await response.DeserializeAsync<Project>(cancellationToken)
                .ConfigureAwait(false);
        }

        /// <inheritdoc cref="ITodoistApi.DeleteProjectAsync"/>
        public static async ValueTask<bool> DeleteProjectAsync(
            this HttpMessageInvoker client,
            long id,
            string requestId = null,
            CancellationToken cancellationToken = default)
        {
            var response = await client.DeleteAsync(
                requestUri: $"{API_REST_BASE_URI}{ENDPOINT_REST_PROJECTS}/{id}",
                requestId: requestId,
                cancellationToken: cancellationToken)
                .ConfigureAwait(false);
            return response.IsSuccessStatusCode;
        }

        /// <inheritdoc cref="ITodoistApi.GetProjectAsync"/>
        public static async ValueTask<Project> GetProjectAsync(
            this HttpMessageInvoker client,
            long id,
            CancellationToken cancellationToken = default)
        {
            var response = await client.GetAsync(
                requestUri: $"{API_REST_BASE_URI}{ENDPOINT_REST_PROJECTS}/{id}",
                cancellationToken: cancellationToken)
                .ConfigureAwait(false);
            return await response.DeserializeAsync<Project>(cancellationToken)
                .ConfigureAwait(false);
        }

        /// <inheritdoc cref="ITodoistApi.GetProjectCollaboratorsAsync"/>
        public static async ValueTask<IReadOnlyList<User>> GetProjectCollaboratorsAsync(
            this HttpMessageInvoker client,
            long projectId,
            CancellationToken cancellationToken = default)
        {
            var response = await client.GetAsync(
                requestUri: $"{API_REST_BASE_URI}{ENDPOINT_REST_PROJECTS}/{projectId}/collaborators",
                cancellationToken: cancellationToken)
                .ConfigureAwait(false);
            return await response.DeserializeAsync<IReadOnlyList<User>>(cancellationToken)
                .ConfigureAwait(false);
        }

        /// <inheritdoc cref="ITodoistApi.GetProjectsAsync"/>
        public static async ValueTask<IReadOnlyList<Project>> GetProjectsAsync(
            this HttpMessageInvoker client,
            CancellationToken cancellationToken = default)
        {
            var response = await client.GetAsync(
                requestUri: $"{API_REST_BASE_URI}{ENDPOINT_REST_PROJECTS}",
                cancellationToken: cancellationToken)
                .ConfigureAwait(false);
            return await response.DeserializeAsync<IReadOnlyList<Project>>(cancellationToken)
                .ConfigureAwait(false);
        }

        /// <inheritdoc cref="ITodoistApi.UpdateProjectAsync"/>
        public static async ValueTask<bool> UpdateProjectAsync(
            this HttpMessageInvoker client,
            long id,
            UpdateProjectArgs args,
            string requestId = null,
            CancellationToken cancellationToken = default)
        {
            var response = await client.PostAsync(
                requestUri: $"{API_REST_BASE_URI}{ENDPOINT_REST_PROJECTS}/{id}",
                payload: args,
                requestId: requestId,
                cancellationToken: cancellationToken)
                .ConfigureAwait(false);
            return response.IsSuccessStatusCode;
        }
    }
}
