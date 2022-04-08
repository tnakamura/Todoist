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
        /// <param name="name">name.</param>
        /// <param name="order">order.</param>
        /// <param name="color">color.</param>
        /// <param name="favorite">favorite.</param>
        public UpdateLabelArgs(
            string name = default,
            int? order = default,
            int? color = default,
            bool? favorite = default)
        {
            Name = name;
            Order = order;
            Color = color;
            Favorite = favorite;
        }

        /// <summary>
        /// Gets or Sets Name
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or Sets Order
        /// </summary>
        [JsonPropertyName("order")]
        public int? Order { get; set; }

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
