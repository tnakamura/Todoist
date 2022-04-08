using System.Text.Json.Serialization;

namespace Todoist.Models
{
    /// <summary>
    /// Attachment
    /// </summary>
    public class Attachment
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Attachment" /> class.
        /// </summary>
        [JsonConstructor]
        protected Attachment() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="Attachment" /> class.
        /// </summary>
        /// <param name="resourceType">resourceType.</param>
        /// <param name="fileUrl">fileUrl.</param>
        /// <param name="fileType">fileType.</param>
        /// <param name="fileName">fileName.</param>
        public Attachment(
            string resourceType = default,
            string fileUrl = default,
            string fileType = default,
            string fileName = default)
        {
            ResourceType = resourceType;
            FileUrl = fileUrl;
            FileType = fileType;
            FileName = fileName;
        }

        /// <summary>
        /// Gets ResourceType
        /// </summary>
        [JsonPropertyName("resource_type")]
        public string ResourceType { get; private set; }

        /// <summary>
        /// Gets FileUrl
        /// </summary>
        [JsonPropertyName("file_url")]
        public string FileUrl { get; private set; }

        /// <summary>
        /// Gets FileType
        /// </summary>
        [JsonPropertyName("file_type")]
        public string FileType { get; private set; }

        /// <summary>
        /// Gets FileName
        /// </summary>
        [JsonPropertyName("file_name")]
        public string FileName { get; private set; }

    }
}
