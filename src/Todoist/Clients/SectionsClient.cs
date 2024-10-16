using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Todoist.Clients;
using Todoist.Models;
using static Todoist.Endpoints;

namespace Todoist;

public partial class TodoistClient : ISectionsClient
{
    async ValueTask<Section> ISectionsClient.CreateAsync(CreateSectionArgs args, string? requestId, CancellationToken cancellationToken)
    {
        var response = await _client.PostAsync(
            requestUri: $"{GetRestBaseUri()}{ENDPOINT_REST_SECTIONS}",
            payload: args,
            requestId: requestId,
            cancellationToken: cancellationToken)
            .ConfigureAwait(false);
        return await response.DeserializeAsync<Section>(cancellationToken)
            .ConfigureAwait(false);
    }

    async ValueTask<bool> ISectionsClient.DeleteAsync(string id, string? requestId, CancellationToken cancellationToken)
    {
        var response = await _client.DeleteAsync(
            requestUri: $"{GetRestBaseUri()}{ENDPOINT_REST_SECTIONS}/{id}",
            requestId: requestId,
            cancellationToken: cancellationToken)
            .ConfigureAwait(false);
        return response.IsSuccessStatusCode;
    }

    async ValueTask<IReadOnlyList<Section>> ISectionsClient.GetAllAsync(string? projectId, CancellationToken cancellationToken)
    {
        var requestUri = $"{GetRestBaseUri()}{ENDPOINT_REST_SECTIONS}";
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

    async ValueTask<Section> ISectionsClient.GetAsync(string id, CancellationToken cancellationToken)
    {
        var response = await _client.GetAsync(
            requestUri: $"{GetRestBaseUri()}{ENDPOINT_REST_SECTIONS}/{id}",
            cancellationToken: cancellationToken)
            .ConfigureAwait(false);
        return await response.DeserializeAsync<Section>(cancellationToken)
            .ConfigureAwait(false);
    }

    async ValueTask<Section> ISectionsClient.UpdateAsync(string id, UpdateSectionArgs args, string? requestId, CancellationToken cancellationToken)
    {
        var response = await _client.PostAsync(
            requestUri: $"{GetRestBaseUri()}{ENDPOINT_REST_SECTIONS}/{id}",
            payload: args,
            requestId: requestId,
            cancellationToken: cancellationToken)
            .ConfigureAwait(false);
        return await response.DeserializeAsync<Section>(cancellationToken)
            .ConfigureAwait(false);
    }
}
