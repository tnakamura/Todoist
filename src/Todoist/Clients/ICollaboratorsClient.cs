using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Todoist.Models;

namespace Todoist.Clients;

/// <summary>
/// Collaborators
/// </summary>
public interface ICollaboratorsClient
{
    /// <summary>
    /// Get all collaborators
    /// </summary>
    ValueTask<IReadOnlyList<User>> GetAllAsync(string projectId, CancellationToken cancellationToken = default);
    /// <summary>
    /// Get collaborators page with next cursor.
    /// </summary>
    ValueTask<PagedResult<User>> GetPageAsync(string projectId, string? cursor = null, CancellationToken cancellationToken = default);
}
