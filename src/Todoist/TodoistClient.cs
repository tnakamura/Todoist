using System;
using System.Net.Http;
using Todoist.Clients;

namespace Todoist;

/// <inheritdoc cref="ITodoistClient"/>
public partial class TodoistClient :
    ITodoistClient
{
    private readonly HttpClient _client;

    /// <summary>
    /// Initializes a new instance of the <see cref="TodoistClient"/> class.
    /// </summary>
    public TodoistClient(HttpMessageHandler? handler = null)
    {
        _client = handler is not null ? new HttpClient(handler) : new HttpClient();
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="TodoistClient"/> class.
    /// </summary>
    public TodoistClient(string accessToken, HttpMessageHandler? handler = null)
    {
        if (accessToken is null) throw new ArgumentNullException(nameof(accessToken));
        _client = handler is not null ? new HttpClient(handler) : new HttpClient();
        _client.SetBearerToken(accessToken);
    }

    /// <inheritdoc/>
    public IAuthTokenClient AuthToken => this;

    /// <inheritdoc/>
    public ITasksClient Tasks => this;

    /// <inheritdoc/>
    public IProjectsClient Projects => this;

    /// <inheritdoc/>
    public ISectionsClient Sections => this;

    /// <inheritdoc/>
    public ILabelsClient Labels => this;

    /// <inheritdoc/>
    public ICommentsClient Comments => this;
}
