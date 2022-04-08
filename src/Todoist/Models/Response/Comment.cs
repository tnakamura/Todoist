using System;
using System.Text.Json.Serialization;

namespace Todoist.Models
{
    /// <summary>
    /// Comment
    /// </summary>
    public partial class Comment : IEquatable<Comment>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Comment" /> class.
        /// </summary>
        /// <param name="id">id.</param>
        /// <param name="taskId">taskId.</param>
        /// <param name="projectId">projectId.</param>
        /// <param name="posted">posted.</param>
        /// <param name="content">content.</param>
        /// <param name="attachment">attachment.</param>
        public Comment(
            long id = default,
            long taskId = default,
            long projectId = default,
            DateTimeOffset posted = default,
            string content = default,
            Attachment attachment = default)
        {
            Id = id;
            TaskId = taskId;
            ProjectId = projectId;
            Posted = posted;
            Content = content;
            Attachment = attachment;
        }

        /// <summary>
        /// Gets Id
        /// </summary>
        [JsonPropertyName("id")]
        public long Id { get; private set; }

        /// <summary>
        /// Gets TaskId
        /// </summary>
        [JsonPropertyName("task_id")]
        public long TaskId { get; private set; }

        /// <summary>
        /// Gets ProjectId
        /// </summary>
        [JsonPropertyName("project_id")]
        public long ProjectId { get; private set; }

        /// <summary>
        /// Gets Posted
        /// </summary>
        [JsonPropertyName("posted")]
        public DateTimeOffset Posted { get; private set; }

        /// <summary>
        /// Gets Content
        /// </summary>
        [JsonPropertyName("content")]
        public string Content { get; private set; }

        /// <summary>
        /// Gets Attachment
        /// </summary>
        [JsonPropertyName("attachment")]
        public Attachment Attachment { get; private set; }

        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            return Equals(input as Comment);
        }

        /// <summary>
        /// Returns true if Comment instances are equal
        /// </summary>
        /// <param name="input">Instance of Comment to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(Comment input)
        {
            if (input == null)
            {
                return false;
            }
            return
                (
                    this.Id == input.Id ||
                    this.Id.Equals(input.Id)
                ) &&
                (
                    this.TaskId == input.TaskId ||
                    this.TaskId.Equals(input.TaskId)
                ) &&
                (
                    this.ProjectId == input.ProjectId ||
                    this.ProjectId.Equals(input.ProjectId)
                ) &&
                (
                    this.Posted == input.Posted ||
                    (this.Posted != null &&
                    this.Posted.Equals(input.Posted))
                ) &&
                (
                    this.Content == input.Content ||
                    (this.Content != null &&
                    this.Content.Equals(input.Content))
                ) &&
                (
                    this.Attachment == input.Attachment ||
                    (this.Attachment != null &&
                    this.Attachment.Equals(input.Attachment))
                );
        }

        /// <summary>
        /// Gets the hash code
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode()
        {
            unchecked // Overflow is fine, just wrap
            {
                int hashCode = 41;
                hashCode = (hashCode * 59) + this.Id.GetHashCode();
                hashCode = (hashCode * 59) + this.TaskId.GetHashCode();
                hashCode = (hashCode * 59) + this.ProjectId.GetHashCode();
                if (this.Posted != null)
                {
                    hashCode = (hashCode * 59) + this.Posted.GetHashCode();
                }
                if (this.Content != null)
                {
                    hashCode = (hashCode * 59) + this.Content.GetHashCode();
                }
                if (this.Attachment != null)
                {
                    hashCode = (hashCode * 59) + this.Attachment.GetHashCode();
                }
                return hashCode;
            }
        }
    }

}
