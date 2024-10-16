using System.Text.Json.Serialization;

namespace Todoist.Models;

public abstract class GetCommentsArgs
{
    /// <summary>
    /// Initializes a new instance of the <see cref="GetCommentsArgs" /> class.
    /// </summary>
    private protected GetCommentsArgs() { }

    /// <summary>
    /// ID of the project used to filter comments.
    /// </summary>
    [JsonPropertyName("project_id")]
    public string? ProjectId { get; private protected set; }

    /// <summary>
    /// ID of the task used to filter comments.
    /// </summary>
    [JsonPropertyName("task_id")]
    public string? TaskId { get; private protected set; }
}

public sealed class GetProjectCommentsArgs : GetCommentsArgs
{
    /// <summary>
    /// Initializes a new instance of the <see cref="GetProjectCommentsArgs" /> class.
    /// </summary>
    public GetProjectCommentsArgs(string projectId)
        : base()
    {
        ProjectId = projectId;
    }
}

public sealed class GetTaskCommentsArgs : GetCommentsArgs
{
    /// <summary>
    /// Initializes a new instance of the <see cref="GetTaskCommentsArgs" /> class.
    /// </summary>
    public GetTaskCommentsArgs(string taskId)
        : base()
    {
        TaskId = taskId;
    }
}
