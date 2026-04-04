using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Todoist.Clients;
using Todoist.Models;
using static Todoist.Endpoints;

namespace Todoist;

public partial class TodoistClient : ISharedLabelsClient
{
    async ValueTask<IReadOnlyList<string>> ISharedLabelsClient.GetAllAsync(GetAllSharedLabelsArgs? args, CancellationToken cancellationToken)
    {
        var query = new Dictionary<string, string?>
        {
            ["omit_personal"] = args?.OmitPersonal?.ToString().ToLowerInvariant(),
            ["cursor"] = args?.Cursor,
        };
        var response = await _client.GetAsync(
            requestUri: $"{GetRestBaseUri()}{ENDPOINT_REST_LABELS_SHARED}",
            queryParameters: query,
            cancellationToken: cancellationToken)
            .ConfigureAwait(false);
        return await response.DeserializeAsync<IReadOnlyList<string>>(cancellationToken)
            .ConfigureAwait(false);
    }

    async ValueTask<PagedResult<string>> ISharedLabelsClient.GetPageAsync(GetAllSharedLabelsArgs? args, CancellationToken cancellationToken)
    {
        var query = new Dictionary<string, string?>
        {
            ["omit_personal"] = args?.OmitPersonal?.ToString().ToLowerInvariant(),
            ["cursor"] = args?.Cursor,
        };
        var response = await _client.GetAsync(
            requestUri: $"{GetRestBaseUri()}{ENDPOINT_REST_LABELS_SHARED}",
            queryParameters: query,
            cancellationToken: cancellationToken)
            .ConfigureAwait(false);
        return await response.DeserializePageAsync<string>(cancellationToken)
            .ConfigureAwait(false);
    }

    async ValueTask<bool> ISharedLabelsClient.RenameAsync(RenameSharedLabelsArgs args, CancellationToken cancellationToken)
    {
        var response = await _client.PostAsync(
            requestUri: $"{GetRestBaseUri()}{ENDPOINT_REST_LABELS_SHARED_RENAME}",
            payload: args,
            cancellationToken: cancellationToken)
            .ConfigureAwait(false);
        return response.IsSuccessStatusCode;
    }

    async ValueTask<bool> ISharedLabelsClient.RemoveAsync(RemoveSharedLabelsArgs args, CancellationToken cancellationToken)
    {
        var response = await _client.PostAsync(
            requestUri: $"{GetRestBaseUri()}{ENDPOINT_REST_LABELS_SHARED_REMOVE}",
            payload: args,
            cancellationToken: cancellationToken)
            .ConfigureAwait(false);
        return response.IsSuccessStatusCode;
    }
}
