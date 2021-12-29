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
    /// Task
    /// </summary>
    [DataContract(Name = "Task")]
    public partial class Task : IEquatable<Task>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Task" /> class.
        /// </summary>
        /// <param name="id">id.</param>
        /// <param name="projectId">projectId.</param>
        /// <param name="sectionId">sectionId.</param>
        /// <param name="content">content.</param>
        /// <param name="description">description.</param>
        /// <param name="completed">completed.</param>
        /// <param name="labelIds">labelIds.</param>
        /// <param name="parentId">parentId.</param>
        /// <param name="order">order.</param>
        /// <param name="priority">priority.</param>
        /// <param name="due">due.</param>
        /// <param name="url">url.</param>
        /// <param name="commentCount">commentCount.</param>
        /// <param name="assignee">assignee.</param>
        /// <param name="assigner">assigner.</param>
        public Task(long id = default(long), long projectId = default(long), int sectionId = default(int), string content = default(string), string description = default(string), bool completed = default(bool), List<long> labelIds = default(List<long>), long parentId = default(long), int order = default(int), int priority = default(int), Due due = default(Due), string url = default(string), int commentCount = default(int), int assignee = default(int), int assigner = default(int))
        {
            this.Id = id;
            this.ProjectId = projectId;
            this.SectionId = sectionId;
            this.Content = content;
            this.Description = description;
            this.Completed = completed;
            this.LabelIds = labelIds;
            this.ParentId = parentId;
            this.Order = order;
            this.Priority = priority;
            this.Due = due;
            this.Url = url;
            this.CommentCount = commentCount;
            this.Assignee = assignee;
            this.Assigner = assigner;
        }

        /// <summary>
        /// Gets or Sets Id
        /// </summary>
        [DataMember(Name = "id", EmitDefaultValue = false)]
        public long Id { get; set; }

        /// <summary>
        /// Gets or Sets ProjectId
        /// </summary>
        [DataMember(Name = "project_id", EmitDefaultValue = false)]
        public long ProjectId { get; set; }

        /// <summary>
        /// Gets or Sets SectionId
        /// </summary>
        [DataMember(Name = "section_id", EmitDefaultValue = false)]
        public int SectionId { get; set; }

        /// <summary>
        /// Gets or Sets Content
        /// </summary>
        [DataMember(Name = "content", EmitDefaultValue = false)]
        public string Content { get; set; }

        /// <summary>
        /// Gets or Sets Description
        /// </summary>
        [DataMember(Name = "description", EmitDefaultValue = false)]
        public string Description { get; set; }

        /// <summary>
        /// Gets or Sets Completed
        /// </summary>
        [DataMember(Name = "completed", EmitDefaultValue = true)]
        public bool Completed { get; set; }

        /// <summary>
        /// Gets or Sets LabelIds
        /// </summary>
        [DataMember(Name = "label_ids", EmitDefaultValue = false)]
        public List<long> LabelIds { get; set; }

        /// <summary>
        /// Gets or Sets ParentId
        /// </summary>
        [DataMember(Name = "parent_id", EmitDefaultValue = false)]
        public long ParentId { get; set; }

        /// <summary>
        /// Gets or Sets Order
        /// </summary>
        [DataMember(Name = "order", EmitDefaultValue = false)]
        public int Order { get; set; }

        /// <summary>
        /// Gets or Sets Priority
        /// </summary>
        [DataMember(Name = "priority", EmitDefaultValue = false)]
        public int Priority { get; set; }

        /// <summary>
        /// Gets or Sets Due
        /// </summary>
        [DataMember(Name = "due", EmitDefaultValue = false)]
        public Due Due { get; set; }

        /// <summary>
        /// Gets or Sets Url
        /// </summary>
        [DataMember(Name = "url", EmitDefaultValue = false)]
        public string Url { get; set; }

        /// <summary>
        /// Gets or Sets CommentCount
        /// </summary>
        [DataMember(Name = "comment_count", EmitDefaultValue = false)]
        public int CommentCount { get; set; }

        /// <summary>
        /// Gets or Sets Assignee
        /// </summary>
        [DataMember(Name = "assignee", EmitDefaultValue = false)]
        public int Assignee { get; set; }

        /// <summary>
        /// Gets or Sets Assigner
        /// </summary>
        [DataMember(Name = "assigner", EmitDefaultValue = false)]
        public int Assigner { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class Task {\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  ProjectId: ").Append(ProjectId).Append("\n");
            sb.Append("  SectionId: ").Append(SectionId).Append("\n");
            sb.Append("  Content: ").Append(Content).Append("\n");
            sb.Append("  Description: ").Append(Description).Append("\n");
            sb.Append("  Completed: ").Append(Completed).Append("\n");
            sb.Append("  LabelIds: ").Append(LabelIds).Append("\n");
            sb.Append("  ParentId: ").Append(ParentId).Append("\n");
            sb.Append("  Order: ").Append(Order).Append("\n");
            sb.Append("  Priority: ").Append(Priority).Append("\n");
            sb.Append("  Due: ").Append(Due).Append("\n");
            sb.Append("  Url: ").Append(Url).Append("\n");
            sb.Append("  CommentCount: ").Append(CommentCount).Append("\n");
            sb.Append("  Assignee: ").Append(Assignee).Append("\n");
            sb.Append("  Assigner: ").Append(Assigner).Append("\n");
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
            return this.Equals(input as Task);
        }

        /// <summary>
        /// Returns true if Task instances are equal
        /// </summary>
        /// <param name="input">Instance of Task to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(Task input)
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
                    this.ProjectId == input.ProjectId ||
                    this.ProjectId.Equals(input.ProjectId)
                ) && 
                (
                    this.SectionId == input.SectionId ||
                    this.SectionId.Equals(input.SectionId)
                ) && 
                (
                    this.Content == input.Content ||
                    (this.Content != null &&
                    this.Content.Equals(input.Content))
                ) && 
                (
                    this.Description == input.Description ||
                    (this.Description != null &&
                    this.Description.Equals(input.Description))
                ) && 
                (
                    this.Completed == input.Completed ||
                    this.Completed.Equals(input.Completed)
                ) && 
                (
                    this.LabelIds == input.LabelIds ||
                    this.LabelIds != null &&
                    input.LabelIds != null &&
                    this.LabelIds.SequenceEqual(input.LabelIds)
                ) && 
                (
                    this.ParentId == input.ParentId ||
                    this.ParentId.Equals(input.ParentId)
                ) && 
                (
                    this.Order == input.Order ||
                    this.Order.Equals(input.Order)
                ) && 
                (
                    this.Priority == input.Priority ||
                    this.Priority.Equals(input.Priority)
                ) && 
                (
                    this.Due == input.Due ||
                    (this.Due != null &&
                    this.Due.Equals(input.Due))
                ) && 
                (
                    this.Url == input.Url ||
                    (this.Url != null &&
                    this.Url.Equals(input.Url))
                ) && 
                (
                    this.CommentCount == input.CommentCount ||
                    this.CommentCount.Equals(input.CommentCount)
                ) && 
                (
                    this.Assignee == input.Assignee ||
                    this.Assignee.Equals(input.Assignee)
                ) && 
                (
                    this.Assigner == input.Assigner ||
                    this.Assigner.Equals(input.Assigner)
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
                hashCode = (hashCode * 59) + this.ProjectId.GetHashCode();
                hashCode = (hashCode * 59) + this.SectionId.GetHashCode();
                if (this.Content != null)
                {
                    hashCode = (hashCode * 59) + this.Content.GetHashCode();
                }
                if (this.Description != null)
                {
                    hashCode = (hashCode * 59) + this.Description.GetHashCode();
                }
                hashCode = (hashCode * 59) + this.Completed.GetHashCode();
                if (this.LabelIds != null)
                {
                    hashCode = (hashCode * 59) + this.LabelIds.GetHashCode();
                }
                hashCode = (hashCode * 59) + this.ParentId.GetHashCode();
                hashCode = (hashCode * 59) + this.Order.GetHashCode();
                hashCode = (hashCode * 59) + this.Priority.GetHashCode();
                if (this.Due != null)
                {
                    hashCode = (hashCode * 59) + this.Due.GetHashCode();
                }
                if (this.Url != null)
                {
                    hashCode = (hashCode * 59) + this.Url.GetHashCode();
                }
                hashCode = (hashCode * 59) + this.CommentCount.GetHashCode();
                hashCode = (hashCode * 59) + this.Assignee.GetHashCode();
                hashCode = (hashCode * 59) + this.Assigner.GetHashCode();
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
