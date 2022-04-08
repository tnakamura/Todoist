using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Todoist.Models
{
    public sealed class QuickAddTaskResponse
    {
        /// <summary>
        /// Gets Id
        /// </summary>
        [JsonPropertyName("id")]
        public long Id { get; private set; }

        /// <summary>
        /// Gets ProjectId
        /// </summary>
        [JsonPropertyName("project_id")]
        public long ProjectId { get; private set; }

        /// <summary>
        /// Gets Content
        /// </summary>
        [JsonPropertyName("content")]
        public string Content { get; private set; }

        /// <summary>
        /// Gets Description
        /// </summary>
        [JsonPropertyName("description")]
        public string Description { get; private set; }

        /// <summary>
        /// Gets SectionId
        /// </summary>
        [JsonPropertyName("section_id")]
        public int? SectionId { get; private set; }

        /// <summary>
        /// Gets ChildOrder
        /// </summary>
        [JsonPropertyName("child_order")]
        public int ChildOrder { get; private set; }

        /// <summary>
        /// Gets Labels
        /// </summary>
        [JsonPropertyName("labels")]
        public IReadOnlyList<int> Labels { get; private set; }

        /// <summary>
        /// Gets ResponsibleUid
        /// </summary>
        [JsonPropertyName("responsible_uid")]
        public long ResponsibleUid { get; private set; }

        /// <summary>
        /// Gets Checked
        /// </summary>
        [JsonPropertyName("checked")]
        public int Checked { get; private set; }

        /// <summary>
        /// Gets DateAdded
        /// </summary>
        [JsonPropertyName("date_added")]
        public DateTimeOffset DateAdded { get; private set; }

        /// <summary>
        /// Gets SyncId
        /// </summary>
        [JsonPropertyName("sync_id")]
        public long? SyncId { get; private set; }

        /// <summary>
        /// Gets Due
        /// </summary>
        [JsonPropertyName("due")]
        public DueDate Due { get; private set; }

        /// <summary>
        /// Due
        /// </summary>
        public sealed class DueDate
        {
            /// <summary>
            /// Gets Date
            /// </summary>
            [JsonPropertyName("date")]
            public DateTimeOffset Date { get; private set; }

            /// <summary>
            /// Gets Timezone
            /// </summary>
            [JsonPropertyName("timezone")]
            public string Timezone { get; private set; }

            /// <summary>
            /// Gets IsRecurring
            /// </summary>
            [JsonPropertyName("is_recurring")]
            public bool Recurring { get; private set; }

            /// <summary>
            /// Gets String
            /// </summary>
            [JsonPropertyName("string")]
            public string String { get; private set; }

            /// <summary>
            /// Gets Lang
            /// </summary>
            [JsonPropertyName("lang")]
            public string Lang { get; private set; }
        }
    }
}
