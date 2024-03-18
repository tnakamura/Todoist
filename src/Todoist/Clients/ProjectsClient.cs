using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Todoist.Clients;
using Todoist.Models;
using static Todoist.Constants.Endpoints;

namespace Todoist
{
    public partial class TodoistClient : IProjectsClient
    {
        async ValueTask<Project> IProjectsClient.CreateAsync(CreateProjectArgs args, string requestId, CancellationToken cancellationToken)
        {
            var response = await _client.PostAsync(
                requestUri: $"{API_REST_BASE_URI}{ENDPOINT_REST_PROJECTS}",
                payload: args,
                requestId: requestId,
                cancellationToken: cancellationToken)
                .ConfigureAwait(false);
            return await response.DeserializeAsync<Project>(cancellationToken)
                .ConfigureAwait(false);
        }

        async ValueTask<bool> IProjectsClient.DeleteAsync(long id, string requestId, CancellationToken cancellationToken)
        {
            var response = await _client.DeleteAsync(
                requestUri: $"{API_REST_BASE_URI}{ENDPOINT_REST_PROJECTS}/{id}",
                requestId: requestId,
                cancellationToken: cancellationToken)
                .ConfigureAwait(false);
            return response.IsSuccessStatusCode;
        }

        async ValueTask<IReadOnlyList<Project>> IProjectsClient.GetAllAsync(CancellationToken cancellationToken)
        {
            var response = await _client.GetAsync(
                requestUri: $"{API_REST_BASE_URI}{ENDPOINT_REST_PROJECTS}",
                cancellationToken: cancellationToken)
                .ConfigureAwait(false);
            return await response.DeserializeAsync<IReadOnlyList<Project>>(cancellationToken)
                .ConfigureAwait(false);
        }

        async ValueTask<Project> IProjectsClient.GetAsync(long id, CancellationToken cancellationToken)
        {
            var response = await _client.GetAsync(
                requestUri: $"{API_REST_BASE_URI}{ENDPOINT_REST_PROJECTS}/{id}",
                cancellationToken: cancellationToken)
                .ConfigureAwait(false);
            return await response.DeserializeAsync<Project>(cancellationToken)
                .ConfigureAwait(false);
        }

        async ValueTask<bool> IProjectsClient.UpdateAsync(long id, UpdateProjectArgs args, string requestId, CancellationToken cancellationToken)
        {
            var response = await _client.PostAsync(
                requestUri: $"{API_REST_BASE_URI}{ENDPOINT_REST_PROJECTS}/{id}",
                payload: args,
                requestId: requestId,
                cancellationToken: cancellationToken)
                .ConfigureAwait(false);
            return response.IsSuccessStatusCode;
        }

        ICollaboratorsClient IProjectsClient.Collaborators => this;
    }
}
