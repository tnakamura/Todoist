using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Todoist.Models;

/// <summary>
/// Task
/// </summary>
public partial class Task
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Task" /> class.
    /// </summary>
    [JsonConstructor]
    public Task(
        string id,
        string projectId,
        string? sectionId,
        string content,
        string description,
        bool isCompleted,
        IList<string> labels,
        string? parentId,
        int order,
        int priority,
        Due? due,
        string url,
        int commentCount,
        DateTimeOffset createdAt,
        string creatorId,
        string? assigneeId,
        string? assignerId,
        Duration? duration)
    {
        Id = id;
        ProjectId = projectId;
        SectionId = sectionId;
        Content = content;
        Description = description;
        IsCompleted = isCompleted;
        Labels = labels;
        ParentId = parentId;
        Order = order;
        Priority = priority;
        Due = due;
        Url = url;
        CommentCount = commentCount;
        CreatedAt = createdAt;
        CreatorId = creatorId;
        AssigneeId = assigneeId;
        AssignerId = assignerId;
        Duration = duration;
    }

    /// <summary>
    /// Task ID.
    /// </summary>
    [JsonPropertyName("id")]
    public string Id { get; private set; }

    /// <summary>
    /// Task's project ID (read-only).
    /// </summary>
    [JsonPropertyName("project_id")]
    public string ProjectId { get; private set; }

    /// <summary>
    /// ID of section task belongs to (read-only, will be null when the task has no parent section).
    /// </summary>
    [JsonPropertyName("section_id")]
    public string? SectionId { get; private set; }

    /// <summary>
    /// Task content.
    /// This value may contain markdown-formatted text and hyperlinks.
    /// Details on markdown support can be found in the Text Formatting article in the Help Center.
    /// </summary>
    [JsonPropertyName("content")]
    public string Content { get; private set; }

    /// <summary>
    /// A description for the task.
    /// This value may contain markdown-formatted text and hyperlinks.
    /// Details on markdown support can be found in the Text Formatting article in the Help Center.
    /// </summary>
    [JsonPropertyName("description")]
    public string Description { get; private set; }

    /// <summary>
    /// Flag to mark completed tasks.
    /// </summary>
    [JsonPropertyName("is_completed")]
    public bool IsCompleted { get; private set; }

    /// <summary>
    /// The task's labels (a list of names that may represent either personal or shared labels).
    /// </summary>
    [JsonPropertyName("labels")]
    public IList<string> Labels { get; private set; }

    /// <summary>
    /// ID of parent task (read-only, will be null for top-level tasks).
    /// </summary>
    [JsonPropertyName("parent_id")]
    public string? ParentId { get; private set; }

    /// <summary>
    /// Position under the same parent or project for top-level tasks (read-only).
    /// </summary>
    [JsonPropertyName("order")]
    public int Order { get; private set; }

    /// <summary>
    /// Task priority from 1 (normal, default value) to 4 (urgent).
    /// </summary>
    [JsonPropertyName("priority")]
    public int Priority { get; private set; }

    /// <summary>
    /// object representing task due date/time, or null if no date is set.
    /// </summary>
    [JsonPropertyName("due")]
    public Due? Due { get; private set; }

    /// <summary>
    /// URL to access this task in the Todoist web or mobile applications (read-only).
    /// </summary>
    [JsonPropertyName("url")]
    public string Url { get; private set; }

    /// <summary>
    /// Number of task comments (read-only).
    /// </summary>
    [JsonPropertyName("comment_count")]
    public int CommentCount { get; private set; }

    /// <summary>
    /// The date when the task was created (read-only).
    /// </summary>
    [JsonPropertyName("created_at")]
    public DateTimeOffset CreatedAt { get; private set; }

    /// <summary>
    /// The ID of the user who created the task (read-only).
    /// </summary>
    [JsonPropertyName("creator_id")]
    public string CreatorId { get; private set; }

    /// <summary>
    /// The responsible user ID (will be null if the task is unassigned).
    /// </summary>
    [JsonPropertyName("assignee_id")]
    public string? AssigneeId { get; private set; }

    /// <summary>
    /// The ID of the user who assigned the task (read-only, will be null if the task is unassigned).
    /// </summary>
    [JsonPropertyName("assigner_id")]
    public string? AssignerId { get; private set; }

    /// <summary>
    /// Object representing a task's duration.
    /// Includes a positive integer (greater than zero) for the amount of time the task will take,
    /// and the unit of time that the amount represents which must be either minute or day.
    /// Both the amount and unit must be defined.
    /// The object will be null if the task has no duration.
    /// </summary>
    [JsonPropertyName("duration")]
    public Duration? Duration { get; private set; }
}
