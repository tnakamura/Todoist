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
        if (args != null)
        {
            var query = HttpUtility.ParseQueryString(string.Empty);
            if (args.ProjectId != null)
                query.Add("project_id", args.ProjectId.Value.ToString());
            if (args.SectionId != null)
                query.Add("section_id", args.SectionId.Value.ToString());
            if (args.LabelId != null)
                query.Add("label_id", args.LabelId.Value.ToString());
            if (args.Lang != null)
                query.Add("lang", args.Lang);
            if (args.Filter != null)
                query.Add("filter", args.Filter);
            if (query.HasKeys())
                requestUri += "?" + query.ToString();
        }
        var response = await _client.GetAsync(
            requestUri: requestUri,
            cancellationToken: cancellationToken)
            .ConfigureAwait(false);
        return await response.DeserializeAsync<IReadOnlyList<Models.Task>>()
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
}
