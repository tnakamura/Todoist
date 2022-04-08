using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Todoist.Models;

namespace Todoist
{
    /// <inheritdoc cref="ITodoistApi"/>
    public class TodoistApi : ITodoistApi
    {
        private readonly string _accessToken;

        private readonly HttpClient _client;

        /// <summary>
        /// Initializes a new instance of the <see cref="TodoistApi"/> class.
        /// </summary>
        public TodoistApi(string accessToken, HttpClient httpClient = null)
        {
            _accessToken = accessToken ?? throw new ArgumentNullException(nameof(accessToken));
            _client = httpClient ?? new HttpClient();
            _client.SetBearerToken(_accessToken);
        }

        /// <inheritdoc/>
        public ValueTask<Comment> AddCommentAsync(AddCommentArgs args, string requestId = null, CancellationToken cancellationToken = default) =>
            _client.AddCommentAsync(args, requestId, cancellationToken);

        /// <inheritdoc/>
        public ValueTask<Label> AddLabelAsync(AddLabelArgs args, string requestId = null, CancellationToken cancellationToken = default) =>
            _client.AddLabelAsync(args, requestId, cancellationToken);

        /// <inheritdoc/>
        public ValueTask<Project> AddProjectAsync(AddProjectArgs args, string requestId = null, CancellationToken cancellationToken = default) =>
            _client.AddProjectAsync(args, requestId, cancellationToken);

        /// <inheritdoc/>
        public ValueTask<Section> AddSectionAsync(AddSectionArgs args, string requestId = null, CancellationToken cancellationToken = default) =>
            _client.AddSectionAsync(args, requestId, cancellationToken);

        /// <inheritdoc/>
        public ValueTask<Models.Task> AddTaskAsync(AddTaskArgs args, string requestId = null, CancellationToken cancellationToken = default) =>
            _client.AddTaskAsync(args, requestId, cancellationToken);

        /// <inheritdoc/>
        public ValueTask<bool> CloseTaskAsync(long id, string requestId = null, CancellationToken cancellationToken = default) =>
            _client.CloseTaskAsync(id, requestId, cancellationToken);

        /// <inheritdoc/>
        public ValueTask<bool> DeleteCommentAsync(long id, string requestId = null, CancellationToken cancellationToken = default) =>
            _client.DeleteCommentAsync(id, requestId, cancellationToken);

        /// <inheritdoc/>
        public ValueTask<bool> DeleteLabelAsync(long id, string requestId = null, CancellationToken cancellationToken = default) =>
            _client.DeleteLabelAsync(id, requestId, cancellationToken);

        /// <inheritdoc/>
        public ValueTask<bool> DeleteProjectAsync(long id, string requestId = null, CancellationToken cancellationToken = default) =>
            _client.DeleteProjectAsync(id, requestId, cancellationToken);

        /// <inheritdoc/>
        public ValueTask<bool> DeleteSectionAsync(long id, string requestId = null, CancellationToken cancellationToken = default) =>
            _client.DeleteSectionAsync(id, requestId, cancellationToken);

        /// <inheritdoc/>
        public ValueTask<bool> DeleteTaskAsync(long id, string requestId = null, CancellationToken cancellationToken = default) =>
            _client.DeleteTaskAsync(id, requestId, cancellationToken);

        /// <inheritdoc/>
        public ValueTask<Comment> GetCommentAsync(long id, CancellationToken cancellationToken = default) =>
            _client.GetCommentAsync(id, cancellationToken);

        /// <inheritdoc/>
        public ValueTask<IReadOnlyList<Comment>> GetCommentsAsync(GetCommentsArgs args, CancellationToken cancellationToken = default) =>
            _client.GetCommentsAsync(args, cancellationToken);

        /// <inheritdoc/>
        public ValueTask<Label> GetLabelAsync(long id, CancellationToken cancellationToken = default) =>
            _client.GetLabelAsync(id, cancellationToken);

        /// <inheritdoc/>
        public ValueTask<IReadOnlyList<Label>> GetLabelsAsync(CancellationToken cancellationToken = default) =>
            _client.GetLabelsAsync(cancellationToken);

        /// <inheritdoc/>
        public ValueTask<Project> GetProjectAsync(long id, CancellationToken cancellationToken = default) =>
            _client.GetProjectAsync(id, cancellationToken);

        /// <inheritdoc/>
        public ValueTask<IReadOnlyList<User>> GetProjectCollaboratorsAsync(long projectId, CancellationToken cancellationToken = default) =>
            _client.GetProjectCollaboratorsAsync(projectId, cancellationToken);

        /// <inheritdoc/>
        public ValueTask<IReadOnlyList<Project>> GetProjectsAsync(CancellationToken cancellationToken = default) =>
            _client.GetProjectsAsync(cancellationToken);

        /// <inheritdoc/>
        public ValueTask<Section> GetSectionAsync(long id, CancellationToken cancellationToken = default) =>
            _client.GetSectionAsync(id, cancellationToken);

        /// <inheritdoc/>
        public ValueTask<IReadOnlyList<Section>> GetSectionsAsync(long? projectId = null, CancellationToken cancellationToken = default) =>
            _client.GetSectionsAsync(projectId, cancellationToken);

        /// <inheritdoc/>
        public ValueTask<Models.Task> GetTaskAsync(long id, CancellationToken cancellationToken = default) =>
            _client.GetTaskAsync(id, cancellationToken);

        /// <inheritdoc/>
        public ValueTask<IReadOnlyList<Models.Task>> GetTasksAsync(GetTasksArgs args = null, CancellationToken cancellationToken = default) =>
            _client.GetTasksAsync(args, cancellationToken);

        /// <inheritdoc/>
        public ValueTask<Models.Task> QuickAddTaskAsync(QuickAddTaskArgs args, CancellationToken cancellationToken = default) =>
            _client.QuickAddTaskAsync(args, cancellationToken);

        /// <inheritdoc/>
        public ValueTask<bool> ReopenTaskAsync(long id, string requestId = null, CancellationToken cancellationToken = default) =>
            _client.ReopenTaskAsync(id, requestId, cancellationToken);

        /// <inheritdoc/>
        public ValueTask<bool> UpdateCommentAsync(long id, UpdateCommentArgs args, string requestId = null, CancellationToken cancellationToken = default) =>
            _client.UpdateCommentAsync(id, args, requestId, cancellationToken);

        /// <inheritdoc/>
        public ValueTask<bool> UpdateLabelAsync(long id, UpdateLabelArgs args, string requestId = null, CancellationToken cancellationToken = default) =>
            _client.UpdateLabelAsync(id, args, requestId, cancellationToken);

        /// <inheritdoc/>
        public ValueTask<bool> UpdateProjectAsync(long id, UpdateProjectArgs args, string requestId = null, CancellationToken cancellationToken = default) =>
            _client.UpdateProjectAsync(id, args, requestId, cancellationToken);

        /// <inheritdoc/>
        public ValueTask<bool> UpdateSectionAsync(long id, UpdateSectionArgs args, string requestId = null, CancellationToken cancellationToken = default) =>
            _client.UpdateSectionAsync(id, args, requestId, cancellationToken);

        /// <inheritdoc/>
        public ValueTask<bool> UpdateTaskAsync(long id, UpdateTaskArgs args, string requestId = null, CancellationToken cancellationToken = default) =>
            _client.UpdateTaskAsync(id, args, requestId, cancellationToken);
    }
}
