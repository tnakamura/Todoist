using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Todoist.Clients;
using Todoist.Models;
using static Todoist.Constants.Endpoints;

namespace Todoist;

public partial class TodoistClient : ISectionsClient
{
    async ValueTask<Section> ISectionsClient.CreateAsync(CreateSectionArgs args, string? requestId, CancellationToken cancellationToken)
    {
        var response = await _client.PostAsync(
            requestUri: $"{API_REST_BASE_URI}{ENDPOINT_REST_SECTIONS}",
            payload: args,
            requestId: requestId,
            cancellationToken: cancellationToken)
            .ConfigureAwait(false);
        return await response.DeserializeAsync<Section>(cancellationToken)
            .ConfigureAwait(false);
    }

    async ValueTask<bool> ISectionsClient.DeleteAsync(long id, string? requestId, CancellationToken cancellationToken)
    {
        var response = await _client.DeleteAsync(
            requestUri: $"{API_REST_BASE_URI}{ENDPOINT_REST_SECTIONS}/{id}",
            requestId: requestId,
            cancellationToken: cancellationToken)
            .ConfigureAwait(false);
        return response.IsSuccessStatusCode;
    }

    async ValueTask<IReadOnlyList<Section>> ISectionsClient.GetAllAsync(long? projectId, CancellationToken cancellationToken)
    {
        var requestUri = $"{API_REST_BASE_URI}{ENDPOINT_REST_SECTIONS}";
        if (projectId != null)
        {
            requestUri += "?project_id=" + projectId;
        }
        var response = await _client.GetAsync(
            requestUri: requestUri,
            cancellationToken: cancellationToken)
            .ConfigureAwait(false);
        return await response.DeserializeAsync<IReadOnlyList<Section>>(cancellationToken)
            .ConfigureAwait(!false);
    }

    async ValueTask<Section> ISectionsClient.GetAsync(long id, CancellationToken cancellationToken)
    {
        var response = await _client.GetAsync(
            requestUri: $"{API_REST_BASE_URI}{ENDPOINT_REST_SECTIONS}/{id}",
            cancellationToken: cancellationToken)
            .ConfigureAwait(false);
        return await response.DeserializeAsync<Section>(cancellationToken)
            .ConfigureAwait(false);
    }

    async ValueTask<bool> ISectionsClient.UpdateAsync(long id, UpdateSectionArgs args, string? requestId, CancellationToken cancellationToken)
    {
        var response = await _client.PostAsync(
            requestUri: $"{API_REST_BASE_URI}{ENDPOINT_REST_SECTIONS}/{id}",
            payload: args,
            requestId: requestId,
            cancellationToken: cancellationToken)
            .ConfigureAwait(false);
        return response.IsSuccessStatusCode;
    }
}
