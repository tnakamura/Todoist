using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Todoist.Models;

namespace Todoist.Clients;

/// <summary>
/// Shared Labels
/// </summary>
public interface ISharedLabelsClient
{
    /// <summary>
    /// Get all shared labels.
    /// </summary>
    ValueTask<IReadOnlyList<string>> GetAllAsync(GetAllSharedLabelsArgs? args = null, CancellationToken cancellationToken = default);
    /// <summary>
    /// Rename shared labels.
    /// </summary>
    ValueTask<bool> RenameAsync(RenameSharedLabelsArgs args, CancellationToken cancellationToken = default);
    /// <summary>
    /// Remove shared labels.
    /// </summary>
    ValueTask<bool> RemoveAsync(RemoveSharedLabelsArgs args, CancellationToken cancellationToken = default);
}
