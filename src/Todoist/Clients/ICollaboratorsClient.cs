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
    ValueTask<IReadOnlyList<User>> GetAllAsync(long projectId, CancellationToken cancellationToken = default);
}
