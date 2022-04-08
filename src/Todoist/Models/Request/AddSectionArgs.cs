using System;
using System.Text.Json.Serialization;

namespace Todoist.Models
{
    /// <summary>
    /// NewSection
    /// </summary>
    public class AddSectionArgs
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AddSectionArgs" /> class.
        /// </summary>
        /// <param name="name">name (required).</param>
        /// <param name="projectId">projectId (required).</param>
        /// <param name="order">order.</param>
        public AddSectionArgs(string name, long projectId, int? order = default)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            ProjectId = projectId;
            Order = order;
        }

        /// <summary>
        /// Gets or Sets Name
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; private set; }

        /// <summary>
        /// Gets or Sets ProjectId
        /// </summary>
        [JsonPropertyName("project_id")]
        public long ProjectId { get; private set; }

        /// <summary>
        /// Gets or Sets Order
        /// </summary>
        [JsonPropertyName("order")]
        public int? Order { get; set; }
    }
}
