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
        /// <param name="name">name.</param>
        /// <param name="color">color.</param>
        /// <param name="favorite">favorite.</param>
        public UpdateProjectArgs(
            string name = default,
            int? color = default,
            bool? favorite = default)
        {
            Name = name;
            Color = color;
            Favorite = favorite;
        }

        /// <summary>
        /// Gets or Sets Name
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }

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
