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
    /// <param name="id">id.</param>
    /// <param name="projectId">projectId.</param>
    /// <param name="sectionId">sectionId.</param>
    /// <param name="content">content.</param>
    /// <param name="description">description.</param>
    /// <param name="completed">completed.</param>
    /// <param name="labelIds">labelIds.</param>
    /// <param name="parentId">parentId.</param>
    /// <param name="order">order.</param>
    /// <param name="priority">priority.</param>
    /// <param name="due">due.</param>
    /// <param name="url">url.</param>
    /// <param name="commentCount">commentCount.</param>
    /// <param name="assignee">assignee.</param>
    /// <param name="assigner">assigner.</param>
    public Task(
        long id = default,
        long projectId = default,
        int? sectionId = default,
        string content = default,
        string description = default,
        bool completed = default,
        IList<long> labelIds = default,
        long? parentId = default,
        int order = default,
        int priority = default,
        DueDate due = default,
        string url = default,
        int commentCount = default,
        int? assignee = default,
        int? assigner = default)
    {
        Id = id;
        ProjectId = projectId;
        SectionId = sectionId;
        Content = content;
        Description = description;
        Completed = completed;
        LabelIds = labelIds;
        ParentId = parentId;
        Order = order;
        Priority = priority;
        Due = due;
        Url = url;
        CommentCount = commentCount;
        Assignee = assignee;
        Assigner = assigner;
    }

    /// <summary>
    /// Gets Id
    /// </summary>
    [JsonPropertyName("id")]
    public long Id { get; private set; }

    /// <summary>
    /// Gets ProjectId
    /// </summary>
    [JsonPropertyName("project_id")]
    public long ProjectId { get; private set; }

    /// <summary>
    /// Gets SectionId
    /// </summary>
    [JsonPropertyName("section_id")]
    public int? SectionId { get; private set; }

    /// <summary>
    /// Gets Content
    /// </summary>
    [JsonPropertyName("content")]
    public string Content { get; private set; }

    /// <summary>
    /// Gets Description
    /// </summary>
    [JsonPropertyName("description")]
    public string Description { get; private set; }

    /// <summary>
    /// Gets Completed
    /// </summary>
    [JsonPropertyName("completed")]
    public bool Completed { get; private set; }

    /// <summary>
    /// Gets LabelIds
    /// </summary>
    [JsonPropertyName("label_ids")]
    public IList<long> LabelIds { get; private set; }

    /// <summary>
    /// Gets ParentId
    /// </summary>
    [JsonPropertyName("parent_id")]
    public long? ParentId { get; private set; }

    /// <summary>
    /// Gets Order
    /// </summary>
    [JsonPropertyName("order")]
    public int Order { get; private set; }

    /// <summary>
    /// Gets Priority
    /// </summary>
    [JsonPropertyName("priority")]
    public int Priority { get; private set; }

    /// <summary>
    /// Gets Due
    /// </summary>
    [JsonPropertyName("due")]
    public DueDate Due { get; private set; }

    /// <summary>
    /// Gets Url
    /// </summary>
    [JsonPropertyName("url")]
    public string Url { get; private set; }

    /// <summary>
    /// Gets CommentCount
    /// </summary>
    [JsonPropertyName("comment_count")]
    public int CommentCount { get; private set; }

    /// <summary>
    /// Gets Assignee
    /// </summary>
    [JsonPropertyName("assignee")]
    public int? Assignee { get; private set; }

    /// <summary>
    /// Gets Assigner
    /// </summary>
    [JsonPropertyName("assigner")]
    public int? Assigner { get; private set; }
}
