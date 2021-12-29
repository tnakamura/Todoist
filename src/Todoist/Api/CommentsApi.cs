using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mime;
using Todoist.Client;
using Todoist.Model;

namespace Todoist
{
    using Todoist.Api;
    public partial interface ITodoistClient
    {
        ICommentsApi Comments { get; }
    }
    public partial class TodoistClient
    {
        private ICommentsApi _comments;

        public ICommentsApi Comments =>
            _comments ?? (_comments = CreateCommentsApi());

        private CommentsApi CreateCommentsApi()
        {
            if (_client != null && _configuration != null && _handler != null)
                return new CommentsApi(_client, _configuration, _handler); 
            if (_client != null && _basePath != null && _handler != null)
                return new CommentsApi(_client, _basePath, _handler); 
            if (_client != null &&  _handler != null)
                return new CommentsApi(_client, _handler); 
            if (_configuration != null)
                return new CommentsApi(_configuration); 
            if (_basePath != null)
                return new CommentsApi(_basePath); 
            return new CommentsApi();
        }
    }
}

namespace Todoist.Api
{

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface ICommentsApiSync : IApiAccessor
    {
        #region Synchronous Operations
        /// <summary>
        /// Create a new comment
        /// </summary>
        /// <remarks>
        /// Creates a new comment on a project or task and returns it as a JSON object. Note that one of task_id or project_id arguments is required.
        /// </remarks>
        /// <exception cref="Todoist.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="xRequestId"> (optional)</param>
        /// <param name="newComment"> (optional)</param>
        /// <returns>Comment</returns>
        Comment CreateComment(string xRequestId = default(string), NewComment newComment = default(NewComment));

        /// <summary>
        /// Create a new comment
        /// </summary>
        /// <remarks>
        /// Creates a new comment on a project or task and returns it as a JSON object. Note that one of task_id or project_id arguments is required.
        /// </remarks>
        /// <exception cref="Todoist.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="xRequestId"> (optional)</param>
        /// <param name="newComment"> (optional)</param>
        /// <returns>ApiResponse of Comment</returns>
        ApiResponse<Comment> CreateCommentWithHttpInfo(string xRequestId = default(string), NewComment newComment = default(NewComment));
        /// <summary>
        /// Delete a comment
        /// </summary>
        /// <remarks>
        /// Deletes a comment.
        /// </remarks>
        /// <exception cref="Todoist.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="commentId"></param>
        /// <returns></returns>
        void DeleteComment(long commentId);

        /// <summary>
        /// Delete a comment
        /// </summary>
        /// <remarks>
        /// Deletes a comment.
        /// </remarks>
        /// <exception cref="Todoist.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="commentId"></param>
        /// <returns>ApiResponse of Object(void)</returns>
        ApiResponse<Object> DeleteCommentWithHttpInfo(long commentId);
        /// <summary>
        /// Get a comment
        /// </summary>
        /// <remarks>
        /// Returns a single comment as a JSON object.
        /// </remarks>
        /// <exception cref="Todoist.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="commentId"></param>
        /// <returns>Comment</returns>
        Comment GetComment(long commentId);

        /// <summary>
        /// Get a comment
        /// </summary>
        /// <remarks>
        /// Returns a single comment as a JSON object.
        /// </remarks>
        /// <exception cref="Todoist.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="commentId"></param>
        /// <returns>ApiResponse of Comment</returns>
        ApiResponse<Comment> GetCommentWithHttpInfo(long commentId);
        /// <summary>
        /// Get all comments
        /// </summary>
        /// <remarks>
        /// Returns a JSON-encoded array of all comments for a given task_id or project_id. Note that one of task_id or project_id arguments is required.
        /// </remarks>
        /// <exception cref="Todoist.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="taskId"></param>
        /// <param name="projectId"> (optional)</param>
        /// <returns>List&lt;Comment&gt;</returns>
        List<Comment> GetComments(long taskId, long? projectId = default(long?));

        /// <summary>
        /// Get all comments
        /// </summary>
        /// <remarks>
        /// Returns a JSON-encoded array of all comments for a given task_id or project_id. Note that one of task_id or project_id arguments is required.
        /// </remarks>
        /// <exception cref="Todoist.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="taskId"></param>
        /// <param name="projectId"> (optional)</param>
        /// <returns>ApiResponse of List&lt;Comment&gt;</returns>
        ApiResponse<List<Comment>> GetCommentsWithHttpInfo(long taskId, long? projectId = default(long?));
        /// <summary>
        /// Update a comment
        /// </summary>
        /// <remarks>
        /// Updates a comment.
        /// </remarks>
        /// <exception cref="Todoist.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="commentId"></param>
        /// <param name="xRequestId"> (optional)</param>
        /// <param name="commentUpdate"> (optional)</param>
        /// <returns></returns>
        void UpdateComment(long commentId, string xRequestId = default(string), CommentUpdate commentUpdate = default(CommentUpdate));

        /// <summary>
        /// Update a comment
        /// </summary>
        /// <remarks>
        /// Updates a comment.
        /// </remarks>
        /// <exception cref="Todoist.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="commentId"></param>
        /// <param name="xRequestId"> (optional)</param>
        /// <param name="commentUpdate"> (optional)</param>
        /// <returns>ApiResponse of Object(void)</returns>
        ApiResponse<Object> UpdateCommentWithHttpInfo(long commentId, string xRequestId = default(string), CommentUpdate commentUpdate = default(CommentUpdate));
        #endregion Synchronous Operations
    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface ICommentsApiAsync : IApiAccessor
    {
        #region Asynchronous Operations
        /// <summary>
        /// Create a new comment
        /// </summary>
        /// <remarks>
        /// Creates a new comment on a project or task and returns it as a JSON object. Note that one of task_id or project_id arguments is required.
        /// </remarks>
        /// <exception cref="Todoist.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="xRequestId"> (optional)</param>
        /// <param name="newComment"> (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of Comment</returns>
        System.Threading.Tasks.Task<Comment> CreateCommentAsync(string xRequestId = default(string), NewComment newComment = default(NewComment), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// Create a new comment
        /// </summary>
        /// <remarks>
        /// Creates a new comment on a project or task and returns it as a JSON object. Note that one of task_id or project_id arguments is required.
        /// </remarks>
        /// <exception cref="Todoist.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="xRequestId"> (optional)</param>
        /// <param name="newComment"> (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (Comment)</returns>
        System.Threading.Tasks.Task<ApiResponse<Comment>> CreateCommentWithHttpInfoAsync(string xRequestId = default(string), NewComment newComment = default(NewComment), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// Delete a comment
        /// </summary>
        /// <remarks>
        /// Deletes a comment.
        /// </remarks>
        /// <exception cref="Todoist.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="commentId"></param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of void</returns>
        System.Threading.Tasks.Task DeleteCommentAsync(long commentId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// Delete a comment
        /// </summary>
        /// <remarks>
        /// Deletes a comment.
        /// </remarks>
        /// <exception cref="Todoist.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="commentId"></param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse</returns>
        System.Threading.Tasks.Task<ApiResponse<Object>> DeleteCommentWithHttpInfoAsync(long commentId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// Get a comment
        /// </summary>
        /// <remarks>
        /// Returns a single comment as a JSON object.
        /// </remarks>
        /// <exception cref="Todoist.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="commentId"></param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of Comment</returns>
        System.Threading.Tasks.Task<Comment> GetCommentAsync(long commentId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// Get a comment
        /// </summary>
        /// <remarks>
        /// Returns a single comment as a JSON object.
        /// </remarks>
        /// <exception cref="Todoist.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="commentId"></param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (Comment)</returns>
        System.Threading.Tasks.Task<ApiResponse<Comment>> GetCommentWithHttpInfoAsync(long commentId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// Get all comments
        /// </summary>
        /// <remarks>
        /// Returns a JSON-encoded array of all comments for a given task_id or project_id. Note that one of task_id or project_id arguments is required.
        /// </remarks>
        /// <exception cref="Todoist.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="taskId"></param>
        /// <param name="projectId"> (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of List&lt;Comment&gt;</returns>
        System.Threading.Tasks.Task<List<Comment>> GetCommentsAsync(long taskId, long? projectId = default(long?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// Get all comments
        /// </summary>
        /// <remarks>
        /// Returns a JSON-encoded array of all comments for a given task_id or project_id. Note that one of task_id or project_id arguments is required.
        /// </remarks>
        /// <exception cref="Todoist.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="taskId"></param>
        /// <param name="projectId"> (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (List&lt;Comment&gt;)</returns>
        System.Threading.Tasks.Task<ApiResponse<List<Comment>>> GetCommentsWithHttpInfoAsync(long taskId, long? projectId = default(long?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// Update a comment
        /// </summary>
        /// <remarks>
        /// Updates a comment.
        /// </remarks>
        /// <exception cref="Todoist.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="commentId"></param>
        /// <param name="xRequestId"> (optional)</param>
        /// <param name="commentUpdate"> (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of void</returns>
        System.Threading.Tasks.Task UpdateCommentAsync(long commentId, string xRequestId = default(string), CommentUpdate commentUpdate = default(CommentUpdate), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// Update a comment
        /// </summary>
        /// <remarks>
        /// Updates a comment.
        /// </remarks>
        /// <exception cref="Todoist.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="commentId"></param>
        /// <param name="xRequestId"> (optional)</param>
        /// <param name="commentUpdate"> (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse</returns>
        System.Threading.Tasks.Task<ApiResponse<Object>> UpdateCommentWithHttpInfoAsync(long commentId, string xRequestId = default(string), CommentUpdate commentUpdate = default(CommentUpdate), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        #endregion Asynchronous Operations
    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface ICommentsApi : ICommentsApiSync, ICommentsApiAsync
    {

    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    internal partial class CommentsApi : IDisposable, ICommentsApi
    {
        private Todoist.Client.ExceptionFactory _exceptionFactory = (name, response) => null;

        /// <summary>
        /// Initializes a new instance of the <see cref="CommentsApi"/> class.
        /// **IMPORTANT** This will also create an instance of HttpClient, which is less than ideal.
        /// It's better to reuse the <see href="https://docs.microsoft.com/en-us/dotnet/architecture/microservices/implement-resilient-applications/use-httpclientfactory-to-implement-resilient-http-requests#issues-with-the-original-httpclient-class-available-in-net">HttpClient and HttpClientHandler</see>.
        /// </summary>
        /// <returns></returns>
        public CommentsApi() : this((string)null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CommentsApi"/> class.
        /// **IMPORTANT** This will also create an instance of HttpClient, which is less than ideal.
        /// It's better to reuse the <see href="https://docs.microsoft.com/en-us/dotnet/architecture/microservices/implement-resilient-applications/use-httpclientfactory-to-implement-resilient-http-requests#issues-with-the-original-httpclient-class-available-in-net">HttpClient and HttpClientHandler</see>.
        /// </summary>
        /// <param name="basePath">The target service's base path in URL format.</param>
        /// <exception cref="ArgumentException"></exception>
        /// <returns></returns>
        public CommentsApi(string basePath)
        {
            this.Configuration = Todoist.Client.Configuration.MergeConfigurations(
                Todoist.Client.GlobalConfiguration.Instance,
                new Todoist.Client.Configuration { BasePath = basePath }
            );
            this.ApiClient = new Todoist.Client.ApiClient(this.Configuration.BasePath);
            this.Client =  this.ApiClient;
            this.AsynchronousClient = this.ApiClient;
            this.ExceptionFactory = Todoist.Client.Configuration.DefaultExceptionFactory;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CommentsApi"/> class using Configuration object.
        /// **IMPORTANT** This will also create an instance of HttpClient, which is less than ideal.
        /// It's better to reuse the <see href="https://docs.microsoft.com/en-us/dotnet/architecture/microservices/implement-resilient-applications/use-httpclientfactory-to-implement-resilient-http-requests#issues-with-the-original-httpclient-class-available-in-net">HttpClient and HttpClientHandler</see>.
        /// </summary>
        /// <param name="configuration">An instance of Configuration.</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <returns></returns>
        public CommentsApi(Todoist.Client.Configuration configuration)
        {
            if (configuration == null) throw new ArgumentNullException("configuration");

            this.Configuration = Todoist.Client.Configuration.MergeConfigurations(
                Todoist.Client.GlobalConfiguration.Instance,
                configuration
            );
            this.ApiClient = new Todoist.Client.ApiClient(this.Configuration.BasePath);
            this.Client = this.ApiClient;
            this.AsynchronousClient = this.ApiClient;
            ExceptionFactory = Todoist.Client.Configuration.DefaultExceptionFactory;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CommentsApi"/> class.
        /// </summary>
        /// <param name="client">An instance of HttpClient.</param>
        /// <param name="handler">An optional instance of HttpClientHandler that is used by HttpClient.</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <returns></returns>
        /// <remarks>
        /// Some configuration settings will not be applied without passing an HttpClientHandler.
        /// The features affected are: Setting and Retrieving Cookies, Client Certificates, Proxy settings.
        /// </remarks>
        public CommentsApi(HttpClient client, HttpClientHandler handler = null) : this(client, (string)null, handler)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CommentsApi"/> class.
        /// </summary>
        /// <param name="client">An instance of HttpClient.</param>
        /// <param name="basePath">The target service's base path in URL format.</param>
        /// <param name="handler">An optional instance of HttpClientHandler that is used by HttpClient.</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        /// <returns></returns>
        /// <remarks>
        /// Some configuration settings will not be applied without passing an HttpClientHandler.
        /// The features affected are: Setting and Retrieving Cookies, Client Certificates, Proxy settings.
        /// </remarks>
        public CommentsApi(HttpClient client, string basePath, HttpClientHandler handler = null)
        {
            if (client == null) throw new ArgumentNullException("client");

            this.Configuration = Todoist.Client.Configuration.MergeConfigurations(
                Todoist.Client.GlobalConfiguration.Instance,
                new Todoist.Client.Configuration { BasePath = basePath }
            );
            this.ApiClient = new Todoist.Client.ApiClient(client, this.Configuration.BasePath, handler);
            this.Client =  this.ApiClient;
            this.AsynchronousClient = this.ApiClient;
            this.ExceptionFactory = Todoist.Client.Configuration.DefaultExceptionFactory;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CommentsApi"/> class using Configuration object.
        /// </summary>
        /// <param name="client">An instance of HttpClient.</param>
        /// <param name="configuration">An instance of Configuration.</param>
        /// <param name="handler">An optional instance of HttpClientHandler that is used by HttpClient.</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <returns></returns>
        /// <remarks>
        /// Some configuration settings will not be applied without passing an HttpClientHandler.
        /// The features affected are: Setting and Retrieving Cookies, Client Certificates, Proxy settings.
        /// </remarks>
        public CommentsApi(HttpClient client, Todoist.Client.Configuration configuration, HttpClientHandler handler = null)
        {
            if (configuration == null) throw new ArgumentNullException("configuration");
            if (client == null) throw new ArgumentNullException("client");

            this.Configuration = Todoist.Client.Configuration.MergeConfigurations(
                Todoist.Client.GlobalConfiguration.Instance,
                configuration
            );
            this.ApiClient = new Todoist.Client.ApiClient(client, this.Configuration.BasePath, handler);
            this.Client = this.ApiClient;
            this.AsynchronousClient = this.ApiClient;
            ExceptionFactory = Todoist.Client.Configuration.DefaultExceptionFactory;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CommentsApi"/> class
        /// using a Configuration object and client instance.
        /// </summary>
        /// <param name="client">The client interface for synchronous API access.</param>
        /// <param name="asyncClient">The client interface for asynchronous API access.</param>
        /// <param name="configuration">The configuration object.</param>
        /// <exception cref="ArgumentNullException"></exception>
        internal CommentsApi(Todoist.Client.ISynchronousClient client, Todoist.Client.IAsynchronousClient asyncClient, Todoist.Client.IReadableConfiguration configuration)
        {
            if (client == null) throw new ArgumentNullException("client");
            if (asyncClient == null) throw new ArgumentNullException("asyncClient");
            if (configuration == null) throw new ArgumentNullException("configuration");

            this.Client = client;
            this.AsynchronousClient = asyncClient;
            this.Configuration = configuration;
            this.ExceptionFactory = Todoist.Client.Configuration.DefaultExceptionFactory;
        }

        /// <summary>
        /// Disposes resources if they were created by us
        /// </summary>
        public void Dispose()
        {
            this.ApiClient?.Dispose();
        }

        /// <summary>
        /// Holds the ApiClient if created
        /// </summary>
        public Todoist.Client.ApiClient ApiClient { get; set; } = null;

        /// <summary>
        /// The client for accessing this underlying API asynchronously.
        /// </summary>
        public Todoist.Client.IAsynchronousClient AsynchronousClient { get; set; }

        /// <summary>
        /// The client for accessing this underlying API synchronously.
        /// </summary>
        public Todoist.Client.ISynchronousClient Client { get; set; }

        /// <summary>
        /// Gets the base path of the API client.
        /// </summary>
        /// <value>The base path</value>
        public string GetBasePath()
        {
            return this.Configuration.BasePath;
        }

        /// <summary>
        /// Gets or sets the configuration object
        /// </summary>
        /// <value>An instance of the Configuration</value>
        public Todoist.Client.IReadableConfiguration Configuration { get; set; }

        /// <summary>
        /// Provides a factory method hook for the creation of exceptions.
        /// </summary>
        public Todoist.Client.ExceptionFactory ExceptionFactory
        {
            get
            {
                if (_exceptionFactory != null && _exceptionFactory.GetInvocationList().Length > 1)
                {
                    throw new InvalidOperationException("Multicast delegate for ExceptionFactory is unsupported.");
                }
                return _exceptionFactory;
            }
            set { _exceptionFactory = value; }
        }

        /// <summary>
        /// Create a new comment
        /// </summary>
        /// <remarks>
        /// Creates a new comment on a project or task and returns it as a JSON object. Note that one of task_id or project_id arguments is required.
        /// </remarks>
        /// <exception cref="Todoist.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="xRequestId"> (optional)</param>
        /// <param name="newComment"> (optional)</param>
        /// <returns>Comment</returns>
        public Comment CreateComment(string xRequestId = default(string), NewComment newComment = default(NewComment))
        {
            Todoist.Client.ApiResponse<Comment> localVarResponse = CreateCommentWithHttpInfo(xRequestId, newComment);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Create a new comment
        /// </summary>
        /// <remarks>
        /// Creates a new comment on a project or task and returns it as a JSON object. Note that one of task_id or project_id arguments is required.
        /// </remarks>
        /// <exception cref="Todoist.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="xRequestId"> (optional)</param>
        /// <param name="newComment"> (optional)</param>
        /// <returns>ApiResponse of Comment</returns>
        public Todoist.Client.ApiResponse<Comment> CreateCommentWithHttpInfo(string xRequestId = default(string), NewComment newComment = default(NewComment))
        {
            Todoist.Client.RequestOptions localVarRequestOptions = new Todoist.Client.RequestOptions();

            string[] _contentTypes = new string[] {
                "application/json"
            };

            // to determine the Accept header
            string[] _accepts = new string[] {
                "application/json"
            };

            var localVarContentType = Todoist.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null) localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);

            var localVarAccept = Todoist.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null) localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);

            if (xRequestId != null)
            {
                localVarRequestOptions.HeaderParameters.Add("X-Request-Id", Todoist.Client.ClientUtils.ParameterToString(xRequestId)); // header parameter
            }
            localVarRequestOptions.Data = newComment;

            // authentication (OAuth) required
            // oauth required
            if (!string.IsNullOrEmpty(this.Configuration.AccessToken))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }

            // make the HTTP request
            var localVarResponse = this.Client.Post<Comment>("/comments", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("CreateComment", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// Create a new comment
        /// </summary>
        /// <remarks>
        /// Creates a new comment on a project or task and returns it as a JSON object. Note that one of task_id or project_id arguments is required.
        /// </remarks>
        /// <exception cref="Todoist.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="xRequestId"> (optional)</param>
        /// <param name="newComment"> (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of Comment</returns>
        public async System.Threading.Tasks.Task<Comment> CreateCommentAsync(string xRequestId = default(string), NewComment newComment = default(NewComment), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Todoist.Client.ApiResponse<Comment> localVarResponse = await CreateCommentWithHttpInfoAsync(xRequestId, newComment, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Create a new comment
        /// </summary>
        /// <remarks>
        /// Creates a new comment on a project or task and returns it as a JSON object. Note that one of task_id or project_id arguments is required.
        /// </remarks>
        /// <exception cref="Todoist.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="xRequestId"> (optional)</param>
        /// <param name="newComment"> (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (Comment)</returns>
        public async System.Threading.Tasks.Task<Todoist.Client.ApiResponse<Comment>> CreateCommentWithHttpInfoAsync(string xRequestId = default(string), NewComment newComment = default(NewComment), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {

            Todoist.Client.RequestOptions localVarRequestOptions = new Todoist.Client.RequestOptions();

            string[] _contentTypes = new string[] {
                "application/json"
            };

            // to determine the Accept header
            string[] _accepts = new string[] {
                "application/json"
            };


            var localVarContentType = Todoist.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null) localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);

            var localVarAccept = Todoist.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null) localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);

            if (xRequestId != null)
            {
                localVarRequestOptions.HeaderParameters.Add("X-Request-Id", Todoist.Client.ClientUtils.ParameterToString(xRequestId)); // header parameter
            }
            localVarRequestOptions.Data = newComment;

            // authentication (OAuth) required
            // oauth required
            if (!string.IsNullOrEmpty(this.Configuration.AccessToken))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }

            // make the HTTP request

            var localVarResponse = await this.AsynchronousClient.PostAsync<Comment>("/comments", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("CreateComment", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// Delete a comment
        /// </summary>
        /// <remarks>
        /// Deletes a comment.
        /// </remarks>
        /// <exception cref="Todoist.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="commentId"></param>
        /// <returns></returns>
        public void DeleteComment(long commentId)
        {
            DeleteCommentWithHttpInfo(commentId);
        }

        /// <summary>
        /// Delete a comment
        /// </summary>
        /// <remarks>
        /// Deletes a comment.
        /// </remarks>
        /// <exception cref="Todoist.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="commentId"></param>
        /// <returns>ApiResponse of Object(void)</returns>
        public Todoist.Client.ApiResponse<Object> DeleteCommentWithHttpInfo(long commentId)
        {
            Todoist.Client.RequestOptions localVarRequestOptions = new Todoist.Client.RequestOptions();

            string[] _contentTypes = new string[] {
            };

            // to determine the Accept header
            string[] _accepts = new string[] {
            };

            var localVarContentType = Todoist.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null) localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);

            var localVarAccept = Todoist.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null) localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);

            localVarRequestOptions.PathParameters.Add("commentId", Todoist.Client.ClientUtils.ParameterToString(commentId)); // path parameter

            // authentication (OAuth) required
            // oauth required
            if (!string.IsNullOrEmpty(this.Configuration.AccessToken))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }

            // make the HTTP request
            var localVarResponse = this.Client.Delete<Object>("/comments/{commentId}", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("DeleteComment", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// Delete a comment
        /// </summary>
        /// <remarks>
        /// Deletes a comment.
        /// </remarks>
        /// <exception cref="Todoist.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="commentId"></param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of void</returns>
        public async System.Threading.Tasks.Task DeleteCommentAsync(long commentId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            await DeleteCommentWithHttpInfoAsync(commentId, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Delete a comment
        /// </summary>
        /// <remarks>
        /// Deletes a comment.
        /// </remarks>
        /// <exception cref="Todoist.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="commentId"></param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse</returns>
        public async System.Threading.Tasks.Task<Todoist.Client.ApiResponse<Object>> DeleteCommentWithHttpInfoAsync(long commentId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {

            Todoist.Client.RequestOptions localVarRequestOptions = new Todoist.Client.RequestOptions();

            string[] _contentTypes = new string[] {
            };

            // to determine the Accept header
            string[] _accepts = new string[] {
            };


            var localVarContentType = Todoist.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null) localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);

            var localVarAccept = Todoist.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null) localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);

            localVarRequestOptions.PathParameters.Add("commentId", Todoist.Client.ClientUtils.ParameterToString(commentId)); // path parameter

            // authentication (OAuth) required
            // oauth required
            if (!string.IsNullOrEmpty(this.Configuration.AccessToken))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }

            // make the HTTP request

            var localVarResponse = await this.AsynchronousClient.DeleteAsync<Object>("/comments/{commentId}", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("DeleteComment", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// Get a comment
        /// </summary>
        /// <remarks>
        /// Returns a single comment as a JSON object.
        /// </remarks>
        /// <exception cref="Todoist.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="commentId"></param>
        /// <returns>Comment</returns>
        public Comment GetComment(long commentId)
        {
            Todoist.Client.ApiResponse<Comment> localVarResponse = GetCommentWithHttpInfo(commentId);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Get a comment
        /// </summary>
        /// <remarks>
        /// Returns a single comment as a JSON object.
        /// </remarks>
        /// <exception cref="Todoist.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="commentId"></param>
        /// <returns>ApiResponse of Comment</returns>
        public Todoist.Client.ApiResponse<Comment> GetCommentWithHttpInfo(long commentId)
        {
            Todoist.Client.RequestOptions localVarRequestOptions = new Todoist.Client.RequestOptions();

            string[] _contentTypes = new string[] {
            };

            // to determine the Accept header
            string[] _accepts = new string[] {
                "application/json"
            };

            var localVarContentType = Todoist.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null) localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);

            var localVarAccept = Todoist.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null) localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);

            localVarRequestOptions.PathParameters.Add("commentId", Todoist.Client.ClientUtils.ParameterToString(commentId)); // path parameter

            // authentication (OAuth) required
            // oauth required
            if (!string.IsNullOrEmpty(this.Configuration.AccessToken))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }

            // make the HTTP request
            var localVarResponse = this.Client.Get<Comment>("/comments/{commentId}", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetComment", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// Get a comment
        /// </summary>
        /// <remarks>
        /// Returns a single comment as a JSON object.
        /// </remarks>
        /// <exception cref="Todoist.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="commentId"></param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of Comment</returns>
        public async System.Threading.Tasks.Task<Comment> GetCommentAsync(long commentId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Todoist.Client.ApiResponse<Comment> localVarResponse = await GetCommentWithHttpInfoAsync(commentId, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Get a comment
        /// </summary>
        /// <remarks>
        /// Returns a single comment as a JSON object.
        /// </remarks>
        /// <exception cref="Todoist.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="commentId"></param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (Comment)</returns>
        public async System.Threading.Tasks.Task<Todoist.Client.ApiResponse<Comment>> GetCommentWithHttpInfoAsync(long commentId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {

            Todoist.Client.RequestOptions localVarRequestOptions = new Todoist.Client.RequestOptions();

            string[] _contentTypes = new string[] {
            };

            // to determine the Accept header
            string[] _accepts = new string[] {
                "application/json"
            };


            var localVarContentType = Todoist.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null) localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);

            var localVarAccept = Todoist.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null) localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);

            localVarRequestOptions.PathParameters.Add("commentId", Todoist.Client.ClientUtils.ParameterToString(commentId)); // path parameter

            // authentication (OAuth) required
            // oauth required
            if (!string.IsNullOrEmpty(this.Configuration.AccessToken))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }

            // make the HTTP request

            var localVarResponse = await this.AsynchronousClient.GetAsync<Comment>("/comments/{commentId}", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetComment", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// Get all comments
        /// </summary>
        /// <remarks>
        /// Returns a JSON-encoded array of all comments for a given task_id or project_id. Note that one of task_id or project_id arguments is required.
        /// </remarks>
        /// <exception cref="Todoist.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="taskId"></param>
        /// <param name="projectId"> (optional)</param>
        /// <returns>List&lt;Comment&gt;</returns>
        public List<Comment> GetComments(long taskId, long? projectId = default(long?))
        {
            Todoist.Client.ApiResponse<List<Comment>> localVarResponse = GetCommentsWithHttpInfo(taskId, projectId);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Get all comments
        /// </summary>
        /// <remarks>
        /// Returns a JSON-encoded array of all comments for a given task_id or project_id. Note that one of task_id or project_id arguments is required.
        /// </remarks>
        /// <exception cref="Todoist.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="taskId"></param>
        /// <param name="projectId"> (optional)</param>
        /// <returns>ApiResponse of List&lt;Comment&gt;</returns>
        public Todoist.Client.ApiResponse<List<Comment>> GetCommentsWithHttpInfo(long taskId, long? projectId = default(long?))
        {
            Todoist.Client.RequestOptions localVarRequestOptions = new Todoist.Client.RequestOptions();

            string[] _contentTypes = new string[] {
            };

            // to determine the Accept header
            string[] _accepts = new string[] {
                "application/json"
            };

            var localVarContentType = Todoist.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null) localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);

            var localVarAccept = Todoist.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null) localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);

            if (projectId != null)
            {
                localVarRequestOptions.QueryParameters.Add(Todoist.Client.ClientUtils.ParameterToMultiMap("", "project_id", projectId));
            }
            localVarRequestOptions.QueryParameters.Add(Todoist.Client.ClientUtils.ParameterToMultiMap("", "task_id", taskId));

            // authentication (OAuth) required
            // oauth required
            if (!string.IsNullOrEmpty(this.Configuration.AccessToken))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }

            // make the HTTP request
            var localVarResponse = this.Client.Get<List<Comment>>("/comments", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetComments", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// Get all comments
        /// </summary>
        /// <remarks>
        /// Returns a JSON-encoded array of all comments for a given task_id or project_id. Note that one of task_id or project_id arguments is required.
        /// </remarks>
        /// <exception cref="Todoist.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="taskId"></param>
        /// <param name="projectId"> (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of List&lt;Comment&gt;</returns>
        public async System.Threading.Tasks.Task<List<Comment>> GetCommentsAsync(long taskId, long? projectId = default(long?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Todoist.Client.ApiResponse<List<Comment>> localVarResponse = await GetCommentsWithHttpInfoAsync(taskId, projectId, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Get all comments
        /// </summary>
        /// <remarks>
        /// Returns a JSON-encoded array of all comments for a given task_id or project_id. Note that one of task_id or project_id arguments is required.
        /// </remarks>
        /// <exception cref="Todoist.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="taskId"></param>
        /// <param name="projectId"> (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (List&lt;Comment&gt;)</returns>
        public async System.Threading.Tasks.Task<Todoist.Client.ApiResponse<List<Comment>>> GetCommentsWithHttpInfoAsync(long taskId, long? projectId = default(long?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {

            Todoist.Client.RequestOptions localVarRequestOptions = new Todoist.Client.RequestOptions();

            string[] _contentTypes = new string[] {
            };

            // to determine the Accept header
            string[] _accepts = new string[] {
                "application/json"
            };


            var localVarContentType = Todoist.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null) localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);

            var localVarAccept = Todoist.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null) localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);

            if (projectId != null)
            {
                localVarRequestOptions.QueryParameters.Add(Todoist.Client.ClientUtils.ParameterToMultiMap("", "project_id", projectId));
            }
            localVarRequestOptions.QueryParameters.Add(Todoist.Client.ClientUtils.ParameterToMultiMap("", "task_id", taskId));

            // authentication (OAuth) required
            // oauth required
            if (!string.IsNullOrEmpty(this.Configuration.AccessToken))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }

            // make the HTTP request

            var localVarResponse = await this.AsynchronousClient.GetAsync<List<Comment>>("/comments", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetComments", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// Update a comment
        /// </summary>
        /// <remarks>
        /// Updates a comment.
        /// </remarks>
        /// <exception cref="Todoist.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="commentId"></param>
        /// <param name="xRequestId"> (optional)</param>
        /// <param name="commentUpdate"> (optional)</param>
        /// <returns></returns>
        public void UpdateComment(long commentId, string xRequestId = default(string), CommentUpdate commentUpdate = default(CommentUpdate))
        {
            UpdateCommentWithHttpInfo(commentId, xRequestId, commentUpdate);
        }

        /// <summary>
        /// Update a comment
        /// </summary>
        /// <remarks>
        /// Updates a comment.
        /// </remarks>
        /// <exception cref="Todoist.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="commentId"></param>
        /// <param name="xRequestId"> (optional)</param>
        /// <param name="commentUpdate"> (optional)</param>
        /// <returns>ApiResponse of Object(void)</returns>
        public Todoist.Client.ApiResponse<Object> UpdateCommentWithHttpInfo(long commentId, string xRequestId = default(string), CommentUpdate commentUpdate = default(CommentUpdate))
        {
            Todoist.Client.RequestOptions localVarRequestOptions = new Todoist.Client.RequestOptions();

            string[] _contentTypes = new string[] {
                "application/json"
            };

            // to determine the Accept header
            string[] _accepts = new string[] {
            };

            var localVarContentType = Todoist.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null) localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);

            var localVarAccept = Todoist.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null) localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);

            localVarRequestOptions.PathParameters.Add("commentId", Todoist.Client.ClientUtils.ParameterToString(commentId)); // path parameter
            if (xRequestId != null)
            {
                localVarRequestOptions.HeaderParameters.Add("X-Request-Id", Todoist.Client.ClientUtils.ParameterToString(xRequestId)); // header parameter
            }
            localVarRequestOptions.Data = commentUpdate;

            // authentication (OAuth) required
            // oauth required
            if (!string.IsNullOrEmpty(this.Configuration.AccessToken))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }

            // make the HTTP request
            var localVarResponse = this.Client.Post<Object>("/comments/{commentId}", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("UpdateComment", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// Update a comment
        /// </summary>
        /// <remarks>
        /// Updates a comment.
        /// </remarks>
        /// <exception cref="Todoist.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="commentId"></param>
        /// <param name="xRequestId"> (optional)</param>
        /// <param name="commentUpdate"> (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of void</returns>
        public async System.Threading.Tasks.Task UpdateCommentAsync(long commentId, string xRequestId = default(string), CommentUpdate commentUpdate = default(CommentUpdate), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            await UpdateCommentWithHttpInfoAsync(commentId, xRequestId, commentUpdate, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Update a comment
        /// </summary>
        /// <remarks>
        /// Updates a comment.
        /// </remarks>
        /// <exception cref="Todoist.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="commentId"></param>
        /// <param name="xRequestId"> (optional)</param>
        /// <param name="commentUpdate"> (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse</returns>
        public async System.Threading.Tasks.Task<Todoist.Client.ApiResponse<Object>> UpdateCommentWithHttpInfoAsync(long commentId, string xRequestId = default(string), CommentUpdate commentUpdate = default(CommentUpdate), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {

            Todoist.Client.RequestOptions localVarRequestOptions = new Todoist.Client.RequestOptions();

            string[] _contentTypes = new string[] {
                "application/json"
            };

            // to determine the Accept header
            string[] _accepts = new string[] {
            };


            var localVarContentType = Todoist.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null) localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);

            var localVarAccept = Todoist.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null) localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);

            localVarRequestOptions.PathParameters.Add("commentId", Todoist.Client.ClientUtils.ParameterToString(commentId)); // path parameter
            if (xRequestId != null)
            {
                localVarRequestOptions.HeaderParameters.Add("X-Request-Id", Todoist.Client.ClientUtils.ParameterToString(xRequestId)); // header parameter
            }
            localVarRequestOptions.Data = commentUpdate;

            // authentication (OAuth) required
            // oauth required
            if (!string.IsNullOrEmpty(this.Configuration.AccessToken))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }

            // make the HTTP request

            var localVarResponse = await this.AsynchronousClient.PostAsync<Object>("/comments/{commentId}", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("UpdateComment", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

    }
}
