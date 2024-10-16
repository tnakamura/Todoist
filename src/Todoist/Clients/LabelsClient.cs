using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Todoist.Clients;
using Todoist.Models;
using static Todoist.Constants.Endpoints;

namespace Todoist;

public partial class TodoistClient : ILabelsClient
{
    async ValueTask<Label> ILabelsClient.CreateAsync(CreateLabelArgs args, string? requestId, CancellationToken cancellationToken)
    {
        var response = await _client.PostAsync(
            requestUri: $"{API_REST_BASE_URI}{ENDPOINT_REST_LABELS}",
            payload: args,
            requestId: requestId,
            cancellationToken: cancellationToken)
            .ConfigureAwait(false);
        return await response.DeserializeAsync<Label>(cancellationToken)
            .ConfigureAwait(false);
    }

    async ValueTask<bool> ILabelsClient.DeleteAsync(string id, string? requestId, CancellationToken cancellationToken)
    {
        var response = await _client.DeleteAsync(
            requestUri: $"{API_REST_BASE_URI}{ENDPOINT_REST_LABELS}/{id}",
            requestId: requestId,
            cancellationToken: cancellationToken)
            .ConfigureAwait(false);
        return response.IsSuccessStatusCode;
    }

    async ValueTask<IReadOnlyList<Label>> ILabelsClient.GetAllAsync(CancellationToken cancellationToken)
    {
        var response = await _client.GetAsync(
            requestUri: $"{API_REST_BASE_URI}{ENDPOINT_REST_LABELS}",
            cancellationToken: cancellationToken)
            .ConfigureAwait(false);
        return await response.DeserializeAsync<IReadOnlyList<Label>>(cancellationToken)
            .ConfigureAwait(false);
    }

    async ValueTask<Label> ILabelsClient.GetAsync(string id, CancellationToken cancellationToken)
    {
        var response = await _client.GetAsync(
            requestUri: $"{API_REST_BASE_URI}{ENDPOINT_REST_LABELS}/{id}",
            cancellationToken: cancellationToken)
            .ConfigureAwait(false);
        return await response.DeserializeAsync<Label>(cancellationToken)
            .ConfigureAwait(false);
    }

    async ValueTask<Label> ILabelsClient.UpdateAsync(string id, UpdateLabelArgs args, string? requestId, CancellationToken cancellationToken)
    {
        var response = await _client.PostAsync(
            requestUri: $"{API_REST_BASE_URI}{ENDPOINT_REST_LABELS}/{id}",
            payload: args,
            requestId: requestId,
            cancellationToken: cancellationToken)
            .ConfigureAwait(false);
        return await response.DeserializeAsync<Label>(cancellationToken)
            .ConfigureAwait(false);
    }

    ISharedLabelsClient ILabelsClient.SharedLabels => this;
}
