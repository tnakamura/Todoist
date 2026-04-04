using System.Text.Json.Serialization;

namespace Todoist.Models;

/// <summary>
/// Reminder
/// </summary>
public sealed class Reminder
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Reminder"/> class.
    /// </summary>
    [JsonConstructor]
    public Reminder(
        string id,
        string notifyUid,
        string itemId,
        string service,
        string type)
    {
        Id = id;
        NotifyUid = notifyUid;
        ItemId = itemId;
        Service = service;
        Type = type;
    }

    /// <summary>
    /// Reminder ID.
    /// </summary>
    [JsonPropertyName("id")]
    public string Id { get; private set; }

    /// <summary>
    /// User ID to notify.
    /// </summary>
    [JsonPropertyName("notify_uid")]
    public string NotifyUid { get; private set; }

    /// <summary>
    /// Task ID.
    /// </summary>
    [JsonPropertyName("item_id")]
    public string ItemId { get; private set; }

    /// <summary>
    /// Reminder service.
    /// </summary>
    [JsonPropertyName("service")]
    public string Service { get; private set; }

    /// <summary>
    /// Reminder type.
    /// </summary>
    [JsonPropertyName("type")]
    public string Type { get; private set; }
}
