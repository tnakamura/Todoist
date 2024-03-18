using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Todoist.Clients;
using Todoist.Models;
using static Todoist.Constants.Endpoints;

namespace Todoist
{
    public partial class TodoistClient : ICollaboratorsClient
    {
        async ValueTask<IReadOnlyList<User>> ICollaboratorsClient.GetAllAsync(long projectId, CancellationToken cancellationToken)
        {
            var response = await _client.GetAsync(
                requestUri: $"{API_REST_BASE_URI}{ENDPOINT_REST_PROJECTS}/{projectId}/collaborators",
                cancellationToken: cancellationToken)
                .ConfigureAwait(false);
            return await response.DeserializeAsync<IReadOnlyList<User>>(cancellationToken)
                .ConfigureAwait(false);
        }
    }
}
