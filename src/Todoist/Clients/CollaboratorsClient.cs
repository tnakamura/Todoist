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
}
