using System;
using System.Text.Json.Serialization;

namespace Todoist.Models
{
    /// <summary>
    /// CommentUpdate
    /// </summary>
    public class UpdateCommentArgs
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateCommentArgs" /> class.
        /// </summary>
        /// <param name="content">content (required).</param>
        public UpdateCommentArgs(string content)
        {
            Content = content ?? throw new ArgumentNullException(nameof(content));
        }

        /// <summary>
        /// Gets Content
        /// </summary>
        [JsonPropertyName("content")]
        public string Content { get; private set; }
    }
}
