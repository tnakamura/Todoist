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

namespace Todoist.Model
{
    /// <summary>
    /// TaskUpdate
    /// </summary>
    [DataContract(Name = "TaskUpdate")]
    public partial class TaskUpdate : IEquatable<TaskUpdate>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TaskUpdate" /> class.
        /// </summary>
        /// <param name="content">content.</param>
        /// <param name="description">description.</param>
        /// <param name="labelIds">labelIds.</param>
        /// <param name="priority">priority.</param>
        /// <param name="dueString">dueString.</param>
        /// <param name="dueDate">dueDate.</param>
        /// <param name="dueDatetime">dueDatetime.</param>
        /// <param name="dueLang">dueLang.</param>
        /// <param name="assignee">assignee.</param>
        public TaskUpdate(string content = default(string), string description = default(string), List<long> labelIds = default(List<long>), int priority = default(int), string dueString = default(string), DateTimeOffset dueDate = default(DateTimeOffset), DateTimeOffset dueDatetime = default(DateTimeOffset), string dueLang = default(string), long assignee = default(long))
        {
            this.Content = content;
            this.Description = description;
            this.LabelIds = labelIds;
            this.Priority = priority;
            this.DueString = dueString;
            this.DueDate = dueDate;
            this.DueDatetime = dueDatetime;
            this.DueLang = dueLang;
            this.Assignee = assignee;
        }

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
        /// Gets or Sets LabelIds
        /// </summary>
        [DataMember(Name = "label_ids", EmitDefaultValue = false)]
        public List<long> LabelIds { get; set; }

        /// <summary>
        /// Gets or Sets Priority
        /// </summary>
        [DataMember(Name = "priority", EmitDefaultValue = false)]
        public int Priority { get; set; }

        /// <summary>
        /// Gets or Sets DueString
        /// </summary>
        [DataMember(Name = "due_string", EmitDefaultValue = false)]
        public string DueString { get; set; }

        /// <summary>
        /// Gets or Sets DueDate
        /// </summary>
        [DataMember(Name = "due_date", EmitDefaultValue = false)]
        [JsonConverter(typeof(OpenAPIDateConverter))]
        public DateTimeOffset DueDate { get; set; }

        /// <summary>
        /// Gets or Sets DueDatetime
        /// </summary>
        [DataMember(Name = "due_datetime", EmitDefaultValue = false)]
        public DateTimeOffset DueDatetime { get; set; }

        /// <summary>
        /// Gets or Sets DueLang
        /// </summary>
        [DataMember(Name = "due_lang", EmitDefaultValue = false)]
        public string DueLang { get; set; }

        /// <summary>
        /// Gets or Sets Assignee
        /// </summary>
        [DataMember(Name = "assignee", EmitDefaultValue = false)]
        public long Assignee { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class TaskUpdate {\n");
            sb.Append("  Content: ").Append(Content).Append("\n");
            sb.Append("  Description: ").Append(Description).Append("\n");
            sb.Append("  LabelIds: ").Append(LabelIds).Append("\n");
            sb.Append("  Priority: ").Append(Priority).Append("\n");
            sb.Append("  DueString: ").Append(DueString).Append("\n");
            sb.Append("  DueDate: ").Append(DueDate).Append("\n");
            sb.Append("  DueDatetime: ").Append(DueDatetime).Append("\n");
            sb.Append("  DueLang: ").Append(DueLang).Append("\n");
            sb.Append("  Assignee: ").Append(Assignee).Append("\n");
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
            return this.Equals(input as TaskUpdate);
        }

        /// <summary>
        /// Returns true if TaskUpdate instances are equal
        /// </summary>
        /// <param name="input">Instance of TaskUpdate to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(TaskUpdate input)
        {
            if (input == null)
            {
                return false;
            }
            return 
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
                    this.LabelIds == input.LabelIds ||
                    this.LabelIds != null &&
                    input.LabelIds != null &&
                    this.LabelIds.SequenceEqual(input.LabelIds)
                ) && 
                (
                    this.Priority == input.Priority ||
                    this.Priority.Equals(input.Priority)
                ) && 
                (
                    this.DueString == input.DueString ||
                    (this.DueString != null &&
                    this.DueString.Equals(input.DueString))
                ) && 
                (
                    this.DueDate == input.DueDate ||
                    (this.DueDate != null &&
                    this.DueDate.Equals(input.DueDate))
                ) && 
                (
                    this.DueDatetime == input.DueDatetime ||
                    (this.DueDatetime != null &&
                    this.DueDatetime.Equals(input.DueDatetime))
                ) && 
                (
                    this.DueLang == input.DueLang ||
                    (this.DueLang != null &&
                    this.DueLang.Equals(input.DueLang))
                ) && 
                (
                    this.Assignee == input.Assignee ||
                    this.Assignee.Equals(input.Assignee)
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
                if (this.Content != null)
                {
                    hashCode = (hashCode * 59) + this.Content.GetHashCode();
                }
                if (this.Description != null)
                {
                    hashCode = (hashCode * 59) + this.Description.GetHashCode();
                }
                if (this.LabelIds != null)
                {
                    hashCode = (hashCode * 59) + this.LabelIds.GetHashCode();
                }
                hashCode = (hashCode * 59) + this.Priority.GetHashCode();
                if (this.DueString != null)
                {
                    hashCode = (hashCode * 59) + this.DueString.GetHashCode();
                }
                if (this.DueDate != null)
                {
                    hashCode = (hashCode * 59) + this.DueDate.GetHashCode();
                }
                if (this.DueDatetime != null)
                {
                    hashCode = (hashCode * 59) + this.DueDatetime.GetHashCode();
                }
                if (this.DueLang != null)
                {
                    hashCode = (hashCode * 59) + this.DueLang.GetHashCode();
                }
                hashCode = (hashCode * 59) + this.Assignee.GetHashCode();
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
