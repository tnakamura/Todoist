using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Todoist.Models;

/// <summary>
/// NewTask
/// </summary>
public class CreateTaskArgs
{
    /// <summary>
    /// Initializes a new instance of the <see cref="CreateTaskArgs" /> class.
    /// </summary>
    public CreateTaskArgs(
        string content,
        string? description = default,
        string? projectId = default,
        string? sectionId = default,
        string? parentId = default,
        int? order = default,
        IList<string>? labels = default,
        int? priority = default,
        string? dueString = default,
        DateTimeOffset? dueDate = default,
        DateTimeOffset? dueDateTime = default,
        string? dueLang = default,
        string? assigneeId = default,
        int? duration = default,
        string? durationUnit = default)
    {
        Content = content;
        Description = description;
        ProjectId = projectId;
        SectionId = sectionId;
        ParentId = parentId;
        Order = order;
        Labels = labels;
        Priority = priority;
        DueString = dueString;
        DueDate = dueDate;
        DueDateTime = dueDateTime;
        DueLang = dueLang;
        AssigneeId = assigneeId;
        Duration = duration;
        DurationUnit = durationUnit;
    }

    /// <summary>
    /// Task content.
    /// This value may contain markdown-formatted text and hyperlinks.
    /// Details on markdown support can be found in the Text Formatting article in the Help Center.
    /// </summary>
    [JsonPropertyName("content")]
    public string Content { get; set; }

    /// <summary>
    /// A description for the task.
    /// This value may contain markdown-formatted text and hyperlinks.
    /// Details on markdown support can be found in the Text Formatting article in the Help Center.
    /// </summary>
    [JsonPropertyName("description")]
    public string? Description { get; set; }

    /// <summary>
    /// Task project ID. If not set, task is put to user's Inbox.
    /// </summary>
    [JsonPropertyName("project_id")]
    public string? ProjectId { get; set; }

    /// <summary>
    /// ID of section to put task into.
    /// </summary>
    [JsonPropertyName("section_id")]
    public string? SectionId { get; set; }

    /// <summary>
    /// Parent task ID.
    /// </summary>
    [JsonPropertyName("parent_id")]
    public string? ParentId { get; set; }

    /// <summary>
    /// Non-zero integer value used by clients to sort tasks under the same parent.
    /// </summary>
    [JsonPropertyName("order")]
    public int? Order { get; set; }

    /// <summary>
    /// The task's labels (a list of names that may represent either personal or shared labels).
    /// </summary>
    [JsonPropertyName("labels")]
    public IList<string>? Labels { get; set; }

    /// <summary>
    /// Task priority from 1 (normal) to 4 (urgent).
    /// </summary>
    [JsonPropertyName("priority")]
    public int? Priority { get; set; }

    /// <summary>
    /// Human defined task due date (ex.: "next Monday", "Tomorrow").
    /// Value is set using local (not UTC) time.
    /// </summary>
    [JsonPropertyName("due_string")]
    public string? DueString { get; set; }

    /// <summary>
    /// Specific date in YYYY-MM-DD format relative to userÅfs timezone.
    /// </summary>
    [JsonPropertyName("due_date")]
    public DateTimeOffset? DueDate { get; set; }

    /// <summary>
    /// Specific date and time in RFC3339 format in UTC.
    /// </summary>
    [JsonPropertyName("due_datetime")]
    public DateTimeOffset? DueDateTime { get; set; }

    /// <summary>
    /// 2-letter code specifying language in case due_string is not written in English.
    /// </summary>
    [JsonPropertyName("due_lang")]
    public string? DueLang { get; set; }

    /// <summary>
    /// The responsible user ID (only applies to shared tasks).
    /// </summary>
    [JsonPropertyName("assignee_id")]
    public string? AssigneeId { get; set; }

    /// <summary>
    /// A positive (greater than zero) integer for the amount of duration_unit the task will take.
    /// If specified, you must define a duration_unit.
    /// </summary>
    [JsonPropertyName("duration")]
    public int? Duration { get; set; }

    /// <summary>
    /// The unit of time that the duration field above represents.
    /// Must be either minute or day.
    /// If specified, duration must be defined as well.
    /// </summary>
    [JsonPropertyName("duration_unit")]
    public string? DurationUnit { get; set; }
}
