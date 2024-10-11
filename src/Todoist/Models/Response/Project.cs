using System.Text.Json.Serialization;

namespace Todoist.Models;

/// <summary>
/// Project
/// </summary>
public partial class Project
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Project" /> class.
    /// </summary>
    [JsonConstructor]
    public Project(
        long id = default,
        string name = default,
        int commentCount = default,
        int order = default,
        int color = default,
        bool shared = default,
        bool favorite = default,
        bool inboxProject = default,
        bool teamInbox = default,
        string url = default,
        long? parentId = default)
    {
        Id = id;
        Name = name;
        CommentCount = commentCount;
        Order = order;
        Color = color;
        Shared = shared;
        Favorite = favorite;
        InboxProject = inboxProject;
        TeamInbox = teamInbox;
        Url = url;
        ParentId = parentId;
    }

    /// <summary>
    /// Gets Id
    /// </summary>
    [JsonPropertyName("id")]
    public long Id { get; private set; }

    /// <summary>
    /// Gets Name
    /// </summary>
    [JsonPropertyName("name")]
    public string Name { get; private set; }

    /// <summary>
    /// Gets CommentCount
    /// </summary>
    [JsonPropertyName("comment_count")]
    public int CommentCount { get; private set; }

    /// <summary>
    /// Gets Order
    /// </summary>
    [JsonPropertyName("order")]
    public int Order { get; private set; }

    /// <summary>
    /// Gets Color
    /// </summary>
    [JsonPropertyName("color")]
    public int Color { get; private set; }

    /// <summary>
    /// Gets Shared
    /// </summary>
    [JsonPropertyName("shared")]
    public bool Shared { get; private set; }

    /// <summary>
    /// Gets Favorite
    /// </summary>
    [JsonPropertyName("favorite")]
    public bool Favorite { get; private set; }

    /// <summary>
    /// Gets InboxProject
    /// </summary>
    [JsonPropertyName("inbox_project")]
    public bool InboxProject { get; private set; }

    /// <summary>
    /// Gets TeamInbox
    /// </summary>
    [JsonPropertyName("team_inbox")]
    public bool TeamInbox { get; private set; }

    /// <summary>
    /// Gets Url
    /// </summary>
    [JsonPropertyName("url")]
    public string Url { get; private set; }

    /// <summary>
    /// Gets ParentId
    /// </summary>
    [JsonPropertyName("parent_id")]
    public long? ParentId { get; private set; }
}
