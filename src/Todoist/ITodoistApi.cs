using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Todoist.Models;
using TodoistTask = Todoist.Models.Task;

namespace Todoist
{
    /// <summary>
    /// Todoist REST API
    /// </summary>
    public interface ITodoistApi
    {
        /// <summary>
        /// Get an active task
        /// </summary>
        ValueTask<TodoistTask> GetTaskAsync(long id, CancellationToken cancellationToken = default);
        /// <summary>
        /// Get active tasks
        /// </summary>
        ValueTask<IReadOnlyList<TodoistTask>> GetTasksAsync(GetTasksArgs args = null, CancellationToken cancellationToken = default);
        /// <summary>
        /// Create a new task
        /// </summary>
        ValueTask<TodoistTask> AddTaskAsync(AddTaskArgs args, string requestId = null, CancellationToken cancellationToken = default);
        /// <summary>
        /// Update a task
        /// </summary>
        ValueTask<bool> UpdateTaskAsync(long id, UpdateTaskArgs args, string requestId = null, CancellationToken cancellationToken = default);
        /// <summary>
        /// Close a task
        /// </summary>
        ValueTask<bool> CloseTaskAsync(long id, string requestId = null, CancellationToken cancellationToken = default);
        /// <summary>
        /// Reopen a task
        /// </summary>
        ValueTask<bool> ReopenTaskAsync(long id, string requestId = null, CancellationToken cancellationToken = default);
        /// <summary>
        /// Delete a task
        /// </summary>
        ValueTask<bool> DeleteTaskAsync(long id, string requestId = null, CancellationToken cancellationToken = default);

        /// <summary>
        /// Get a project
        /// </summary>
        ValueTask<Project> GetProjectAsync(long id, CancellationToken cancellationToken = default);
        /// <summary>
        /// Get all projects
        /// </summary>
        ValueTask<IReadOnlyList<Project>> GetProjectsAsync(CancellationToken cancellationToken = default);
        /// <summary>
        /// Create a new project
        /// </summary>
        ValueTask<Project> AddProjectAsync(AddProjectArgs args, string requestId = null, CancellationToken cancellationToken = default);
        /// <summary>
        /// Update a project
        /// </summary>
        ValueTask<bool> UpdateProjectAsync(long id, UpdateProjectArgs args, string requestId = null, CancellationToken cancellationToken = default);
        /// <summary>
        /// Delete a project
        /// </summary>
        ValueTask<bool> DeleteProjectAsync(long id, string requestId = null, CancellationToken cancellationToken = default);

        /// <summary>
        /// Get all collaborators
        /// </summary>
        ValueTask<IReadOnlyList<User>> GetProjectCollaboratorsAsync(long projectId, CancellationToken cancellationToken = default);
        /// <summary>
        /// Get all sections
        /// </summary>
        ValueTask<IReadOnlyList<Section>> GetSectionsAsync(long? projectId = null, CancellationToken cancellationToken = default);
        /// <summary>
        /// Get a single section
        /// </summary>
        ValueTask<Section> GetSectionAsync(long id, CancellationToken cancellationToken = default);
        /// <summary>
        /// Create a new section
        /// </summary>
        ValueTask<Section> AddSectionAsync(AddSectionArgs args, string requestId = null, CancellationToken cancellationToken = default);
        /// <summary>
        /// Update a section
        /// </summary>
        ValueTask<bool> UpdateSectionAsync(long id, UpdateSectionArgs args, string requestId = null, CancellationToken cancellationToken = default);
        /// <summary>
        /// Delete a section
        /// </summary>
        ValueTask<bool> DeleteSectionAsync(long id, string requestId = null, CancellationToken cancellationToken = default);

        /// <summary>
        /// Get a label
        /// </summary>
        ValueTask<Label> GetLabelAsync(long id, CancellationToken cancellationToken = default);
        /// <summary>
        /// Get all labels
        /// </summary>
        ValueTask<IReadOnlyList<Label>> GetLabelsAsync(CancellationToken cancellationToken = default);
        /// <summary>
        /// Create a new label
        /// </summary>
        ValueTask<Label> AddLabelAsync(AddLabelArgs args, string requestId = null, CancellationToken cancellationToken = default);
        /// <summary>
        /// Update a label
        /// </summary>
        ValueTask<bool> UpdateLabelAsync(long id, UpdateLabelArgs args, string requestId = null, CancellationToken cancellationToken = default);
        /// <summary>
        /// Delete a label
        /// </summary>
        ValueTask<bool> DeleteLabelAsync(long id, string requestId = null, CancellationToken cancellationToken = default);
        /// <summary>
        /// Get all comments
        /// </summary>
        ValueTask<IReadOnlyList<Comment>> GetCommentsAsync(GetCommentsArgs args, CancellationToken cancellationToken = default);
        /// <summary>
        /// Get a comment
        /// </summary>
        ValueTask<Comment> GetCommentAsync(long id, CancellationToken cancellationToken = default);
        /// <summary>
        /// Create a new comment
        /// </summary>
        ValueTask<Comment> AddCommentAsync(AddCommentArgs args, string requestId = null, CancellationToken cancellationToken = default);
        /// <summary>
        /// Update a comment
        /// </summary>
        ValueTask<bool> UpdateCommentAsync(long id, UpdateCommentArgs args, string requestId = null, CancellationToken cancellationToken = default);
        /// <summary>
        /// Delete a comment
        /// </summary>
        ValueTask<bool> DeleteCommentAsync(long id, string requestId = null, CancellationToken cancellationToken = default);
    }
}
