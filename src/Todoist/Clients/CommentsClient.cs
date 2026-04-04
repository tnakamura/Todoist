using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using Todoist.Clients;
using Todoist.Models;
using static Todoist.Endpoints;

namespace Todoist;

public partial class TodoistClient : ICommentsClient
{
    async ValueTask<Comment> ICommentsClient.CreateAsync(CreateCommentArgs args, string? requestId, CancellationToken cancellationToken)
    {
        var response = await _client.PostAsync(
            requestUri: $"{GetRestBaseUri()}{ENDPOINT_REST_COMMENTS}",
            payload: args,
            requestId: requestId,
            cancellationToken: cancellationToken)
            .ConfigureAwait(false);
        return await response.DeserializeAsync<Comment>(cancellationToken)
            .ConfigureAwait(false);
    }

    async ValueTask<bool> ICommentsClient.DeleteAsync(string id, string? requestId, CancellationToken cancellationToken)
    {
        var response = await _client.DeleteAsync(
            requestUri: $"{GetRestBaseUri()}{ENDPOINT_REST_COMMENTS}/{id}",
            requestId: requestId,
            cancellationToken: cancellationToken)
            .ConfigureAwait(false);
        return response.IsSuccessStatusCode;
    }

    async ValueTask<IReadOnlyList<Comment>> ICommentsClient.GetAllAsync(GetCommentsArgs args, CancellationToken cancellationToken)
    {
        var query = BuildQuery(args);

        var response = await _client.GetAsync(
            requestUri: $"{GetRestBaseUri()}{ENDPOINT_REST_COMMENTS}",
            queryParameters: query,
            cancellationToken: cancellationToken)
            .ConfigureAwait(false);
        return await response.DeserializeAsync<IReadOnlyList<Comment>>(cancellationToken)
            .ConfigureAwait(false);
    }

    async ValueTask<PagedResult<Comment>> ICommentsClient.GetPageAsync(GetCommentsArgs args, CancellationToken cancellationToken)
    {
        var query = BuildQuery(args);
        var response = await _client.GetAsync(
            requestUri: $"{GetRestBaseUri()}{ENDPOINT_REST_COMMENTS}",
            queryParameters: query,
            cancellationToken: cancellationToken)
            .ConfigureAwait(false);
        return await response.DeserializePageAsync<Comment>(cancellationToken)
            .ConfigureAwait(false);
    }

    async ValueTask<Comment> ICommentsClient.GetAsync(string id, CancellationToken cancellationToken)
    {
        var response = await _client.GetAsync(
            requestUri: $"{GetRestBaseUri()}{ENDPOINT_REST_COMMENTS}/{id}",
            cancellationToken: cancellationToken)
            .ConfigureAwait(false);
        return await response.DeserializeAsync<Comment>(cancellationToken)
            .ConfigureAwait(false);
    }

    async ValueTask<Comment> ICommentsClient.UpdateAsync(string id, UpdateCommentArgs args, string? requestId, CancellationToken cancellationToken)
    {
        var response = await _client.PostAsync(
            requestUri: $"{GetRestBaseUri()}{ENDPOINT_REST_COMMENTS}/{id}",
            payload: args,
            requestId: requestId,
            cancellationToken: cancellationToken)
            .ConfigureAwait(false);
        return await response.DeserializeAsync<Comment>(cancellationToken)
            .ConfigureAwait(false);
    }

    private static Dictionary<string, string?> BuildQuery(GetCommentsArgs args)
    {
        return new Dictionary<string, string?>
        {
            ["project_id"] = args.ProjectId,
            ["task_id"] = args.TaskId,
            ["cursor"] = args.Cursor,
        };
    }
}
