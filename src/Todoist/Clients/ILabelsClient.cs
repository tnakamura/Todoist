using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Todoist.Models;

namespace Todoist.Clients;

/// <summary>
/// Labels
/// </summary>
public interface ILabelsClient
{
    /// <summary>
    /// Get a label
    /// </summary>
    ValueTask<Label> GetAsync(string id, CancellationToken cancellationToken = default);
    /// <summary>
    /// Get all labels
    /// </summary>
    ValueTask<IReadOnlyList<Label>> GetAllAsync(CancellationToken cancellationToken = default);
    /// <summary>
    /// Create a new label
    /// </summary>
    ValueTask<Label> CreateAsync(CreateLabelArgs args, string? requestId = null, CancellationToken cancellationToken = default);
    /// <summary>
    /// Update a label
    /// </summary>
    ValueTask<Label> UpdateAsync(string id, UpdateLabelArgs args, string? requestId = null, CancellationToken cancellationToken = default);
    /// <summary>
    /// Delete a label
    /// </summary>
    ValueTask<bool> DeleteAsync(string id, string? requestId = null, CancellationToken cancellationToken = default);
    /// <summary>
    /// Shared labels
    /// </summary>
    ISharedLabelsClient SharedLabels { get; }
}
