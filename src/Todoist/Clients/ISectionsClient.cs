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
    /// <param name="projectId">
    /// Filter sections by project ID.
    /// </param>
    /// <param name="cancellationToken"></param>
    ValueTask<IReadOnlyList<Section>> GetAllAsync(string? projectId = null, CancellationToken cancellationToken = default);
    /// <summary>
    /// Get a single section
    /// </summary>
    ValueTask<Section> GetAsync(string id, CancellationToken cancellationToken = default);
    /// <summary>
    /// Create a new section
    /// </summary>
    ValueTask<Section> CreateAsync(CreateSectionArgs args, string? requestId = null, CancellationToken cancellationToken = default);
    /// <summary>
    /// Update a section
    /// </summary>
    ValueTask<Section> UpdateAsync(string id, UpdateSectionArgs args, string? requestId = null, CancellationToken cancellationToken = default);
    /// <summary>
    /// Delete a section
    /// </summary>
    ValueTask<bool> DeleteAsync(string id, string? requestId = null, CancellationToken cancellationToken = default);
}
