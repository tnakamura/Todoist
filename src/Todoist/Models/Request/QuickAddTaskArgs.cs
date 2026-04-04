using System.Text.Json.Serialization;

namespace Todoist.Models;

/// <summary>
/// Quick add task args.
/// </summary>
public sealed class QuickAddTaskArgs
{
    /// <summary>
    /// Initializes a new instance of the <see cref="QuickAddTaskArgs"/> class.
    /// </summary>
    public QuickAddTaskArgs(
        string text,
        bool? autoReminder = null,
        string? note = null,
        bool? reminder = null)
    {
        Text = text;
        AutoReminder = autoReminder;
        Note = note;
        Reminder = reminder;
    }

    /// <summary>
    /// Task text with natural language.
    /// </summary>
    [JsonPropertyName("text")]
    public string Text { get; set; }

    /// <summary>
    /// Enable automatic reminders where applicable.
    /// </summary>
    [JsonPropertyName("auto_reminder")]
    public bool? AutoReminder { get; set; }

    /// <summary>
    /// Optional note for created task.
    /// </summary>
    [JsonPropertyName("note")]
    public string? Note { get; set; }

    /// <summary>
    /// Parse reminder in the text.
    /// </summary>
    [JsonPropertyName("reminder")]
    public bool? Reminder { get; set; }
}
