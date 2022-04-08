using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Todoist.Models
{
    /// <summary>
    /// NewTask
    /// </summary>
    public class AddTaskArgs
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AddTaskArgs" /> class.
        /// </summary>
        /// <param name="content">content (required).</param>
        /// <param name="description">description.</param>
        /// <param name="projectId">projectId.</param>
        /// <param name="sectionId">sectionId.</param>
        /// <param name="parentId">parentId.</param>
        /// <param name="order">order.</param>
        /// <param name="labelIds">labelIds.</param>
        /// <param name="priority">priority.</param>
        /// <param name="dueString">dueString.</param>
        /// <param name="dueDate">dueDate.</param>
        /// <param name="dueDatetime">dueDatetime.</param>
        /// <param name="dueLang">dueLang.</param>
        /// <param name="assignee">assignee.</param>
        public AddTaskArgs(
            string content = default,
            string description = default,
            long? projectId = default,
            long? sectionId = default,
            long? parentId = default,
            int? order = default,
            IList<long> labelIds = default,
            int? priority = default,
            string dueString = default,
            DateTimeOffset? dueDate = default,
            DateTimeOffset? dueDatetime = default,
            string dueLang = default,
            long? assignee = default)
        {
            Content = content ?? throw new ArgumentNullException(nameof(content));
            Description = description;
            ProjectId = projectId;
            SectionId = sectionId;
            ParentId = parentId;
            Order = order;
            LabelIds = labelIds;
            Priority = priority;
            DueString = dueString;
            DueDate = dueDate;
            DueDatetime = dueDatetime;
            DueLang = dueLang;
            Assignee = assignee;
        }

        /// <summary>
        /// Gets or Sets Content
        /// </summary>
        [JsonPropertyName("content")]
        public string Content { get; set; }

        /// <summary>
        /// Gets or Sets Description
        /// </summary>
        [JsonPropertyName("description")]
        public string Description { get; set; }

        /// <summary>
        /// Gets or Sets ProjectId
        /// </summary>
        [JsonPropertyName("project_id")]
        public long? ProjectId { get; set; }

        /// <summary>
        /// Gets or Sets SectionId
        /// </summary>
        [JsonPropertyName("section_id")]
        public long? SectionId { get; set; }

        /// <summary>
        /// Gets or Sets ParentId
        /// </summary>
        [JsonPropertyName("parent_id")]
        public long? ParentId { get; set; }

        /// <summary>
        /// Gets or Sets Order
        /// </summary>
        [JsonPropertyName("order")]
        public int? Order { get; set; }

        /// <summary>
        /// Gets or Sets LabelIds
        /// </summary>
        [JsonPropertyName("label_ids")]
        public IList<long> LabelIds { get; set; }

        /// <summary>
        /// Gets or Sets Priority
        /// </summary>
        [JsonPropertyName("priority")]
        public int? Priority { get; set; }

        /// <summary>
        /// Gets or Sets DueString
        /// </summary>
        [JsonPropertyName("due_string")]
        public string DueString { get; set; }

        /// <summary>
        /// Gets or Sets DueDate
        /// </summary>
        [JsonPropertyName("due_date")]
        public DateTimeOffset? DueDate { get; set; }

        /// <summary>
        /// Gets or Sets DueDatetime
        /// </summary>
        [JsonPropertyName("due_datetime")]
        public DateTimeOffset? DueDatetime { get; set; }

        /// <summary>
        /// Gets or Sets DueLang
        /// </summary>
        [JsonPropertyName("due_lang")]
        public string DueLang { get; set; }

        /// <summary>
        /// Gets or Sets Assignee
        /// </summary>
        [JsonPropertyName("assignee")]
        public long? Assignee { get; set; }
    }
}
