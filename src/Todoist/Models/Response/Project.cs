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
        string id,
        string name,
        int commentCount,
        int order,
        string color,
        bool isShared,
        bool isFavorite,
        bool isInboxProject,
        bool isTeamInbox,
        string url,
        string viewStyle,
        string? parentId = default)
    {
        Id = id;
        Name = name;
        CommentCount = commentCount;
        Order = order;
        Color = color;
        IsShared = isShared;
        IsFavorite = isFavorite;
        IsInboxProject = isInboxProject;
        IsTeamInbox = isTeamInbox;
        Url = url;
        ParentId = parentId;
        ViewStyle = viewStyle;
    }

    /// <summary>
    /// Project ID.
    /// </summary>
    [JsonPropertyName("id")]
    public string Id { get; private set; }

    /// <summary>
    /// Project name.
    /// </summary>
    [JsonPropertyName("name")]
    public string Name { get; private set; }

    /// <summary>
    /// The color of the project icon.
    /// Refer to the name column in the Colors guide for more info.
    /// </summary>
    [JsonPropertyName("color")]
    public string Color { get; private set; }

    /// <summary>
    /// ID of parent project (will be null for top-level projects).
    /// </summary>
    [JsonPropertyName("parent_id")]
    public string? ParentId { get; private set; }

    /// <summary>
    /// Project position under the same parent
    /// (read-only, will be 0 for inbox and team inbox projects).
    /// </summary>
    [JsonPropertyName("order")]
    public int Order { get; private set; }

    /// <summary>
    /// Number of project comments.
    /// </summary>
    [JsonPropertyName("comment_count")]
    public int CommentCount { get; private set; }

    /// <summary>
    /// Whether the project is shared
    /// (read-only, a true or false value).
    /// </summary>
    [JsonPropertyName("is_shared")]
    public bool IsShared { get; private set; }

    /// <summary>
    /// Whether the project is a favorite
    /// (a true or false value).
    /// </summary>
    [JsonPropertyName("is_favorite")]
    public bool IsFavorite { get; private set; }

    /// <summary>
    /// Whether the project is the user's Inbox (read-only).
    /// </summary>
    [JsonPropertyName("is_inbox_project")]
    public bool IsInboxProject { get; private set; }

    /// <summary>
    /// Whether the project is the Team Inbox (read-only).
    /// </summary>
    [JsonPropertyName("is_team_inbox")]
    public bool IsTeamInbox { get; private set; }

    /// <summary>
    /// A string value (either list or board).
    /// This determines the way the project is displayed within the Todoist clients.
    /// </summary>
    [JsonPropertyName("view_style")]
    public string ViewStyle { get; private set; }

    /// <summary>
    /// URL to access this project in the Todoist web or mobile applications.
    /// </summary>
    [JsonPropertyName("url")]
    public string Url { get; private set; }
}
