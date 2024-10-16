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
        public CreateSectionArgs(string name, string projectId, int? order = default)
        {
            Name = name;
            ProjectId = projectId;
            Order = order;
        }

        /// <summary>
        /// Section name
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; private set; }

        /// <summary>
        /// Project ID this section should belong to
        /// </summary>
        [JsonPropertyName("project_id")]
        public string ProjectId { get; private set; }

        /// <summary>
        /// Order among other sections in a project
        /// </summary>
        [JsonPropertyName("order")]
        public int? Order { get; set; }
    }
}
