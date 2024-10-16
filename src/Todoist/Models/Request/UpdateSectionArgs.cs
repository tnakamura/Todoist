using System;
using System.Text.Json.Serialization;

namespace Todoist.Models
{
    /// <summary>
    /// SectionUpdate
    /// </summary>
    public class UpdateSectionArgs 
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateSectionArgs" /> class.
        /// </summary>
        /// <param name="name">name (required).</param>
        public UpdateSectionArgs(string name)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
        }

        /// <summary>
        /// Section name
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; private set; }
    }
}
