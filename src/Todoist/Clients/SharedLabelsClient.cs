using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Todoist.Clients;
using Todoist.Models;
using static Todoist.Constants.Endpoints;

namespace Todoist;

public partial class TodoistClient : ISharedLabelsClient
{
    async ValueTask<IReadOnlyList<string>> ISharedLabelsClient.GetAllAsync(GetAllSharedLabelsArgs? args, CancellationToken cancellationToken)
    {
        var requestUri = $"{API_REST_BASE_URI}{ENDPOINT_REST_LABELS}/{ENDPOINT_REST_SHARED_LABELS}";
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
            requestUri: $"{API_REST_BASE_URI}{ENDPOINT_REST_LABELS}/{ENDPOINT_REST_SHARED_LABELS}/{ENDPOINT_REST_RENAME_SHARED_LABELS}",
            payload: args,
            cancellationToken: cancellationToken)
            .ConfigureAwait(false);
        return response.IsSuccessStatusCode;
    }

    async ValueTask<bool> ISharedLabelsClient.RemoveAsync(RemoveSharedLabelsArgs args, CancellationToken cancellationToken)
    {
        var response = await _client.PostAsync(
            requestUri: $"{API_REST_BASE_URI}{ENDPOINT_REST_LABELS}/{ENDPOINT_REST_SHARED_LABELS}/{ENDPOINT_REST_REMOVE_SHARED_LABELS}",
            payload: args,
            cancellationToken: cancellationToken)
            .ConfigureAwait(false);
        return response.IsSuccessStatusCode;
    }
}
