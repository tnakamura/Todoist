using Todoist.Clients;

namespace Todoist
{
    /// <summary>
    /// Todoist REST API
    /// </summary>
    public interface ITodoistClient
    {
        /// <summary>
        /// AuthToken
        /// </summary>
        IAuthTokenClient AuthToken { get; }

        /// <summary>
        /// Tasks
        /// </summary>
        ITasksClient Tasks { get; }

        /// <summary>
        /// Projects
        /// </summary>
        IProjectsClient Projects { get; }

        /// <summary>
        /// Sections
        /// </summary>
        ISectionsClient Sections { get; }

        /// <summary>
        /// Labels
        /// </summary>
        ILabelsClient Labels { get; }

        /// <summary>
        /// Comments
        /// </summary>
        ICommentsClient Comments { get; }
    }
}
