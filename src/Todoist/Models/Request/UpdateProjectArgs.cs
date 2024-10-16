using System.Text.Json.Serialization;

namespace Todoist.Models
{
    /// <summary>
    /// ProjectUpdate
    /// </summary>
    public class UpdateProjectArgs
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateProjectArgs" /> class.
        /// </summary>
        /// <param name="name">
        /// Name of the project.
        /// </param>
        /// <param name="color">
        /// The color of the project icon.
        /// Refer to the name column in the Colors guide for more info.
        /// </param>
        /// <param name="favorite">
        /// Whether the project is a favorite (a true or false value).
        /// </param>
        /// <param name="viewStyle">
        /// A string value (either list or board).
        /// This determines the way the project is displayed within the Todoist clients.
        /// </param>
        public UpdateProjectArgs(
            string? name = default,
            string? color = default,
            bool? favorite = default,
            string? viewStyle = default)
        {
            Name = name;
            Color = color;
            IsFavorite = favorite;
            ViewStyle = viewStyle;
        }

        /// <summary>
        /// Name of the project.
        /// </summary>
        [JsonPropertyName("name")]
        public string? Name { get; set; }

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
        /// A string value (either list or board).
        /// This determines the way the project is displayed within the Todoist clients.
        /// </summary>
        [JsonPropertyName("view_style")]
        public string? ViewStyle { get; set; }
    }
}
