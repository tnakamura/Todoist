using System;
using System.Text.Json.Serialization;

namespace Todoist.Models
{
    /// <summary>
    /// NewLabel
    /// </summary>
    public class AddLabelArgs
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AddLabelArgs" /> class.
        /// </summary>
        /// <param name="name">name (required).</param>
        /// <param name="order">order.</param>
        /// <param name="color">color.</param>
        /// <param name="favorite">favorite.</param>
        public AddLabelArgs(
            string name,
            int? order = default,
            int? color = default,
            bool? favorite = default)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Order = order;
            Color = color;
            Favorite = favorite;
        }

        /// <summary>
        /// Gets Name
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; private set; }

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
