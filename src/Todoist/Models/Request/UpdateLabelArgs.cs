using System.Text.Json.Serialization;

namespace Todoist.Models
{
    /// <summary>
    /// LabelUpdate
    /// </summary>
    public class UpdateLabelArgs
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateLabelArgs" /> class.
        /// </summary>
        public UpdateLabelArgs(
            string? name = default,
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
        /// New name of the label.
        /// </summary>
        [JsonPropertyName("name")]
        public string? Name { get; set; }

        /// <summary>
        /// Number that is used by clients to sort list of labels.
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
