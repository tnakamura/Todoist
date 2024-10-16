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
        var requestUri = $"{GetRestBaseUri()}{ENDPOINT_REST_LABELS_SHARED}";
        if (args is not null && args.OmitPersonal is not null)
        {
            requestUri += $"?omit_personal={args.OmitPersonal}";
        }
        var response = await _client.GetAsync(
            requestUri: requestUri,
            cancellationToken: cancellationToken)
            .ConfigureAwait(false);
        return await response.DeserializeAsync<IReadOnlyList<string>>(cancellationToken)
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
