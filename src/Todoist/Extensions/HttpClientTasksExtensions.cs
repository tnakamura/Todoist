using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using Todoist.Models;
using static Todoist.Constants.Endpoints;

namespace Todoist
{
    /// <summary>
    /// HttpClient extensions for Tasks requests
    /// </summary>
    public static class HttpClientTasksExtensions
    {
        /// <inheritdoc cref="ITodoistApi.AddTaskAsync"/>
        public static async ValueTask<Models.Task> AddTaskAsync(
            this HttpMessageInvoker client,
            AddTaskArgs args,
            string requestId = null,
            CancellationToken cancellationToken = default)
        {
            var response = await client.PostAsync(
                requestUri: $"{API_REST_BASE_URI}{ENDPOINT_REST_TASKS}",
                payload: args,
                requestId: requestId,
                cancellationToken: cancellationToken)
                .ConfigureAwait(false);
            return await response.DeserializeAsync<Models.Task>(cancellationToken)
                .ConfigureAwait(false);
        }

        /// <inheritdoc cref="ITodoistApi.CloseTaskAsync"/>
        public static async ValueTask<bool> CloseTaskAsync(
            this HttpMessageInvoker client,
            long id,
            string requestId = null,
            CancellationToken cancellationToken = default)
        {
            var response = await client.PostAsync<object>(
                requestUri: $"{API_REST_BASE_URI}{ENDPOINT_REST_TASKS}/{id}/{ENDPOINT_REST_TASK_CLOSE}",
                payload: null,
                requestId: requestId,
                cancellationToken: cancellationToken)
                .ConfigureAwait(false);
            return response.IsSuccessStatusCode;
        }

        /// <inheritdoc cref="ITodoistApi.DeleteTaskAsync"/>
        public static async ValueTask<bool> DeleteTaskAsync(
            this HttpMessageInvoker client,
            long id,
            string requestId = null,
            CancellationToken cancellationToken = default)
        {
            var response = await client.DeleteAsync(
                requestUri: $"{API_REST_BASE_URI}{ENDPOINT_REST_TASKS}/{id}",
                requestId: requestId,
                cancellationToken: cancellationToken)
                .ConfigureAwait(false);
            return response.IsSuccessStatusCode;
        }

        /// <inheritdoc cref="ITodoistApi.GetTaskAsync"/>
        public static async ValueTask<Models.Task> GetTaskAsync(
            this HttpMessageInvoker client,
            long id,
            CancellationToken cancellationToken = default)
        {
            var response = await client.GetAsync(
                requestUri: $"{API_REST_BASE_URI}{ENDPOINT_REST_TASKS}/{id}",
                cancellationToken: cancellationToken)
                .ConfigureAwait(false);
            return await response.DeserializeAsync<Models.Task>(cancellationToken)
                .ConfigureAwait(false);
        }

        /// <inheritdoc cref="ITodoistApi.GetTasksAsync"/>
        public static async ValueTask<IReadOnlyList<Models.Task>> GetTasksAsync(
            this HttpMessageInvoker client,
            GetTasksArgs args = null,
            CancellationToken cancellationToken = default)
        {
            var requestUri = $"{API_REST_BASE_URI}{ENDPOINT_REST_TASKS}";
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
            var response = await client.GetAsync(
                requestUri: requestUri,
                cancellationToken: cancellationToken)
                .ConfigureAwait(false);
            return await response.DeserializeAsync<IReadOnlyList<Models.Task>>()
                .ConfigureAwait(false);
        }

        /// <inheritdoc cref="ITodoistApi.QuickAddTaskAsync"/>
        public static async ValueTask<Models.Task> QuickAddTaskAsync(
            this HttpMessageInvoker client,
            QuickAddTaskArgs args,
            CancellationToken cancellationToken = default)
        {
            var response = await client.PostAsync(
                requestUri: $"",
                payload: args,
                cancellationToken: cancellationToken)
                .ConfigureAwait(false);
            var task = await response.DeserializeAsync<QuickAddTaskResponse>(cancellationToken)
                .ConfigureAwait(false);
            return new Models.Task(
                id: task.Id,
                projectId: task.ProjectId,
                sectionId: task.SectionId ?? default,
                content: task.Content,
                description: task.Description);
        }

        /// <inheritdoc cref="ITodoistApi.ReopenTaskAsync"/>
        public static async ValueTask<bool> ReopenTaskAsync(
            this HttpMessageInvoker client,
            long id,
            string requestId = null,
            CancellationToken cancellationToken = default)
        {
            var response = await client.PostAsync<object>(
                requestUri: $"{API_REST_BASE_URI}{ENDPOINT_REST_TASKS}/{id}/{ENDPOINT_REST_TASK_REOPEN}",
                payload: null,
                requestId: requestId,
                cancellationToken: cancellationToken)
                .ConfigureAwait(false);
            return response.IsSuccessStatusCode;
        }

        /// <inheritdoc cref="ITodoistApi.UpdateTaskAsync"/>
        public static async ValueTask<bool> UpdateTaskAsync(
            this HttpMessageInvoker client,
            long id,
            UpdateTaskArgs args,
            string requestId = null,
            CancellationToken cancellationToken = default)
        {
            var response = await client.PostAsync(
                requestUri: $"{API_REST_BASE_URI}{ENDPOINT_REST_TASKS}/{id}",
                payload: args,
                requestId: requestId,
                cancellationToken: cancellationToken)
                .ConfigureAwait(false);
            return response.IsSuccessStatusCode;
        }
    }
}
