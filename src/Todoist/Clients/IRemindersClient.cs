using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Todoist.Models;

namespace Todoist.Clients;

/// <summary>
/// Reminders
/// </summary>
public interface IRemindersClient
{
    /// <summary>
    /// Get reminders page with next cursor.
    /// </summary>
    ValueTask<PagedResult<Reminder>> GetPageAsync(string? cursor = null, CancellationToken cancellationToken = default);

    /// <summary>
    /// Get all reminders.
    /// </summary>
    ValueTask<IReadOnlyList<Reminder>> GetAllAsync(CancellationToken cancellationToken = default);
}
