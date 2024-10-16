using System;
using System.Text.Json.Serialization;

namespace Todoist.Models;

/// <summary>
/// CommentUpdate
/// </summary>
public class UpdateCommentArgs
{
    /// <summary>
    /// Initializes a new instance of the <see cref="UpdateCommentArgs" /> class.
    /// </summary>
    public UpdateCommentArgs(string content)
    {
        Content = content ?? throw new ArgumentNullException(nameof(content));
    }

    /// <summary>
    /// New content for the comment.
    /// This value may contain markdown-formatted text and hyperlinks.
    /// Details on markdown support can be found in the Text Formatting article in the Help Center.
    /// </summary>
    [JsonPropertyName("content")]
    public string Content { get; private set; }
}
