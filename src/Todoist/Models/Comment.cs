using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.IO;
using System.Runtime.Serialization;
using System.Text;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using System.ComponentModel.DataAnnotations;
using FileParameter = Todoist.Client.FileParameter;
using OpenAPIDateConverter = Todoist.Client.OpenAPIDateConverter;

namespace Todoist.Models
{
    /// <summary>
    /// Comment
    /// </summary>
    [DataContract(Name = "Comment")]
    public partial class Comment : IEquatable<Comment>, IValidatableObject
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
        public Comment(long id = default(long), long taskId = default(long), long projectId = default(long), DateTimeOffset posted = default(DateTimeOffset), string content = default(string), Attachment attachment = default(Attachment))
        {
            this.Id = id;
            this.TaskId = taskId;
            this.ProjectId = projectId;
            this.Posted = posted;
            this.Content = content;
            this.Attachment = attachment;
        }

        /// <summary>
        /// Gets or Sets Id
        /// </summary>
        [DataMember(Name = "id", EmitDefaultValue = false)]
        public long Id { get; set; }

        /// <summary>
        /// Gets or Sets TaskId
        /// </summary>
        [DataMember(Name = "task_id", EmitDefaultValue = false)]
        public long TaskId { get; set; }

        /// <summary>
        /// Gets or Sets ProjectId
        /// </summary>
        [DataMember(Name = "project_id", EmitDefaultValue = false)]
        public long ProjectId { get; set; }

        /// <summary>
        /// Gets or Sets Posted
        /// </summary>
        [DataMember(Name = "posted", EmitDefaultValue = false)]
        public DateTimeOffset Posted { get; set; }

        /// <summary>
        /// Gets or Sets Content
        /// </summary>
        [DataMember(Name = "content", EmitDefaultValue = false)]
        public string Content { get; set; }

        /// <summary>
        /// Gets or Sets Attachment
        /// </summary>
        [DataMember(Name = "attachment", EmitDefaultValue = false)]
        public Attachment Attachment { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class Comment {\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  TaskId: ").Append(TaskId).Append("\n");
            sb.Append("  ProjectId: ").Append(ProjectId).Append("\n");
            sb.Append("  Posted: ").Append(Posted).Append("\n");
            sb.Append("  Content: ").Append(Content).Append("\n");
            sb.Append("  Attachment: ").Append(Attachment).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }

        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public virtual string ToJson()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this, Newtonsoft.Json.Formatting.Indented);
        }

        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            return this.Equals(input as Comment);
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

        /// <summary>
        /// To validate all properties of the instance
        /// </summary>
        /// <param name="validationContext">Validation context</param>
        /// <returns>Validation Result</returns>
        public IEnumerable<System.ComponentModel.DataAnnotations.ValidationResult> Validate(ValidationContext validationContext)
        {
            yield break;
        }
    }

}
