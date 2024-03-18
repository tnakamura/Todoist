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
    ValueTask<TodoistTask> GetAsync(long id, CancellationToken cancellationToken = default);
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
    ValueTask<bool> UpdateAsync(long id, UpdateTaskArgs args, string? requestId = null, CancellationToken cancellationToken = default);
    /// <summary>
    /// Close a task
    /// </summary>
    ValueTask<bool> CloseAsync(long id, string? requestId = null, CancellationToken cancellationToken = default);
    /// <summary>
    /// Reopen a task
    /// </summary>
    ValueTask<bool> ReopenAsync(long id, string? requestId = null, CancellationToken cancellationToken = default);
    /// <summary>
    /// Delete a task
    /// </summary>
    ValueTask<bool> DeleteAsync(long id, string? requestId = null, CancellationToken cancellationToken = default);
}
