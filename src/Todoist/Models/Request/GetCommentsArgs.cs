namespace Todoist.Models
{
    public abstract class GetCommentsArgs
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetCommentsArgs" /> class.
        /// </summary>
        private protected GetCommentsArgs() { }

        /// <summary>
        /// Gets ProjectId
        /// </summary>
        public long? ProjectId { get; private protected set; }

        /// <summary>
        /// Gets TaskId
        /// </summary>
        public long? TaskId { get; private protected set; }
    }

    public sealed class GetProjectCommentsArgs : GetCommentsArgs
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetProjectCommentsArgs" /> class.
        /// </summary>
        public GetProjectCommentsArgs(long projectId)
            : base()
        {
            ProjectId = projectId;
        }
    }

    public sealed class GetTaskCommentsArgs : GetCommentsArgs
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetTaskCommentsArgs" /> class.
        /// </summary>
        public GetTaskCommentsArgs(long taskId)
            : base()
        {
            TaskId = taskId;
        }
    }

}
