using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Todoist.Models;

namespace Todoist.Clients;

/// <summary>
/// Sections
/// </summary>
public interface ISectionsClient
{
    /// <summary>
    /// Get all sections
    /// </summary>
    ValueTask<IReadOnlyList<Section>> GetAllAsync(long? projectId = null, CancellationToken cancellationToken = default);
    /// <summary>
    /// Get a single section
    /// </summary>
    ValueTask<Section> GetAsync(long id, CancellationToken cancellationToken = default);
    /// <summary>
    /// Create a new section
    /// </summary>
    ValueTask<Section> CreateAsync(CreateSectionArgs args, string? requestId = null, CancellationToken cancellationToken = default);
    /// <summary>
    /// Update a section
    /// </summary>
    ValueTask<bool> UpdateAsync(long id, UpdateSectionArgs args, string? requestId = null, CancellationToken cancellationToken = default);
    /// <summary>
    /// Delete a section
    /// </summary>
    ValueTask<bool> DeleteAsync(long id, string? requestId = null, CancellationToken cancellationToken = default);
}
