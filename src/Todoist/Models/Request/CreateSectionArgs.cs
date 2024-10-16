using System;
using System.Text.Json.Serialization;

namespace Todoist.Models
{
    /// <summary>
    /// NewSection
    /// </summary>
    public class CreateSectionArgs
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateSectionArgs" /> class.
        /// </summary>
        /// <param name="name">name (required).</param>
        /// <param name="projectId">projectId (required).</param>
        /// <param name="order">order.</param>
        public CreateSectionArgs(string name, string projectId, int? order = default)
        {
            Name = name;
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
        public string ProjectId { get; private set; }

        /// <summary>
        /// Gets or Sets Order
        /// </summary>
        [JsonPropertyName("order")]
        public int? Order { get; set; }
    }
}
