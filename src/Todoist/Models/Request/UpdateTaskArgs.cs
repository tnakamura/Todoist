using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Todoist.Models;

/// <summary>
/// TaskUpdate
/// </summary>
public class UpdateTaskArgs
{
    /// <summary>
    /// Initializes a new instance of the <see cref="UpdateTaskArgs" /> class.
    /// </summary>
    public UpdateTaskArgs(
        string? content = null,
        string? description = null,
        IList<string>? labels = null,
        int? priority = null,
        string? dueString = null,
        DateTimeOffset? dueDate = null,
        DateTimeOffset? dueDateTime = null,
        string? dueLang = null,
        string? assigneeId = null,
        int? duration = null,
        string? durationUnit = null)
    {
        Content = content;
        Description = description;
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
    public string? Content { get; set; }

    /// <summary>
    /// A description for the task.
    /// This value may contain markdown-formatted text and hyperlinks.
    /// Details on markdown support can be found in the Text Formatting article in the Help Center.
    /// </summary>
    [JsonPropertyName("description")]
    public string? Description { get; set; }

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
    /// Value is set using local (not UTC) time. Using "no date" or "no due date" removes the date.
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
    /// The responsible user ID or null to unset (for shared tasks).
    /// </summary>
    [JsonPropertyName("assignee_id")]
    public string? AssigneeId { get; set; }

    /// <summary>
    /// A positive (greater than zero) integer for the amount of duration_unit the task will take,
    /// or null to unset. If specified, you must define a duration_unit.
    /// </summary>
    [JsonPropertyName("duration")]
    public int? Duration { get; set; }

    /// <summary>
    /// The unit of time that the duration field above represents,
    /// or null to unset.
    /// Must be either minute or day.
    /// If specified, duration must be defined as well.
    /// </summary>
    [JsonPropertyName("duration_unit")]
    public string? DurationUnit { get; set; }
}
