using System.Text.Json.Serialization;

namespace Todoist.Models;

/// <summary>
/// NewComment
/// </summary>
public abstract class CreateCommentArgs
{
    /// <summary>
    /// Initializes a new instance of the <see cref="CreateCommentArgs" /> class.
    /// </summary>
    private protected CreateCommentArgs(
        string content,
        string? taskId = null,
        string? projectId = null,
        Attachment? attachment = null)
    {
        Content = content;
        TaskId = taskId;
        ProjectId = projectId;
        Attachment = attachment;
    }

    /// <summary>
    /// Comment's task ID (for task comments).
    /// </summary>
    [JsonPropertyName("task_id")]
    public string? TaskId { get; private protected set; }

    /// <summary>
    /// Comment's project ID (for project comments).
    /// </summary>
    [JsonPropertyName("project_id")]
    public string? ProjectId { get; private protected set; }

    /// <summary>
    /// Comment content.
    /// This value may contain markdown-formatted text and hyperlinks.
    /// Details on markdown support can be found in the Text Formatting article in the Help Center.
    /// </summary>
    [JsonPropertyName("content")]
    public string Content { get; private set; }

    /// <summary>
    /// Object for attachment object.
    /// </summary>
    [JsonPropertyName("attachment")]
    public Attachment? Attachment { get; set; }
}

/// <summary>
/// New Task Comment
/// </summary>
public sealed class AddTaskCommentArgs : CreateCommentArgs
{
    /// <summary>
    /// Initializes a new instance of the <see cref="AddTaskCommentArgs" /> class.
    /// </summary>
    /// <param name="taskId">taskId.</param>
    /// <param name="content">content (required).</param>
    /// <param name="attachment">attachment.</param>
    public AddTaskCommentArgs(
        string taskId,
        string content,
        Attachment? attachment = default) :
        base(
            taskId: taskId,
             content: content,
             attachment: attachment)
    {
    }
}

/// <summary>
/// New Project Comment
/// </summary>
public sealed class AddProjectCommentArgs : CreateCommentArgs
{
    /// <summary>
    /// Initializes a new instance of the <see cref="AddProjectCommentArgs" /> class.
    /// </summary>
    /// <param name="projectId">projectId.</param>
    /// <param name="content">content (required).</param>
    /// <param name="attachment">attachment.</param>
    public AddProjectCommentArgs(
        string projectId,
        string content,
        Attachment? attachment = default) :
        base(
            projectId: projectId,
            content: content,
            attachment: attachment)
    {
    }
}
