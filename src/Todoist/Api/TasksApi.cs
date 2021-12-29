using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mime;
using Todoist.Client;
using Todoist.Models;

namespace Todoist
{
    using Todoist.Api;
    public partial interface ITodoistClient
    {
        ITasksApi Tasks { get; }
    }
    public partial class TodoistClient
    {
        private ITasksApi _tasks;

        public ITasksApi Tasks =>
            _tasks ?? (_tasks = CreateTasksApi());

        private TasksApi CreateTasksApi()
        {
            if (_client != null && _configuration != null && _handler != null)
                return new TasksApi(_client, _configuration, _handler); 
            if (_client != null && _basePath != null && _handler != null)
                return new TasksApi(_client, _basePath, _handler); 
            if (_client != null &&  _handler != null)
                return new TasksApi(_client, _handler); 
            if (_configuration != null)
                return new TasksApi(_configuration); 
            if (_basePath != null)
                return new TasksApi(_basePath); 
            return new TasksApi();
        }
    }
}

namespace Todoist.Api
{

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface ITasksApiSync : IApiAccessor
    {
        #region Synchronous Operations
        /// <summary>
        /// Close a task
        /// </summary>
        /// <remarks>
        /// Closes a task.
        /// </remarks>
        /// <exception cref="Todoist.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="taskId"></param>
        /// <param name="xRequestId"> (optional)</param>
        /// <returns></returns>
        void CloseTask(long taskId, string xRequestId = default(string));

        /// <summary>
        /// Close a task
        /// </summary>
        /// <remarks>
        /// Closes a task.
        /// </remarks>
        /// <exception cref="Todoist.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="taskId"></param>
        /// <param name="xRequestId"> (optional)</param>
        /// <returns>ApiResponse of Object(void)</returns>
        ApiResponse<Object> CloseTaskWithHttpInfo(long taskId, string xRequestId = default(string));
        /// <summary>
        /// Create a new task
        /// </summary>
        /// <remarks>
        /// Creates a new task and returns it as a JSON object.
        /// </remarks>
        /// <exception cref="Todoist.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="xRequestId"> (optional)</param>
        /// <param name="newTask"> (optional)</param>
        /// <returns>Task</returns>
        Task CreateTask(string xRequestId = default(string), NewTask newTask = default(NewTask));

        /// <summary>
        /// Create a new task
        /// </summary>
        /// <remarks>
        /// Creates a new task and returns it as a JSON object.
        /// </remarks>
        /// <exception cref="Todoist.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="xRequestId"> (optional)</param>
        /// <param name="newTask"> (optional)</param>
        /// <returns>ApiResponse of Task</returns>
        ApiResponse<Task> CreateTaskWithHttpInfo(string xRequestId = default(string), NewTask newTask = default(NewTask));
        /// <summary>
        /// Delete a task
        /// </summary>
        /// <remarks>
        /// Delete a task.
        /// </remarks>
        /// <exception cref="Todoist.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="taskId"></param>
        /// <returns></returns>
        void DeleteTask(long taskId);

        /// <summary>
        /// Delete a task
        /// </summary>
        /// <remarks>
        /// Delete a task.
        /// </remarks>
        /// <exception cref="Todoist.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="taskId"></param>
        /// <returns>ApiResponse of Object(void)</returns>
        ApiResponse<Object> DeleteTaskWithHttpInfo(long taskId);
        /// <summary>
        /// Get an active task
        /// </summary>
        /// <remarks>
        /// Returns a single active (non-completed) task by ID as a JSON object.
        /// </remarks>
        /// <exception cref="Todoist.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="taskId"></param>
        /// <returns>Task</returns>
        Task GetTask(long taskId);

        /// <summary>
        /// Get an active task
        /// </summary>
        /// <remarks>
        /// Returns a single active (non-completed) task by ID as a JSON object.
        /// </remarks>
        /// <exception cref="Todoist.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="taskId"></param>
        /// <returns>ApiResponse of Task</returns>
        ApiResponse<Task> GetTaskWithHttpInfo(long taskId);
        /// <summary>
        /// Get active tasks
        /// </summary>
        /// <remarks>
        /// Returns a JSON-encoded array containing all active tasks.
        /// </remarks>
        /// <exception cref="Todoist.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId"> (optional)</param>
        /// <param name="sectionId"> (optional)</param>
        /// <param name="labelId"> (optional)</param>
        /// <param name="filter"> (optional)</param>
        /// <param name="lang"> (optional)</param>
        /// <param name="ids"> (optional)</param>
        /// <returns>List&lt;Task&gt;</returns>
        List<Task> GetTasks(long? projectId = default(long?), int? sectionId = default(int?), long? labelId = default(long?), string filter = default(string), string lang = default(string), List<long> ids = default(List<long>));

        /// <summary>
        /// Get active tasks
        /// </summary>
        /// <remarks>
        /// Returns a JSON-encoded array containing all active tasks.
        /// </remarks>
        /// <exception cref="Todoist.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId"> (optional)</param>
        /// <param name="sectionId"> (optional)</param>
        /// <param name="labelId"> (optional)</param>
        /// <param name="filter"> (optional)</param>
        /// <param name="lang"> (optional)</param>
        /// <param name="ids"> (optional)</param>
        /// <returns>ApiResponse of List&lt;Task&gt;</returns>
        ApiResponse<List<Task>> GetTasksWithHttpInfo(long? projectId = default(long?), int? sectionId = default(int?), long? labelId = default(long?), string filter = default(string), string lang = default(string), List<long> ids = default(List<long>));
        /// <summary>
        /// Reopen a task
        /// </summary>
        /// <remarks>
        /// Reopens a task.
        /// </remarks>
        /// <exception cref="Todoist.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="taskId"></param>
        /// <param name="xRequestId"> (optional)</param>
        /// <returns></returns>
        void ReopenTask(long taskId, string xRequestId = default(string));

        /// <summary>
        /// Reopen a task
        /// </summary>
        /// <remarks>
        /// Reopens a task.
        /// </remarks>
        /// <exception cref="Todoist.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="taskId"></param>
        /// <param name="xRequestId"> (optional)</param>
        /// <returns>ApiResponse of Object(void)</returns>
        ApiResponse<Object> ReopenTaskWithHttpInfo(long taskId, string xRequestId = default(string));
        /// <summary>
        /// Update a task
        /// </summary>
        /// <remarks>
        /// Update a task.
        /// </remarks>
        /// <exception cref="Todoist.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="taskId"></param>
        /// <param name="xRequestId"> (optional)</param>
        /// <param name="taskUpdate"> (optional)</param>
        /// <returns></returns>
        void UpdateTask(long taskId, string xRequestId = default(string), TaskUpdate taskUpdate = default(TaskUpdate));

        /// <summary>
        /// Update a task
        /// </summary>
        /// <remarks>
        /// Update a task.
        /// </remarks>
        /// <exception cref="Todoist.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="taskId"></param>
        /// <param name="xRequestId"> (optional)</param>
        /// <param name="taskUpdate"> (optional)</param>
        /// <returns>ApiResponse of Object(void)</returns>
        ApiResponse<Object> UpdateTaskWithHttpInfo(long taskId, string xRequestId = default(string), TaskUpdate taskUpdate = default(TaskUpdate));
        #endregion Synchronous Operations
    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface ITasksApiAsync : IApiAccessor
    {
        #region Asynchronous Operations
        /// <summary>
        /// Close a task
        /// </summary>
        /// <remarks>
        /// Closes a task.
        /// </remarks>
        /// <exception cref="Todoist.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="taskId"></param>
        /// <param name="xRequestId"> (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of void</returns>
        System.Threading.Tasks.Task CloseTaskAsync(long taskId, string xRequestId = default(string), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// Close a task
        /// </summary>
        /// <remarks>
        /// Closes a task.
        /// </remarks>
        /// <exception cref="Todoist.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="taskId"></param>
        /// <param name="xRequestId"> (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse</returns>
        System.Threading.Tasks.Task<ApiResponse<Object>> CloseTaskWithHttpInfoAsync(long taskId, string xRequestId = default(string), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// Create a new task
        /// </summary>
        /// <remarks>
        /// Creates a new task and returns it as a JSON object.
        /// </remarks>
        /// <exception cref="Todoist.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="xRequestId"> (optional)</param>
        /// <param name="newTask"> (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of Task</returns>
        System.Threading.Tasks.Task<Task> CreateTaskAsync(string xRequestId = default(string), NewTask newTask = default(NewTask), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// Create a new task
        /// </summary>
        /// <remarks>
        /// Creates a new task and returns it as a JSON object.
        /// </remarks>
        /// <exception cref="Todoist.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="xRequestId"> (optional)</param>
        /// <param name="newTask"> (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (Task)</returns>
        System.Threading.Tasks.Task<ApiResponse<Task>> CreateTaskWithHttpInfoAsync(string xRequestId = default(string), NewTask newTask = default(NewTask), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// Delete a task
        /// </summary>
        /// <remarks>
        /// Delete a task.
        /// </remarks>
        /// <exception cref="Todoist.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="taskId"></param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of void</returns>
        System.Threading.Tasks.Task DeleteTaskAsync(long taskId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// Delete a task
        /// </summary>
        /// <remarks>
        /// Delete a task.
        /// </remarks>
        /// <exception cref="Todoist.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="taskId"></param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse</returns>
        System.Threading.Tasks.Task<ApiResponse<Object>> DeleteTaskWithHttpInfoAsync(long taskId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// Get an active task
        /// </summary>
        /// <remarks>
        /// Returns a single active (non-completed) task by ID as a JSON object.
        /// </remarks>
        /// <exception cref="Todoist.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="taskId"></param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of Task</returns>
        System.Threading.Tasks.Task<Task> GetTaskAsync(long taskId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// Get an active task
        /// </summary>
        /// <remarks>
        /// Returns a single active (non-completed) task by ID as a JSON object.
        /// </remarks>
        /// <exception cref="Todoist.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="taskId"></param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (Task)</returns>
        System.Threading.Tasks.Task<ApiResponse<Task>> GetTaskWithHttpInfoAsync(long taskId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// Get active tasks
        /// </summary>
        /// <remarks>
        /// Returns a JSON-encoded array containing all active tasks.
        /// </remarks>
        /// <exception cref="Todoist.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId"> (optional)</param>
        /// <param name="sectionId"> (optional)</param>
        /// <param name="labelId"> (optional)</param>
        /// <param name="filter"> (optional)</param>
        /// <param name="lang"> (optional)</param>
        /// <param name="ids"> (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of List&lt;Task&gt;</returns>
        System.Threading.Tasks.Task<List<Task>> GetTasksAsync(long? projectId = default(long?), int? sectionId = default(int?), long? labelId = default(long?), string filter = default(string), string lang = default(string), List<long> ids = default(List<long>), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// Get active tasks
        /// </summary>
        /// <remarks>
        /// Returns a JSON-encoded array containing all active tasks.
        /// </remarks>
        /// <exception cref="Todoist.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId"> (optional)</param>
        /// <param name="sectionId"> (optional)</param>
        /// <param name="labelId"> (optional)</param>
        /// <param name="filter"> (optional)</param>
        /// <param name="lang"> (optional)</param>
        /// <param name="ids"> (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (List&lt;Task&gt;)</returns>
        System.Threading.Tasks.Task<ApiResponse<List<Task>>> GetTasksWithHttpInfoAsync(long? projectId = default(long?), int? sectionId = default(int?), long? labelId = default(long?), string filter = default(string), string lang = default(string), List<long> ids = default(List<long>), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// Reopen a task
        /// </summary>
        /// <remarks>
        /// Reopens a task.
        /// </remarks>
        /// <exception cref="Todoist.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="taskId"></param>
        /// <param name="xRequestId"> (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of void</returns>
        System.Threading.Tasks.Task ReopenTaskAsync(long taskId, string xRequestId = default(string), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// Reopen a task
        /// </summary>
        /// <remarks>
        /// Reopens a task.
        /// </remarks>
        /// <exception cref="Todoist.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="taskId"></param>
        /// <param name="xRequestId"> (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse</returns>
        System.Threading.Tasks.Task<ApiResponse<Object>> ReopenTaskWithHttpInfoAsync(long taskId, string xRequestId = default(string), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// Update a task
        /// </summary>
        /// <remarks>
        /// Update a task.
        /// </remarks>
        /// <exception cref="Todoist.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="taskId"></param>
        /// <param name="xRequestId"> (optional)</param>
        /// <param name="taskUpdate"> (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of void</returns>
        System.Threading.Tasks.Task UpdateTaskAsync(long taskId, string xRequestId = default(string), TaskUpdate taskUpdate = default(TaskUpdate), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// Update a task
        /// </summary>
        /// <remarks>
        /// Update a task.
        /// </remarks>
        /// <exception cref="Todoist.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="taskId"></param>
        /// <param name="xRequestId"> (optional)</param>
        /// <param name="taskUpdate"> (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse</returns>
        System.Threading.Tasks.Task<ApiResponse<Object>> UpdateTaskWithHttpInfoAsync(long taskId, string xRequestId = default(string), TaskUpdate taskUpdate = default(TaskUpdate), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        #endregion Asynchronous Operations
    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface ITasksApi : ITasksApiSync, ITasksApiAsync
    {

    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    internal partial class TasksApi : IDisposable, ITasksApi
    {
        private Todoist.Client.ExceptionFactory _exceptionFactory = (name, response) => null;

        /// <summary>
        /// Initializes a new instance of the <see cref="TasksApi"/> class.
        /// **IMPORTANT** This will also create an instance of HttpClient, which is less than ideal.
        /// It's better to reuse the <see href="https://docs.microsoft.com/en-us/dotnet/architecture/microservices/implement-resilient-applications/use-httpclientfactory-to-implement-resilient-http-requests#issues-with-the-original-httpclient-class-available-in-net">HttpClient and HttpClientHandler</see>.
        /// </summary>
        /// <returns></returns>
        public TasksApi() : this((string)null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TasksApi"/> class.
        /// **IMPORTANT** This will also create an instance of HttpClient, which is less than ideal.
        /// It's better to reuse the <see href="https://docs.microsoft.com/en-us/dotnet/architecture/microservices/implement-resilient-applications/use-httpclientfactory-to-implement-resilient-http-requests#issues-with-the-original-httpclient-class-available-in-net">HttpClient and HttpClientHandler</see>.
        /// </summary>
        /// <param name="basePath">The target service's base path in URL format.</param>
        /// <exception cref="ArgumentException"></exception>
        /// <returns></returns>
        public TasksApi(string basePath)
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
        /// Initializes a new instance of the <see cref="TasksApi"/> class using Configuration object.
        /// **IMPORTANT** This will also create an instance of HttpClient, which is less than ideal.
        /// It's better to reuse the <see href="https://docs.microsoft.com/en-us/dotnet/architecture/microservices/implement-resilient-applications/use-httpclientfactory-to-implement-resilient-http-requests#issues-with-the-original-httpclient-class-available-in-net">HttpClient and HttpClientHandler</see>.
        /// </summary>
        /// <param name="configuration">An instance of Configuration.</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <returns></returns>
        public TasksApi(Todoist.Client.Configuration configuration)
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
        /// Initializes a new instance of the <see cref="TasksApi"/> class.
        /// </summary>
        /// <param name="client">An instance of HttpClient.</param>
        /// <param name="handler">An optional instance of HttpClientHandler that is used by HttpClient.</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <returns></returns>
        /// <remarks>
        /// Some configuration settings will not be applied without passing an HttpClientHandler.
        /// The features affected are: Setting and Retrieving Cookies, Client Certificates, Proxy settings.
        /// </remarks>
        public TasksApi(HttpClient client, HttpClientHandler handler = null) : this(client, (string)null, handler)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TasksApi"/> class.
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
        public TasksApi(HttpClient client, string basePath, HttpClientHandler handler = null)
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
        /// Initializes a new instance of the <see cref="TasksApi"/> class using Configuration object.
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
        public TasksApi(HttpClient client, Todoist.Client.Configuration configuration, HttpClientHandler handler = null)
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
        /// Initializes a new instance of the <see cref="TasksApi"/> class
        /// using a Configuration object and client instance.
        /// </summary>
        /// <param name="client">The client interface for synchronous API access.</param>
        /// <param name="asyncClient">The client interface for asynchronous API access.</param>
        /// <param name="configuration">The configuration object.</param>
        /// <exception cref="ArgumentNullException"></exception>
        internal TasksApi(Todoist.Client.ISynchronousClient client, Todoist.Client.IAsynchronousClient asyncClient, Todoist.Client.IReadableConfiguration configuration)
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
        /// Close a task
        /// </summary>
        /// <remarks>
        /// Closes a task.
        /// </remarks>
        /// <exception cref="Todoist.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="taskId"></param>
        /// <param name="xRequestId"> (optional)</param>
        /// <returns></returns>
        public void CloseTask(long taskId, string xRequestId = default(string))
        {
            CloseTaskWithHttpInfo(taskId, xRequestId);
        }

        /// <summary>
        /// Close a task
        /// </summary>
        /// <remarks>
        /// Closes a task.
        /// </remarks>
        /// <exception cref="Todoist.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="taskId"></param>
        /// <param name="xRequestId"> (optional)</param>
        /// <returns>ApiResponse of Object(void)</returns>
        public Todoist.Client.ApiResponse<Object> CloseTaskWithHttpInfo(long taskId, string xRequestId = default(string))
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

            localVarRequestOptions.PathParameters.Add("taskId", Todoist.Client.ClientUtils.ParameterToString(taskId)); // path parameter
            if (xRequestId != null)
            {
                localVarRequestOptions.HeaderParameters.Add("X-Request-Id", Todoist.Client.ClientUtils.ParameterToString(xRequestId)); // header parameter
            }

            // authentication (OAuth) required
            // oauth required
            if (!string.IsNullOrEmpty(this.Configuration.AccessToken))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }

            // make the HTTP request
            var localVarResponse = this.Client.Post<Object>("/tasks/{taskId}/close", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("CloseTask", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// Close a task
        /// </summary>
        /// <remarks>
        /// Closes a task.
        /// </remarks>
        /// <exception cref="Todoist.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="taskId"></param>
        /// <param name="xRequestId"> (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of void</returns>
        public async System.Threading.Tasks.Task CloseTaskAsync(long taskId, string xRequestId = default(string), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            await CloseTaskWithHttpInfoAsync(taskId, xRequestId, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Close a task
        /// </summary>
        /// <remarks>
        /// Closes a task.
        /// </remarks>
        /// <exception cref="Todoist.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="taskId"></param>
        /// <param name="xRequestId"> (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse</returns>
        public async System.Threading.Tasks.Task<Todoist.Client.ApiResponse<Object>> CloseTaskWithHttpInfoAsync(long taskId, string xRequestId = default(string), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
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

            localVarRequestOptions.PathParameters.Add("taskId", Todoist.Client.ClientUtils.ParameterToString(taskId)); // path parameter
            if (xRequestId != null)
            {
                localVarRequestOptions.HeaderParameters.Add("X-Request-Id", Todoist.Client.ClientUtils.ParameterToString(xRequestId)); // header parameter
            }

            // authentication (OAuth) required
            // oauth required
            if (!string.IsNullOrEmpty(this.Configuration.AccessToken))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }

            // make the HTTP request

            var localVarResponse = await this.AsynchronousClient.PostAsync<Object>("/tasks/{taskId}/close", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("CloseTask", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// Create a new task
        /// </summary>
        /// <remarks>
        /// Creates a new task and returns it as a JSON object.
        /// </remarks>
        /// <exception cref="Todoist.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="xRequestId"> (optional)</param>
        /// <param name="newTask"> (optional)</param>
        /// <returns>Task</returns>
        public Task CreateTask(string xRequestId = default(string), NewTask newTask = default(NewTask))
        {
            Todoist.Client.ApiResponse<Task> localVarResponse = CreateTaskWithHttpInfo(xRequestId, newTask);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Create a new task
        /// </summary>
        /// <remarks>
        /// Creates a new task and returns it as a JSON object.
        /// </remarks>
        /// <exception cref="Todoist.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="xRequestId"> (optional)</param>
        /// <param name="newTask"> (optional)</param>
        /// <returns>ApiResponse of Task</returns>
        public Todoist.Client.ApiResponse<Task> CreateTaskWithHttpInfo(string xRequestId = default(string), NewTask newTask = default(NewTask))
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
            localVarRequestOptions.Data = newTask;

            // authentication (OAuth) required
            // oauth required
            if (!string.IsNullOrEmpty(this.Configuration.AccessToken))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }

            // make the HTTP request
            var localVarResponse = this.Client.Post<Task>("/tasks", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("CreateTask", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// Create a new task
        /// </summary>
        /// <remarks>
        /// Creates a new task and returns it as a JSON object.
        /// </remarks>
        /// <exception cref="Todoist.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="xRequestId"> (optional)</param>
        /// <param name="newTask"> (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of Task</returns>
        public async System.Threading.Tasks.Task<Task> CreateTaskAsync(string xRequestId = default(string), NewTask newTask = default(NewTask), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Todoist.Client.ApiResponse<Task> localVarResponse = await CreateTaskWithHttpInfoAsync(xRequestId, newTask, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Create a new task
        /// </summary>
        /// <remarks>
        /// Creates a new task and returns it as a JSON object.
        /// </remarks>
        /// <exception cref="Todoist.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="xRequestId"> (optional)</param>
        /// <param name="newTask"> (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (Task)</returns>
        public async System.Threading.Tasks.Task<Todoist.Client.ApiResponse<Task>> CreateTaskWithHttpInfoAsync(string xRequestId = default(string), NewTask newTask = default(NewTask), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
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
            localVarRequestOptions.Data = newTask;

            // authentication (OAuth) required
            // oauth required
            if (!string.IsNullOrEmpty(this.Configuration.AccessToken))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }

            // make the HTTP request

            var localVarResponse = await this.AsynchronousClient.PostAsync<Task>("/tasks", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("CreateTask", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// Delete a task
        /// </summary>
        /// <remarks>
        /// Delete a task.
        /// </remarks>
        /// <exception cref="Todoist.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="taskId"></param>
        /// <returns></returns>
        public void DeleteTask(long taskId)
        {
            DeleteTaskWithHttpInfo(taskId);
        }

        /// <summary>
        /// Delete a task
        /// </summary>
        /// <remarks>
        /// Delete a task.
        /// </remarks>
        /// <exception cref="Todoist.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="taskId"></param>
        /// <returns>ApiResponse of Object(void)</returns>
        public Todoist.Client.ApiResponse<Object> DeleteTaskWithHttpInfo(long taskId)
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

            localVarRequestOptions.PathParameters.Add("taskId", Todoist.Client.ClientUtils.ParameterToString(taskId)); // path parameter

            // authentication (OAuth) required
            // oauth required
            if (!string.IsNullOrEmpty(this.Configuration.AccessToken))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }

            // make the HTTP request
            var localVarResponse = this.Client.Delete<Object>("/tasks/{taskId}", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("DeleteTask", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// Delete a task
        /// </summary>
        /// <remarks>
        /// Delete a task.
        /// </remarks>
        /// <exception cref="Todoist.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="taskId"></param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of void</returns>
        public async System.Threading.Tasks.Task DeleteTaskAsync(long taskId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            await DeleteTaskWithHttpInfoAsync(taskId, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Delete a task
        /// </summary>
        /// <remarks>
        /// Delete a task.
        /// </remarks>
        /// <exception cref="Todoist.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="taskId"></param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse</returns>
        public async System.Threading.Tasks.Task<Todoist.Client.ApiResponse<Object>> DeleteTaskWithHttpInfoAsync(long taskId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
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

            localVarRequestOptions.PathParameters.Add("taskId", Todoist.Client.ClientUtils.ParameterToString(taskId)); // path parameter

            // authentication (OAuth) required
            // oauth required
            if (!string.IsNullOrEmpty(this.Configuration.AccessToken))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }

            // make the HTTP request

            var localVarResponse = await this.AsynchronousClient.DeleteAsync<Object>("/tasks/{taskId}", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("DeleteTask", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// Get an active task
        /// </summary>
        /// <remarks>
        /// Returns a single active (non-completed) task by ID as a JSON object.
        /// </remarks>
        /// <exception cref="Todoist.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="taskId"></param>
        /// <returns>Task</returns>
        public Task GetTask(long taskId)
        {
            Todoist.Client.ApiResponse<Task> localVarResponse = GetTaskWithHttpInfo(taskId);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Get an active task
        /// </summary>
        /// <remarks>
        /// Returns a single active (non-completed) task by ID as a JSON object.
        /// </remarks>
        /// <exception cref="Todoist.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="taskId"></param>
        /// <returns>ApiResponse of Task</returns>
        public Todoist.Client.ApiResponse<Task> GetTaskWithHttpInfo(long taskId)
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

            localVarRequestOptions.PathParameters.Add("taskId", Todoist.Client.ClientUtils.ParameterToString(taskId)); // path parameter

            // authentication (OAuth) required
            // oauth required
            if (!string.IsNullOrEmpty(this.Configuration.AccessToken))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }

            // make the HTTP request
            var localVarResponse = this.Client.Get<Task>("/tasks/{taskId}", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetTask", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// Get an active task
        /// </summary>
        /// <remarks>
        /// Returns a single active (non-completed) task by ID as a JSON object.
        /// </remarks>
        /// <exception cref="Todoist.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="taskId"></param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of Task</returns>
        public async System.Threading.Tasks.Task<Task> GetTaskAsync(long taskId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Todoist.Client.ApiResponse<Task> localVarResponse = await GetTaskWithHttpInfoAsync(taskId, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Get an active task
        /// </summary>
        /// <remarks>
        /// Returns a single active (non-completed) task by ID as a JSON object.
        /// </remarks>
        /// <exception cref="Todoist.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="taskId"></param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (Task)</returns>
        public async System.Threading.Tasks.Task<Todoist.Client.ApiResponse<Task>> GetTaskWithHttpInfoAsync(long taskId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
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

            localVarRequestOptions.PathParameters.Add("taskId", Todoist.Client.ClientUtils.ParameterToString(taskId)); // path parameter

            // authentication (OAuth) required
            // oauth required
            if (!string.IsNullOrEmpty(this.Configuration.AccessToken))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }

            // make the HTTP request

            var localVarResponse = await this.AsynchronousClient.GetAsync<Task>("/tasks/{taskId}", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetTask", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// Get active tasks
        /// </summary>
        /// <remarks>
        /// Returns a JSON-encoded array containing all active tasks.
        /// </remarks>
        /// <exception cref="Todoist.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId"> (optional)</param>
        /// <param name="sectionId"> (optional)</param>
        /// <param name="labelId"> (optional)</param>
        /// <param name="filter"> (optional)</param>
        /// <param name="lang"> (optional)</param>
        /// <param name="ids"> (optional)</param>
        /// <returns>List&lt;Task&gt;</returns>
        public List<Task> GetTasks(long? projectId = default(long?), int? sectionId = default(int?), long? labelId = default(long?), string filter = default(string), string lang = default(string), List<long> ids = default(List<long>))
        {
            Todoist.Client.ApiResponse<List<Task>> localVarResponse = GetTasksWithHttpInfo(projectId, sectionId, labelId, filter, lang, ids);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Get active tasks
        /// </summary>
        /// <remarks>
        /// Returns a JSON-encoded array containing all active tasks.
        /// </remarks>
        /// <exception cref="Todoist.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId"> (optional)</param>
        /// <param name="sectionId"> (optional)</param>
        /// <param name="labelId"> (optional)</param>
        /// <param name="filter"> (optional)</param>
        /// <param name="lang"> (optional)</param>
        /// <param name="ids"> (optional)</param>
        /// <returns>ApiResponse of List&lt;Task&gt;</returns>
        public Todoist.Client.ApiResponse<List<Task>> GetTasksWithHttpInfo(long? projectId = default(long?), int? sectionId = default(int?), long? labelId = default(long?), string filter = default(string), string lang = default(string), List<long> ids = default(List<long>))
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
            if (sectionId != null)
            {
                localVarRequestOptions.QueryParameters.Add(Todoist.Client.ClientUtils.ParameterToMultiMap("", "section_id", sectionId));
            }
            if (labelId != null)
            {
                localVarRequestOptions.QueryParameters.Add(Todoist.Client.ClientUtils.ParameterToMultiMap("", "label_id", labelId));
            }
            if (filter != null)
            {
                localVarRequestOptions.QueryParameters.Add(Todoist.Client.ClientUtils.ParameterToMultiMap("", "filter", filter));
            }
            if (lang != null)
            {
                localVarRequestOptions.QueryParameters.Add(Todoist.Client.ClientUtils.ParameterToMultiMap("", "lang", lang));
            }
            if (ids != null)
            {
                localVarRequestOptions.QueryParameters.Add(Todoist.Client.ClientUtils.ParameterToMultiMap("multi", "ids", ids));
            }

            // authentication (OAuth) required
            // oauth required
            if (!string.IsNullOrEmpty(this.Configuration.AccessToken))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }

            // make the HTTP request
            var localVarResponse = this.Client.Get<List<Task>>("/tasks", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetTasks", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// Get active tasks
        /// </summary>
        /// <remarks>
        /// Returns a JSON-encoded array containing all active tasks.
        /// </remarks>
        /// <exception cref="Todoist.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId"> (optional)</param>
        /// <param name="sectionId"> (optional)</param>
        /// <param name="labelId"> (optional)</param>
        /// <param name="filter"> (optional)</param>
        /// <param name="lang"> (optional)</param>
        /// <param name="ids"> (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of List&lt;Task&gt;</returns>
        public async System.Threading.Tasks.Task<List<Task>> GetTasksAsync(long? projectId = default(long?), int? sectionId = default(int?), long? labelId = default(long?), string filter = default(string), string lang = default(string), List<long> ids = default(List<long>), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Todoist.Client.ApiResponse<List<Task>> localVarResponse = await GetTasksWithHttpInfoAsync(projectId, sectionId, labelId, filter, lang, ids, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Get active tasks
        /// </summary>
        /// <remarks>
        /// Returns a JSON-encoded array containing all active tasks.
        /// </remarks>
        /// <exception cref="Todoist.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId"> (optional)</param>
        /// <param name="sectionId"> (optional)</param>
        /// <param name="labelId"> (optional)</param>
        /// <param name="filter"> (optional)</param>
        /// <param name="lang"> (optional)</param>
        /// <param name="ids"> (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (List&lt;Task&gt;)</returns>
        public async System.Threading.Tasks.Task<Todoist.Client.ApiResponse<List<Task>>> GetTasksWithHttpInfoAsync(long? projectId = default(long?), int? sectionId = default(int?), long? labelId = default(long?), string filter = default(string), string lang = default(string), List<long> ids = default(List<long>), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
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
            if (sectionId != null)
            {
                localVarRequestOptions.QueryParameters.Add(Todoist.Client.ClientUtils.ParameterToMultiMap("", "section_id", sectionId));
            }
            if (labelId != null)
            {
                localVarRequestOptions.QueryParameters.Add(Todoist.Client.ClientUtils.ParameterToMultiMap("", "label_id", labelId));
            }
            if (filter != null)
            {
                localVarRequestOptions.QueryParameters.Add(Todoist.Client.ClientUtils.ParameterToMultiMap("", "filter", filter));
            }
            if (lang != null)
            {
                localVarRequestOptions.QueryParameters.Add(Todoist.Client.ClientUtils.ParameterToMultiMap("", "lang", lang));
            }
            if (ids != null)
            {
                localVarRequestOptions.QueryParameters.Add(Todoist.Client.ClientUtils.ParameterToMultiMap("multi", "ids", ids));
            }

            // authentication (OAuth) required
            // oauth required
            if (!string.IsNullOrEmpty(this.Configuration.AccessToken))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }

            // make the HTTP request

            var localVarResponse = await this.AsynchronousClient.GetAsync<List<Task>>("/tasks", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetTasks", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// Reopen a task
        /// </summary>
        /// <remarks>
        /// Reopens a task.
        /// </remarks>
        /// <exception cref="Todoist.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="taskId"></param>
        /// <param name="xRequestId"> (optional)</param>
        /// <returns></returns>
        public void ReopenTask(long taskId, string xRequestId = default(string))
        {
            ReopenTaskWithHttpInfo(taskId, xRequestId);
        }

        /// <summary>
        /// Reopen a task
        /// </summary>
        /// <remarks>
        /// Reopens a task.
        /// </remarks>
        /// <exception cref="Todoist.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="taskId"></param>
        /// <param name="xRequestId"> (optional)</param>
        /// <returns>ApiResponse of Object(void)</returns>
        public Todoist.Client.ApiResponse<Object> ReopenTaskWithHttpInfo(long taskId, string xRequestId = default(string))
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

            localVarRequestOptions.PathParameters.Add("taskId", Todoist.Client.ClientUtils.ParameterToString(taskId)); // path parameter
            if (xRequestId != null)
            {
                localVarRequestOptions.HeaderParameters.Add("X-Request-Id", Todoist.Client.ClientUtils.ParameterToString(xRequestId)); // header parameter
            }

            // authentication (OAuth) required
            // oauth required
            if (!string.IsNullOrEmpty(this.Configuration.AccessToken))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }

            // make the HTTP request
            var localVarResponse = this.Client.Post<Object>("/tasks/{taskId}/reopen", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ReopenTask", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// Reopen a task
        /// </summary>
        /// <remarks>
        /// Reopens a task.
        /// </remarks>
        /// <exception cref="Todoist.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="taskId"></param>
        /// <param name="xRequestId"> (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of void</returns>
        public async System.Threading.Tasks.Task ReopenTaskAsync(long taskId, string xRequestId = default(string), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            await ReopenTaskWithHttpInfoAsync(taskId, xRequestId, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Reopen a task
        /// </summary>
        /// <remarks>
        /// Reopens a task.
        /// </remarks>
        /// <exception cref="Todoist.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="taskId"></param>
        /// <param name="xRequestId"> (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse</returns>
        public async System.Threading.Tasks.Task<Todoist.Client.ApiResponse<Object>> ReopenTaskWithHttpInfoAsync(long taskId, string xRequestId = default(string), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
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

            localVarRequestOptions.PathParameters.Add("taskId", Todoist.Client.ClientUtils.ParameterToString(taskId)); // path parameter
            if (xRequestId != null)
            {
                localVarRequestOptions.HeaderParameters.Add("X-Request-Id", Todoist.Client.ClientUtils.ParameterToString(xRequestId)); // header parameter
            }

            // authentication (OAuth) required
            // oauth required
            if (!string.IsNullOrEmpty(this.Configuration.AccessToken))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }

            // make the HTTP request

            var localVarResponse = await this.AsynchronousClient.PostAsync<Object>("/tasks/{taskId}/reopen", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ReopenTask", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// Update a task
        /// </summary>
        /// <remarks>
        /// Update a task.
        /// </remarks>
        /// <exception cref="Todoist.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="taskId"></param>
        /// <param name="xRequestId"> (optional)</param>
        /// <param name="taskUpdate"> (optional)</param>
        /// <returns></returns>
        public void UpdateTask(long taskId, string xRequestId = default(string), TaskUpdate taskUpdate = default(TaskUpdate))
        {
            UpdateTaskWithHttpInfo(taskId, xRequestId, taskUpdate);
        }

        /// <summary>
        /// Update a task
        /// </summary>
        /// <remarks>
        /// Update a task.
        /// </remarks>
        /// <exception cref="Todoist.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="taskId"></param>
        /// <param name="xRequestId"> (optional)</param>
        /// <param name="taskUpdate"> (optional)</param>
        /// <returns>ApiResponse of Object(void)</returns>
        public Todoist.Client.ApiResponse<Object> UpdateTaskWithHttpInfo(long taskId, string xRequestId = default(string), TaskUpdate taskUpdate = default(TaskUpdate))
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

            localVarRequestOptions.PathParameters.Add("taskId", Todoist.Client.ClientUtils.ParameterToString(taskId)); // path parameter
            if (xRequestId != null)
            {
                localVarRequestOptions.HeaderParameters.Add("X-Request-Id", Todoist.Client.ClientUtils.ParameterToString(xRequestId)); // header parameter
            }
            localVarRequestOptions.Data = taskUpdate;

            // authentication (OAuth) required
            // oauth required
            if (!string.IsNullOrEmpty(this.Configuration.AccessToken))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }

            // make the HTTP request
            var localVarResponse = this.Client.Post<Object>("/tasks/{taskId}", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("UpdateTask", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// Update a task
        /// </summary>
        /// <remarks>
        /// Update a task.
        /// </remarks>
        /// <exception cref="Todoist.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="taskId"></param>
        /// <param name="xRequestId"> (optional)</param>
        /// <param name="taskUpdate"> (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of void</returns>
        public async System.Threading.Tasks.Task UpdateTaskAsync(long taskId, string xRequestId = default(string), TaskUpdate taskUpdate = default(TaskUpdate), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            await UpdateTaskWithHttpInfoAsync(taskId, xRequestId, taskUpdate, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Update a task
        /// </summary>
        /// <remarks>
        /// Update a task.
        /// </remarks>
        /// <exception cref="Todoist.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="taskId"></param>
        /// <param name="xRequestId"> (optional)</param>
        /// <param name="taskUpdate"> (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse</returns>
        public async System.Threading.Tasks.Task<Todoist.Client.ApiResponse<Object>> UpdateTaskWithHttpInfoAsync(long taskId, string xRequestId = default(string), TaskUpdate taskUpdate = default(TaskUpdate), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
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

            localVarRequestOptions.PathParameters.Add("taskId", Todoist.Client.ClientUtils.ParameterToString(taskId)); // path parameter
            if (xRequestId != null)
            {
                localVarRequestOptions.HeaderParameters.Add("X-Request-Id", Todoist.Client.ClientUtils.ParameterToString(xRequestId)); // header parameter
            }
            localVarRequestOptions.Data = taskUpdate;

            // authentication (OAuth) required
            // oauth required
            if (!string.IsNullOrEmpty(this.Configuration.AccessToken))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }

            // make the HTTP request

            var localVarResponse = await this.AsynchronousClient.PostAsync<Object>("/tasks/{taskId}", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("UpdateTask", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

    }
}
