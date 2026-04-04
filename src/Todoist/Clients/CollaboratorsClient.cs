using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Todoist.Clients;
using Todoist.Models;
using static Todoist.Endpoints;

namespace Todoist;

public partial class TodoistClient : ICollaboratorsClient
{
    async ValueTask<IReadOnlyList<User>> ICollaboratorsClient.GetAllAsync(string projectId, CancellationToken cancellationToken)
    {
        var response = await _client.GetAsync(
            requestUri: $"{GetRestBaseUri()}{ENDPOINT_REST_PROJECTS}/{projectId}/collaborators",
            cancellationToken: cancellationToken)
            .ConfigureAwait(false);
        return await response.DeserializeAsync<IReadOnlyList<User>>(cancellationToken)
            .ConfigureAwait(false);
    }

    async ValueTask<PagedResult<User>> ICollaboratorsClient.GetPageAsync(string projectId, string? cursor, CancellationToken cancellationToken)
    {
        var query = new Dictionary<string, string?> { ["cursor"] = cursor };
        var response = await _client.GetAsync(
            requestUri: $"{GetRestBaseUri()}{ENDPOINT_REST_PROJECTS}/{projectId}/collaborators",
            queryParameters: query,
            cancellationToken: cancellationToken)
            .ConfigureAwait(false);
        return await response.DeserializePageAsync<User>(cancellationToken)
            .ConfigureAwait(false);
    }
}
