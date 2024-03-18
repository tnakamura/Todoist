using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Todoist.Models;

namespace Todoist.Clients
{
    /// <summary>
    /// Projects
    /// </summary>
    public interface IProjectsClient
    {
        /// <summary>
        /// Get a project
        /// </summary>
        ValueTask<Project> GetAsync(long id, CancellationToken cancellationToken = default);
        /// <summary>
        /// Get all projects
        /// </summary>
        ValueTask<IReadOnlyList<Project>> GetAllAsync(CancellationToken cancellationToken = default);
        /// <summary>
        /// Create a new project
        /// </summary>
        ValueTask<Project> CreateAsync(CreateProjectArgs args, string requestId = null, CancellationToken cancellationToken = default);
        /// <summary>
        /// Update a project
        /// </summary>
        ValueTask<bool> UpdateAsync(long id, UpdateProjectArgs args, string requestId = null, CancellationToken cancellationToken = default);
        /// <summary>
        /// Delete a project
        /// </summary>
        ValueTask<bool> DeleteAsync(long id, string requestId = null, CancellationToken cancellationToken = default);

        /// <summary>
        /// Collaborators
        /// </summary>
        ICollaboratorsClient Collaborators { get; }
    }
}
