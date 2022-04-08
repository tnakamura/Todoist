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
    /// HttpClient extensions for Comments requests
    /// </summary>
    public static class HttpClientCommentsExtensions
    {
        /// <inheritdoc cref="ITodoistApi.AddCommentAsync"/>
        public static async ValueTask<Comment> AddCommentAsync(
            this HttpMessageInvoker client,
            AddCommentArgs args,
            string requestId = null,
            CancellationToken cancellationToken = default)
        {
            var response = await client.PostAsync(
                requestUri: $"{API_REST_BASE_URI}{ENDPOINT_REST_COMMENTS}",
                payload: args,
                requestId: requestId,
                cancellationToken: cancellationToken)
                .ConfigureAwait(false);
            return await response.DeserializeAsync<Comment>(cancellationToken)
                .ConfigureAwait(false);
        }

        /// <inheritdoc cref="ITodoistApi.DeleteCommentAsync"/>
        public static async ValueTask<bool> DeleteCommentAsync(
            this HttpMessageInvoker client,
            long id,
            string requestId = null,
            CancellationToken cancellationToken = default)
        {
            var response = await client.DeleteAsync(
                requestUri: $"{API_REST_BASE_URI}{ENDPOINT_REST_COMMENTS}/{id}",
                requestId: requestId,
                cancellationToken: cancellationToken)
                .ConfigureAwait(false);
            return response.IsSuccessStatusCode;
        }

        /// <inheritdoc cref="ITodoistApi.GetCommentAsync"/>
        public static async ValueTask<Comment> GetCommentAsync(
            this HttpMessageInvoker client,
            long id,
            CancellationToken cancellationToken = default)
        {
            var response = await client.GetAsync(
                requestUri: $"{API_REST_BASE_URI}{ENDPOINT_REST_COMMENTS}/{id}",
                cancellationToken: cancellationToken)
                .ConfigureAwait(false);
            return await response.DeserializeAsync<Comment>(cancellationToken)
                .ConfigureAwait(false);
        }

        /// <inheritdoc cref="ITodoistApi.GetCommentsAsync"/>
        public static async ValueTask<IReadOnlyList<Comment>> GetCommentsAsync(
            this HttpMessageInvoker client,
            GetCommentsArgs args,
            CancellationToken cancellationToken = default)
        {
            var requestUri = $"{API_REST_BASE_URI}{ENDPOINT_REST_COMMENTS}";

            var query = HttpUtility.ParseQueryString(string.Empty);
            if (args.ProjectId != null)
                query.Add("project_id", args.ProjectId.Value.ToString());
            if (args.TaskId != null)
                query.Add("task_id", args.TaskId.Value.ToString());
            if (query.HasKeys())
                requestUri += "?" + query.ToString();

            var response = await client.GetAsync(
                requestUri: requestUri,
                cancellationToken: cancellationToken)
                .ConfigureAwait(false);
            return await response.DeserializeAsync<IReadOnlyList<Comment>>(cancellationToken)
                .ConfigureAwait(false);
        }

        /// <inheritdoc cref="ITodoistApi.UpdateCommentAsync"/>
        public static async ValueTask<bool> UpdateCommentAsync(
            this HttpMessageInvoker client,
            long id,
            UpdateCommentArgs args,
            string requestId = null,
            CancellationToken cancellationToken = default)
        {
            var response = await client.PostAsync(
                requestUri: $"{API_REST_BASE_URI}{ENDPOINT_REST_COMMENTS}/{id}",
                payload: args,
                requestId: requestId,
                cancellationToken: cancellationToken)
                .ConfigureAwait(false);
            return response.IsSuccessStatusCode;
        }
    }
}
