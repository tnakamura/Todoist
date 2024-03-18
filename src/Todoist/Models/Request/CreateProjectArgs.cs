using System.Text.Json.Serialization;

namespace Todoist.Models
{
    /// <summary>
    /// NewProject
    /// </summary>
    public partial class CreateProjectArgs
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateProjectArgs" /> class.
        /// </summary>
        /// <param name="name">name.</param>
        /// <param name="parentId">parentId.</param>
        /// <param name="color">color.</param>
        /// <param name="favorite">favorite.</param>
        public CreateProjectArgs(
            string name,
            long? parentId = default,
            int? color = default,
            bool? favorite = default)
        {
            Name = name;
            ParentId = parentId;
            Color = color;
            Favorite = favorite;
        }

        /// <summary>
        /// Gets Name
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; private set; }

        /// <summary>
        /// Gets or Sets ParentId
        /// </summary>
        [JsonPropertyName("parent_id")]
        public long? ParentId { get; set; }

        /// <summary>
        /// Gets or Sets Color
        /// </summary>
        [JsonPropertyName("color")]
        public int? Color { get; set; }

        /// <summary>
        /// Gets or Sets Favorite
        /// </summary>
        [JsonPropertyName("favorite")]
        public bool? Favorite { get; set; }
    }
}
