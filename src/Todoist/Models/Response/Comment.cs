using System;
using System.Text.Json.Serialization;

namespace Todoist.Models;

/// <summary>
/// Comment
/// </summary>
public partial class Comment
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Comment" /> class.
    /// </summary>
    [JsonConstructor]
    public Comment(
        string id,
        string? taskId,
        string? projectId,
        DateTimeOffset postedAt,
        string content,
        Attachment? attachment)
    {
        Id = id;
        TaskId = taskId;
        ProjectId = projectId;
        PostedAt = postedAt;
        Content = content;
        Attachment = attachment;
    }

    /// <summary>
    /// Comment ID.
    /// </summary>
    [JsonPropertyName("id")]
    public string Id { get; private set; }

    /// <summary>
    /// Comment's task ID (will be null if the comment belongs to a project).
    /// </summary>
    [JsonPropertyName("task_id")]
    public string? TaskId { get; private set; }

    /// <summary>
    /// Comment's project ID (will be null if the comment belongs to a task).
    /// </summary>
    [JsonPropertyName("project_id")]
    public string? ProjectId { get; private set; }

    /// <summary>
    /// Date and time when comment was added.
    /// </summary>
    [JsonPropertyName("posted_at")]
    public DateTimeOffset PostedAt { get; private set; }

    /// <summary>
    /// Comment content.
    /// This value may contain markdown-formatted text and hyperlinks.
    /// Details on markdown support can be found in the Text Formatting article in the Help Center.
    /// </summary>
    [JsonPropertyName("content")]
    public string Content { get; private set; }

    /// <summary>
    /// Attachment file (will be null if there is no attachment).
    /// </summary>
    [JsonPropertyName("attachment")]
    public Attachment? Attachment { get; private set; }
}
