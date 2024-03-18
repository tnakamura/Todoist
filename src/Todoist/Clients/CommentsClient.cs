using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using Todoist.Clients;
using Todoist.Models;
using static Todoist.Constants.Endpoints;

namespace Todoist;

public partial class TodoistClient : ICommentsClient
{
    async ValueTask<Comment> ICommentsClient.CreateAsync(CreateCommentArgs args, string requestId, CancellationToken cancellationToken)
    {
        var response = await _client.PostAsync(
            requestUri: $"{API_REST_BASE_URI}{ENDPOINT_REST_COMMENTS}",
            payload: args,
            requestId: requestId,
            cancellationToken: cancellationToken)
            .ConfigureAwait(false);
        return await response.DeserializeAsync<Comment>(cancellationToken)
            .ConfigureAwait(false);
    }

    async ValueTask<bool> ICommentsClient.DeleteAsync(long id, string requestId, CancellationToken cancellationToken)
    {
        var response = await _client.DeleteAsync(
            requestUri: $"{API_REST_BASE_URI}{ENDPOINT_REST_COMMENTS}/{id}",
            requestId: requestId,
            cancellationToken: cancellationToken)
            .ConfigureAwait(false);
        return response.IsSuccessStatusCode;
    }

    async ValueTask<IReadOnlyList<Comment>> ICommentsClient.GetAllAsync(GetCommentsArgs args, CancellationToken cancellationToken)
    {
        var requestUri = $"{API_REST_BASE_URI}{ENDPOINT_REST_COMMENTS}";

        var query = HttpUtility.ParseQueryString(string.Empty);
        if (args.ProjectId != null)
            query.Add("project_id", args.ProjectId.Value.ToString());
        if (args.TaskId != null)
            query.Add("task_id", args.TaskId.Value.ToString());
        if (query.HasKeys())
            requestUri += "?" + query.ToString();

        var response = await _client.GetAsync(
            requestUri: requestUri,
            cancellationToken: cancellationToken)
            .ConfigureAwait(false);
        return await response.DeserializeAsync<IReadOnlyList<Comment>>(cancellationToken)
            .ConfigureAwait(false);
    }

    async ValueTask<Comment> ICommentsClient.GetAsync(long id, CancellationToken cancellationToken)
    {
        var response = await _client.GetAsync(
            requestUri: $"{API_REST_BASE_URI}{ENDPOINT_REST_COMMENTS}/{id}",
            cancellationToken: cancellationToken)
            .ConfigureAwait(false);
        return await response.DeserializeAsync<Comment>(cancellationToken)
            .ConfigureAwait(false);
    }

    async ValueTask<bool> ICommentsClient.UpdateAsync(long id, UpdateCommentArgs args, string requestId, CancellationToken cancellationToken)
    {
        var response = await _client.PostAsync(
            requestUri: $"{API_REST_BASE_URI}{ENDPOINT_REST_COMMENTS}/{id}",
            payload: args,
            requestId: requestId,
            cancellationToken: cancellationToken)
            .ConfigureAwait(false);
        return response.IsSuccessStatusCode;
    }
}
