using System;
using System.Net.Http;
using Todoist.Clients;

namespace Todoist
{
    /// <inheritdoc cref="ITodoistClient"/>
    public partial class TodoistClient :
        ITodoistClient
    {
        private readonly string _accessToken;

        private readonly HttpClient _client;

        /// <summary>
        /// Initializes a new instance of the <see cref="TodoistClient"/> class.
        /// </summary>
        public TodoistClient(string accessToken, HttpMessageHandler handler = null)
        {
            _accessToken = accessToken ?? throw new ArgumentNullException(nameof(accessToken));
            _client = handler != null ? new HttpClient(handler) : new HttpClient();
            _client.SetBearerToken(_accessToken);
        }

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
}
