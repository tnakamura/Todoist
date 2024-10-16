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
        /// <param name="name">
        /// Name of the project.
        /// </param>
        /// <param name="parentId">
        /// Parent project ID.
        /// </param>
        /// <param name="color">
        /// The color of the project icon.
        /// Refer to the name column in the Colors guide for more info.
        /// </param>
        /// <param name="isFavorite">
        /// Whether the project is a favorite (a true or false value).
        /// </param>
        /// <param name="viewStyle">
        /// A string value (either list or board, default is list).
        /// This determines the way the project is displayed within the Todoist clients.
        /// </param>
        public CreateProjectArgs(
            string name,
            string? parentId = default,
            string? color = default,
            bool? isFavorite = default,
            string? viewStyle = default)
        {
            Name = name;
            ParentId = parentId;
            Color = color;
            IsFavorite = isFavorite;
            ViewStyle = viewStyle;
        }

        /// <summary>
        /// Name of the project.
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; private set; }

        /// <summary>
        /// Parent project ID.
        /// </summary>
        [JsonPropertyName("parent_id")]
        public string? ParentId { get; set; }

        /// <summary>
        /// The color of the project icon.
        /// Refer to the name column in the Colors guide for more info.
        /// </summary>
        [JsonPropertyName("color")]
        public string? Color { get; set; }

        /// <summary>
        /// Whether the project is a favorite (a true or false value).
        /// </summary>
        [JsonPropertyName("is_favorite")]
        public bool? IsFavorite { get; set; }

        /// <summary>
        /// A string value (either list or board, default is list).
        /// This determines the way the project is displayed within the Todoist clients.
        /// </summary>
        [JsonPropertyName("view_style")]
        public string? ViewStyle { get; set; }
    }
}
