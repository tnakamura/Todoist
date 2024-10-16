using System.Text.Json.Serialization;

namespace Todoist.Models
{
    /// <summary>
    /// NewLabel
    /// </summary>
    public class CreateLabelArgs
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateLabelArgs" /> class.
        /// </summary>
        public CreateLabelArgs(
            string name,
            int? order = default,
            string? color = default,
            bool? isFavorite = default)
        {
            Name = name;
            Order = order;
            Color = color;
            IsFavorite = isFavorite;
        }

        /// <summary>
        /// Name of the label.
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; private set; }

        /// <summary>
        /// Label order.
        /// </summary>
        [JsonPropertyName("order")]
        public int? Order { get; set; }

        /// <summary>
        /// The color of the label icon.
        /// Refer to the name column in the Colors guide for more info.
        /// </summary>
        [JsonPropertyName("color")]
        public string? Color { get; set; }

        /// <summary>
        /// Whether the label is a favorite (a true or false value).
        /// </summary>
        [JsonPropertyName("is_favorite")]
        public bool? IsFavorite { get; set; }
    }
}
