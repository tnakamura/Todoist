using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Todoist.Clients;
using Todoist.Models;
using static Todoist.Endpoints;

namespace Todoist;

public partial class TodoistClient : IRemindersClient
{
    async ValueTask<IReadOnlyList<Reminder>> IRemindersClient.GetAllAsync(CancellationToken cancellationToken)
    {
        var response = await _client.GetAsync(
            requestUri: $"{GetRestBaseUri()}{ENDPOINT_REST_REMINDERS}",
            cancellationToken: cancellationToken)
            .ConfigureAwait(false);
        return await response.DeserializeAsync<IReadOnlyList<Reminder>>(cancellationToken)
            .ConfigureAwait(false);
    }

    async ValueTask<PagedResult<Reminder>> IRemindersClient.GetPageAsync(string? cursor, CancellationToken cancellationToken)
    {
        var query = new Dictionary<string, string?> { ["cursor"] = cursor };
        var response = await _client.GetAsync(
            requestUri: $"{GetRestBaseUri()}{ENDPOINT_REST_REMINDERS}",
            queryParameters: query,
            cancellationToken: cancellationToken)
            .ConfigureAwait(false);
        return await response.DeserializePageAsync<Reminder>(cancellationToken)
            .ConfigureAwait(false);
    }
}
