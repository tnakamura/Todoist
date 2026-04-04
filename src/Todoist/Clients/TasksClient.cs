using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using Todoist.Clients;
using Todoist.Models;
using static Todoist.Endpoints;

namespace Todoist;

public partial class TodoistClient : ITasksClient
{
    async ValueTask<Models.Task> ITasksClient.QuickAddAsync(QuickAddTaskArgs args, string? requestId, CancellationToken cancellationToken)
    {
        var response = await _client.PostAsync(
            requestUri: $"{GetRestBaseUri()}{ENDPOINT_SYNC_QUICK_ADD}",
            payload: args,
            requestId: requestId,
            cancellationToken: cancellationToken)
            .ConfigureAwait(false);
        return await response.DeserializeAsync<Models.Task>(cancellationToken)
            .ConfigureAwait(false);
    }

    async ValueTask<Models.Task> ITasksClient.CreateAsync(CreateTaskArgs args, string? requestId, CancellationToken cancellationToken)
    {
        var response = await _client.PostAsync(
            requestUri: $"{GetRestBaseUri()}{ENDPOINT_REST_TASKS}",
            payload: args,
            requestId: requestId,
            cancellationToken: cancellationToken)
            .ConfigureAwait(false);
        return await response.DeserializeAsync<Models.Task>(cancellationToken)
            .ConfigureAwait(false);
    }

    async ValueTask<bool> ITasksClient.CloseAsync(string id, string? requestId, CancellationToken cancellationToken)
    {
        var response = await _client.PostAsync<object?>(
            requestUri: $"{GetRestBaseUri()}{ENDPOINT_REST_TASKS}/{id}/{ENDPOINT_REST_TASK_CLOSE}",
            payload: null,
            requestId: requestId,
            cancellationToken: cancellationToken)
            .ConfigureAwait(false);
        return response.IsSuccessStatusCode;
    }

    async ValueTask<bool> ITasksClient.DeleteAsync(string id, string? requestId, CancellationToken cancellationToken)
    {
        var response = await _client.DeleteAsync(
            requestUri: $"{GetRestBaseUri()}{ENDPOINT_REST_TASKS}/{id}",
            requestId: requestId,
            cancellationToken: cancellationToken)
            .ConfigureAwait(false);
        return response.IsSuccessStatusCode;
    }

    async ValueTask<IReadOnlyList<Models.Task>> ITasksClient.GetAllAsync(GetTasksArgs? args, CancellationToken cancellationToken)
    {
        var requestUri = $"{GetRestBaseUri()}{ENDPOINT_REST_TASKS}";
        var query = BuildTaskQuery(args);
        var response = await _client.GetAsync(
            requestUri: requestUri,
            queryParameters: query,
            cancellationToken: cancellationToken)
            .ConfigureAwait(false);
        return await response.DeserializeAsync<IReadOnlyList<Models.Task>>()
            .ConfigureAwait(false);
    }

    async ValueTask<PagedResult<Models.Task>> ITasksClient.GetPageAsync(GetTasksArgs? args, string? cursor, CancellationToken cancellationToken)
    {
        var requestUri = $"{GetRestBaseUri()}{ENDPOINT_REST_TASKS}";
        var query = BuildTaskQuery(args);
        if (!string.IsNullOrEmpty(cursor))
        {
            query["cursor"] = cursor;
        }
        var response = await _client.GetAsync(
            requestUri: requestUri,
            queryParameters: query,
            cancellationToken: cancellationToken)
            .ConfigureAwait(false);
        return await response.DeserializePageAsync<Models.Task>(cancellationToken)
            .ConfigureAwait(false);
    }

    async ValueTask<Models.Task> ITasksClient.GetAsync(string id, CancellationToken cancellationToken)
    {
        var response = await _client.GetAsync(
            requestUri: $"{GetRestBaseUri()}{ENDPOINT_REST_TASKS}/{id}",
            cancellationToken: cancellationToken)
            .ConfigureAwait(false);
        return await response.DeserializeAsync<Models.Task>(cancellationToken)
            .ConfigureAwait(false);
    }

    async ValueTask<bool> ITasksClient.ReopenAsync(string id, string? requestId, CancellationToken cancellationToken)
    {
        var response = await _client.PostAsync<object?>(
            requestUri: $"{GetRestBaseUri()}{ENDPOINT_REST_TASKS}/{id}/{ENDPOINT_REST_TASK_REOPEN}",
            payload: null,
            requestId: requestId,
            cancellationToken: cancellationToken)
            .ConfigureAwait(false);
        return response.IsSuccessStatusCode;
    }

    async ValueTask<Models.Task> ITasksClient.UpdateAsync(string id, UpdateTaskArgs args, string? requestId, CancellationToken cancellationToken)
    {
        var response = await _client.PostAsync(
            requestUri: $"{GetRestBaseUri()}{ENDPOINT_REST_TASKS}/{id}",
            payload: args,
            requestId: requestId,
            cancellationToken: cancellationToken)
            .ConfigureAwait(false);
        return await response.DeserializeAsync<Models.Task>(cancellationToken)
            .ConfigureAwait(false);
    }

    private static Dictionary<string, string?> BuildTaskQuery(GetTasksArgs? args)
    {
        var query = new Dictionary<string, string?>();
        if (args == null)
        {
            return query;
        }

        query["project_id"] = args.ProjectId;
        query["section_id"] = args.SectionId;
        query["label_id"] = args.LabelId;
        query["lang"] = args.Lang;
        query["filter"] = args.Filter;
        query["cursor"] = args.Cursor;
        if (args.Ids != null && args.Ids.Count > 0)
        {
            query["ids"] = string.Join(",", args.Ids);
        }
        return query;
    }
}
