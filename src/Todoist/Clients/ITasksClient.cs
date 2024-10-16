using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Todoist.Models;
using TodoistTask = Todoist.Models.Task;

namespace Todoist.Clients;

/// <summary>
/// Tasks
/// </summary>
public interface ITasksClient
{
    /// <summary>
    /// Get an active task
    /// </summary>
    ValueTask<TodoistTask> GetAsync(string id, CancellationToken cancellationToken = default);
    /// <summary>
    /// Get active tasks
    /// </summary>
    ValueTask<IReadOnlyList<TodoistTask>> GetAllAsync(GetTasksArgs? args = null, CancellationToken cancellationToken = default);
    /// <summary>
    /// Create a new task
    /// </summary>
    ValueTask<TodoistTask> CreateAsync(CreateTaskArgs args, string? requestId = null, CancellationToken cancellationToken = default);
    /// <summary>
    /// Update a task
    /// </summary>
    ValueTask<TodoistTask> UpdateAsync(string id, UpdateTaskArgs args, string? requestId = null, CancellationToken cancellationToken = default);
    /// <summary>
    /// Close a task
    /// </summary>
    ValueTask<bool> CloseAsync(string id, string? requestId = null, CancellationToken cancellationToken = default);
    /// <summary>
    /// Reopen a task
    /// </summary>
    ValueTask<bool> ReopenAsync(string id, string? requestId = null, CancellationToken cancellationToken = default);
    /// <summary>
    /// Delete a task
    /// </summary>
    ValueTask<bool> DeleteAsync(string id, string? requestId = null, CancellationToken cancellationToken = default);
}
