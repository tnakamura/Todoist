using System;
using System.Text.Json.Serialization;

namespace Todoist.Models
{
    /// <summary>
    /// NewComment
    /// </summary>
    public abstract class AddCommentArgs
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AddCommentArgs" /> class.
        /// </summary>
        /// <param name="taskId">taskId.</param>
        /// <param name="projectId">projectId.</param>
        /// <param name="content">content (required).</param>
        /// <param name="attachment">attachment.</param>
        private protected AddCommentArgs(
            string content,
            long? taskId = default,
            long? projectId = default,
            Attachment attachment = default)
        {
            Content = content ?? throw new ArgumentNullException(nameof(content));
            TaskId = taskId;
            ProjectId = projectId;
            Attachment = attachment;
        }

        /// <summary>
        /// Gets TaskId
        /// </summary>
        [JsonPropertyName("task_id")]
        public long? TaskId { get; private protected set; }

        /// <summary>
        /// Gets ProjectId
        /// </summary>
        [JsonPropertyName("project_id")]
        public long? ProjectId { get; private protected set; }

        /// <summary>
        /// Gets Content
        /// </summary>
        [JsonPropertyName("content")]
        public string Content { get; private set; }

        /// <summary>
        /// Gets or Sets Attachment
        /// </summary>
        [JsonPropertyName("attachment")]
        public Attachment Attachment { get; set; }
    }

    /// <summary>
    /// New Task Comment
    /// </summary>
    public sealed class AddTaskCommentArgs : AddCommentArgs
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AddTaskCommentArgs" /> class.
        /// </summary>
        /// <param name="taskId">taskId.</param>
        /// <param name="content">content (required).</param>
        /// <param name="attachment">attachment.</param>
        public AddTaskCommentArgs(
            long taskId,
            string content,
            Attachment attachment = default) :
            base(
                taskId: taskId,
                 content: content,
                 attachment: attachment)
        {
        }
    }

    /// <summary>
    /// New Project Comment
    /// </summary>
    public sealed class AddProjectCommentArgs : AddCommentArgs
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AddProjectCommentArgs" /> class.
        /// </summary>
        /// <param name="projectId">projectId.</param>
        /// <param name="content">content (required).</param>
        /// <param name="attachment">attachment.</param>
        public AddProjectCommentArgs(
            long projectId,
            string content,
            Attachment attachment = default) :
            base(
                projectId: projectId,
                content: content,
                attachment: attachment)
        {
        }
    }
}
