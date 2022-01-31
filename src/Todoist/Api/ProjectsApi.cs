using System;
using System.Collections.Generic;
using System.Net.Http;
using Todoist.Client;
using Todoist.Models;

namespace Todoist
{
    using Todoist.Api;
    public partial interface ITodoistClient
    {
        IProjectsApi Projects { get; }
    }
    public partial class TodoistClient
    {
        private IProjectsApi _projects;

        public IProjectsApi Projects =>
            _projects ?? (_projects = CreateProjectsApi());

        private ProjectsApi CreateProjectsApi()
        {
            if (_client != null && _configuration != null && _handler != null)
                return new ProjectsApi(_client, _configuration, _handler); 
            if (_client != null && _basePath != null && _handler != null)
                return new ProjectsApi(_client, _basePath, _handler); 
            if (_client != null &&  _handler != null)
                return new ProjectsApi(_client, _handler); 
            if (_configuration != null)
                return new ProjectsApi(_configuration); 
            if (_basePath != null)
                return new ProjectsApi(_basePath); 
            return new ProjectsApi();
        }
    }
}

namespace Todoist.Api
{

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface IProjectsApiSync : IApiAccessor
    {
        #region Synchronous Operations
        /// <summary>
        /// Create a new project
        /// </summary>
        /// <remarks>
        /// Creates a new project and returns it as a JSON object.
        /// </remarks>
        /// <exception cref="Todoist.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="xRequestId"> (optional)</param>
        /// <param name="newProject"> (optional)</param>
        /// <returns>Project</returns>
        Project CreateProject(string xRequestId = default(string), NewProject newProject = default(NewProject));

        /// <summary>
        /// Create a new project
        /// </summary>
        /// <remarks>
        /// Creates a new project and returns it as a JSON object.
        /// </remarks>
        /// <exception cref="Todoist.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="xRequestId"> (optional)</param>
        /// <param name="newProject"> (optional)</param>
        /// <returns>ApiResponse of Project</returns>
        ApiResponse<Project> CreateProjectWithHttpInfo(string xRequestId = default(string), NewProject newProject = default(NewProject));
        /// <summary>
        /// Delete a project
        /// </summary>
        /// <remarks>
        /// Deletes a project.
        /// </remarks>
        /// <exception cref="Todoist.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId"></param>
        /// <returns></returns>
        void DeleteProject(long projectId);

        /// <summary>
        /// Delete a project
        /// </summary>
        /// <remarks>
        /// Deletes a project.
        /// </remarks>
        /// <exception cref="Todoist.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId"></param>
        /// <returns>ApiResponse of Object(void)</returns>
        ApiResponse<Object> DeleteProjectWithHttpInfo(long projectId);
        /// <summary>
        /// Get all collaborators
        /// </summary>
        /// <remarks>
        /// Returns JSON-encoded array containing all collaborators of a shared project.
        /// </remarks>
        /// <exception cref="Todoist.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId"></param>
        /// <returns>List&lt;Collaborator&gt;</returns>
        List<Collaborator> GetCollaborators(long projectId);

        /// <summary>
        /// Get all collaborators
        /// </summary>
        /// <remarks>
        /// Returns JSON-encoded array containing all collaborators of a shared project.
        /// </remarks>
        /// <exception cref="Todoist.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId"></param>
        /// <returns>ApiResponse of List&lt;Collaborator&gt;</returns>
        ApiResponse<List<Collaborator>> GetCollaboratorsWithHttpInfo(long projectId);
        /// <summary>
        /// Get a project
        /// </summary>
        /// <remarks>
        /// Returns a JSON object containing a project object related to the given ID.
        /// </remarks>
        /// <exception cref="Todoist.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId"></param>
        /// <returns>Project</returns>
        Project GetProject(long projectId);

        /// <summary>
        /// Get a project
        /// </summary>
        /// <remarks>
        /// Returns a JSON object containing a project object related to the given ID.
        /// </remarks>
        /// <exception cref="Todoist.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId"></param>
        /// <returns>ApiResponse of Project</returns>
        ApiResponse<Project> GetProjectWithHttpInfo(long projectId);
        /// <summary>
        /// Get all projects
        /// </summary>
        /// <remarks>
        /// Returns JSON-encoded array containing all user projects.
        /// </remarks>
        /// <exception cref="Todoist.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>List&lt;Project&gt;</returns>
        List<Project> GetProjects();

        /// <summary>
        /// Get all projects
        /// </summary>
        /// <remarks>
        /// Returns JSON-encoded array containing all user projects.
        /// </remarks>
        /// <exception cref="Todoist.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>ApiResponse of List&lt;Project&gt;</returns>
        ApiResponse<List<Project>> GetProjectsWithHttpInfo();
        /// <summary>
        /// Update a project
        /// </summary>
        /// <remarks>
        /// Updates the project for the given ID.
        /// </remarks>
        /// <exception cref="Todoist.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId"></param>
        /// <param name="xRequestId"> (optional)</param>
        /// <param name="projectUpdate"> (optional)</param>
        /// <returns></returns>
        void UpdateProject(long projectId, string xRequestId = default(string), ProjectUpdate projectUpdate = default(ProjectUpdate));

        /// <summary>
        /// Update a project
        /// </summary>
        /// <remarks>
        /// Updates the project for the given ID.
        /// </remarks>
        /// <exception cref="Todoist.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId"></param>
        /// <param name="xRequestId"> (optional)</param>
        /// <param name="projectUpdate"> (optional)</param>
        /// <returns>ApiResponse of Object(void)</returns>
        ApiResponse<Object> UpdateProjectWithHttpInfo(long projectId, string xRequestId = default(string), ProjectUpdate projectUpdate = default(ProjectUpdate));
        #endregion Synchronous Operations
    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface IProjectsApiAsync : IApiAccessor
    {
        #region Asynchronous Operations
        /// <summary>
        /// Create a new project
        /// </summary>
        /// <remarks>
        /// Creates a new project and returns it as a JSON object.
        /// </remarks>
        /// <exception cref="Todoist.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="xRequestId"> (optional)</param>
        /// <param name="newProject"> (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of Project</returns>
        System.Threading.Tasks.Task<Project> CreateProjectAsync(string xRequestId = default(string), NewProject newProject = default(NewProject), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// Create a new project
        /// </summary>
        /// <remarks>
        /// Creates a new project and returns it as a JSON object.
        /// </remarks>
        /// <exception cref="Todoist.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="xRequestId"> (optional)</param>
        /// <param name="newProject"> (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (Project)</returns>
        System.Threading.Tasks.Task<ApiResponse<Project>> CreateProjectWithHttpInfoAsync(string xRequestId = default(string), NewProject newProject = default(NewProject), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// Delete a project
        /// </summary>
        /// <remarks>
        /// Deletes a project.
        /// </remarks>
        /// <exception cref="Todoist.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId"></param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of void</returns>
        System.Threading.Tasks.Task DeleteProjectAsync(long projectId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// Delete a project
        /// </summary>
        /// <remarks>
        /// Deletes a project.
        /// </remarks>
        /// <exception cref="Todoist.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId"></param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse</returns>
        System.Threading.Tasks.Task<ApiResponse<Object>> DeleteProjectWithHttpInfoAsync(long projectId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// Get all collaborators
        /// </summary>
        /// <remarks>
        /// Returns JSON-encoded array containing all collaborators of a shared project.
        /// </remarks>
        /// <exception cref="Todoist.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId"></param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of List&lt;Collaborator&gt;</returns>
        System.Threading.Tasks.Task<List<Collaborator>> GetCollaboratorsAsync(long projectId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// Get all collaborators
        /// </summary>
        /// <remarks>
        /// Returns JSON-encoded array containing all collaborators of a shared project.
        /// </remarks>
        /// <exception cref="Todoist.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId"></param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (List&lt;Collaborator&gt;)</returns>
        System.Threading.Tasks.Task<ApiResponse<List<Collaborator>>> GetCollaboratorsWithHttpInfoAsync(long projectId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// Get a project
        /// </summary>
        /// <remarks>
        /// Returns a JSON object containing a project object related to the given ID.
        /// </remarks>
        /// <exception cref="Todoist.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId"></param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of Project</returns>
        System.Threading.Tasks.Task<Project> GetProjectAsync(long projectId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// Get a project
        /// </summary>
        /// <remarks>
        /// Returns a JSON object containing a project object related to the given ID.
        /// </remarks>
        /// <exception cref="Todoist.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId"></param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (Project)</returns>
        System.Threading.Tasks.Task<ApiResponse<Project>> GetProjectWithHttpInfoAsync(long projectId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// Get all projects
        /// </summary>
        /// <remarks>
        /// Returns JSON-encoded array containing all user projects.
        /// </remarks>
        /// <exception cref="Todoist.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of List&lt;Project&gt;</returns>
        System.Threading.Tasks.Task<List<Project>> GetProjectsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// Get all projects
        /// </summary>
        /// <remarks>
        /// Returns JSON-encoded array containing all user projects.
        /// </remarks>
        /// <exception cref="Todoist.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (List&lt;Project&gt;)</returns>
        System.Threading.Tasks.Task<ApiResponse<List<Project>>> GetProjectsWithHttpInfoAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// Update a project
        /// </summary>
        /// <remarks>
        /// Updates the project for the given ID.
        /// </remarks>
        /// <exception cref="Todoist.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId"></param>
        /// <param name="xRequestId"> (optional)</param>
        /// <param name="projectUpdate"> (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of void</returns>
        System.Threading.Tasks.Task UpdateProjectAsync(long projectId, string xRequestId = default(string), ProjectUpdate projectUpdate = default(ProjectUpdate), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// Update a project
        /// </summary>
        /// <remarks>
        /// Updates the project for the given ID.
        /// </remarks>
        /// <exception cref="Todoist.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId"></param>
        /// <param name="xRequestId"> (optional)</param>
        /// <param name="projectUpdate"> (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse</returns>
        System.Threading.Tasks.Task<ApiResponse<Object>> UpdateProjectWithHttpInfoAsync(long projectId, string xRequestId = default(string), ProjectUpdate projectUpdate = default(ProjectUpdate), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        #endregion Asynchronous Operations
    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface IProjectsApi : IProjectsApiSync, IProjectsApiAsync
    {

    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    internal partial class ProjectsApi : IDisposable, IProjectsApi
    {
        private Todoist.Client.ExceptionFactory _exceptionFactory = (name, response) => null;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProjectsApi"/> class.
        /// **IMPORTANT** This will also create an instance of HttpClient, which is less than ideal.
        /// It's better to reuse the <see href="https://docs.microsoft.com/en-us/dotnet/architecture/microservices/implement-resilient-applications/use-httpclientfactory-to-implement-resilient-http-requests#issues-with-the-original-httpclient-class-available-in-net">HttpClient and HttpClientHandler</see>.
        /// </summary>
        /// <returns></returns>
        public ProjectsApi() : this((string)null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ProjectsApi"/> class.
        /// **IMPORTANT** This will also create an instance of HttpClient, which is less than ideal.
        /// It's better to reuse the <see href="https://docs.microsoft.com/en-us/dotnet/architecture/microservices/implement-resilient-applications/use-httpclientfactory-to-implement-resilient-http-requests#issues-with-the-original-httpclient-class-available-in-net">HttpClient and HttpClientHandler</see>.
        /// </summary>
        /// <param name="basePath">The target service's base path in URL format.</param>
        /// <exception cref="ArgumentException"></exception>
        /// <returns></returns>
        public ProjectsApi(string basePath)
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
        /// Initializes a new instance of the <see cref="ProjectsApi"/> class using Configuration object.
        /// **IMPORTANT** This will also create an instance of HttpClient, which is less than ideal.
        /// It's better to reuse the <see href="https://docs.microsoft.com/en-us/dotnet/architecture/microservices/implement-resilient-applications/use-httpclientfactory-to-implement-resilient-http-requests#issues-with-the-original-httpclient-class-available-in-net">HttpClient and HttpClientHandler</see>.
        /// </summary>
        /// <param name="configuration">An instance of Configuration.</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <returns></returns>
        public ProjectsApi(Todoist.Client.Configuration configuration)
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
        /// Initializes a new instance of the <see cref="ProjectsApi"/> class.
        /// </summary>
        /// <param name="client">An instance of HttpClient.</param>
        /// <param name="handler">An optional instance of HttpClientHandler that is used by HttpClient.</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <returns></returns>
        /// <remarks>
        /// Some configuration settings will not be applied without passing an HttpClientHandler.
        /// The features affected are: Setting and Retrieving Cookies, Client Certificates, Proxy settings.
        /// </remarks>
        public ProjectsApi(HttpClient client, HttpClientHandler handler = null) : this(client, (string)null, handler)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ProjectsApi"/> class.
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
        public ProjectsApi(HttpClient client, string basePath, HttpClientHandler handler = null)
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
        /// Initializes a new instance of the <see cref="ProjectsApi"/> class using Configuration object.
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
        public ProjectsApi(HttpClient client, Todoist.Client.Configuration configuration, HttpClientHandler handler = null)
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
        /// Initializes a new instance of the <see cref="ProjectsApi"/> class
        /// using a Configuration object and client instance.
        /// </summary>
        /// <param name="client">The client interface for synchronous API access.</param>
        /// <param name="asyncClient">The client interface for asynchronous API access.</param>
        /// <param name="configuration">The configuration object.</param>
        /// <exception cref="ArgumentNullException"></exception>
        internal ProjectsApi(Todoist.Client.ISynchronousClient client, Todoist.Client.IAsynchronousClient asyncClient, Todoist.Client.IReadableConfiguration configuration)
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
        /// Create a new project
        /// </summary>
        /// <remarks>
        /// Creates a new project and returns it as a JSON object.
        /// </remarks>
        /// <exception cref="Todoist.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="xRequestId"> (optional)</param>
        /// <param name="newProject"> (optional)</param>
        /// <returns>Project</returns>
        public Project CreateProject(string xRequestId = default(string), NewProject newProject = default(NewProject))
        {
            Todoist.Client.ApiResponse<Project> localVarResponse = CreateProjectWithHttpInfo(xRequestId, newProject);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Create a new project
        /// </summary>
        /// <remarks>
        /// Creates a new project and returns it as a JSON object.
        /// </remarks>
        /// <exception cref="Todoist.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="xRequestId"> (optional)</param>
        /// <param name="newProject"> (optional)</param>
        /// <returns>ApiResponse of Project</returns>
        public Todoist.Client.ApiResponse<Project> CreateProjectWithHttpInfo(string xRequestId = default(string), NewProject newProject = default(NewProject))
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
            localVarRequestOptions.Data = newProject;

            // authentication (OAuth) required
            // oauth required
            if (!string.IsNullOrEmpty(this.Configuration.AccessToken))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }

            // make the HTTP request
            var localVarResponse = this.Client.Post<Project>("/projects", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("CreateProject", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// Create a new project
        /// </summary>
        /// <remarks>
        /// Creates a new project and returns it as a JSON object.
        /// </remarks>
        /// <exception cref="Todoist.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="xRequestId"> (optional)</param>
        /// <param name="newProject"> (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of Project</returns>
        public async System.Threading.Tasks.Task<Project> CreateProjectAsync(string xRequestId = default(string), NewProject newProject = default(NewProject), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Todoist.Client.ApiResponse<Project> localVarResponse = await CreateProjectWithHttpInfoAsync(xRequestId, newProject, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Create a new project
        /// </summary>
        /// <remarks>
        /// Creates a new project and returns it as a JSON object.
        /// </remarks>
        /// <exception cref="Todoist.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="xRequestId"> (optional)</param>
        /// <param name="newProject"> (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (Project)</returns>
        public async System.Threading.Tasks.Task<Todoist.Client.ApiResponse<Project>> CreateProjectWithHttpInfoAsync(string xRequestId = default(string), NewProject newProject = default(NewProject), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
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
            localVarRequestOptions.Data = newProject;

            // authentication (OAuth) required
            // oauth required
            if (!string.IsNullOrEmpty(this.Configuration.AccessToken))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }

            // make the HTTP request

            var localVarResponse = await this.AsynchronousClient.PostAsync<Project>("/projects", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("CreateProject", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// Delete a project
        /// </summary>
        /// <remarks>
        /// Deletes a project.
        /// </remarks>
        /// <exception cref="Todoist.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId"></param>
        /// <returns></returns>
        public void DeleteProject(long projectId)
        {
            DeleteProjectWithHttpInfo(projectId);
        }

        /// <summary>
        /// Delete a project
        /// </summary>
        /// <remarks>
        /// Deletes a project.
        /// </remarks>
        /// <exception cref="Todoist.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId"></param>
        /// <returns>ApiResponse of Object(void)</returns>
        public Todoist.Client.ApiResponse<Object> DeleteProjectWithHttpInfo(long projectId)
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

            localVarRequestOptions.PathParameters.Add("projectId", Todoist.Client.ClientUtils.ParameterToString(projectId)); // path parameter

            // authentication (OAuth) required
            // oauth required
            if (!string.IsNullOrEmpty(this.Configuration.AccessToken))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }

            // make the HTTP request
            var localVarResponse = this.Client.Delete<Object>("/projects/{projectId}", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("DeleteProject", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// Delete a project
        /// </summary>
        /// <remarks>
        /// Deletes a project.
        /// </remarks>
        /// <exception cref="Todoist.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId"></param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of void</returns>
        public async System.Threading.Tasks.Task DeleteProjectAsync(long projectId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            await DeleteProjectWithHttpInfoAsync(projectId, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Delete a project
        /// </summary>
        /// <remarks>
        /// Deletes a project.
        /// </remarks>
        /// <exception cref="Todoist.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId"></param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse</returns>
        public async System.Threading.Tasks.Task<Todoist.Client.ApiResponse<Object>> DeleteProjectWithHttpInfoAsync(long projectId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
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

            localVarRequestOptions.PathParameters.Add("projectId", Todoist.Client.ClientUtils.ParameterToString(projectId)); // path parameter

            // authentication (OAuth) required
            // oauth required
            if (!string.IsNullOrEmpty(this.Configuration.AccessToken))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }

            // make the HTTP request

            var localVarResponse = await this.AsynchronousClient.DeleteAsync<Object>("/projects/{projectId}", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("DeleteProject", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// Get all collaborators
        /// </summary>
        /// <remarks>
        /// Returns JSON-encoded array containing all collaborators of a shared project.
        /// </remarks>
        /// <exception cref="Todoist.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId"></param>
        /// <returns>List&lt;Collaborator&gt;</returns>
        public List<Collaborator> GetCollaborators(long projectId)
        {
            Todoist.Client.ApiResponse<List<Collaborator>> localVarResponse = GetCollaboratorsWithHttpInfo(projectId);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Get all collaborators
        /// </summary>
        /// <remarks>
        /// Returns JSON-encoded array containing all collaborators of a shared project.
        /// </remarks>
        /// <exception cref="Todoist.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId"></param>
        /// <returns>ApiResponse of List&lt;Collaborator&gt;</returns>
        public Todoist.Client.ApiResponse<List<Collaborator>> GetCollaboratorsWithHttpInfo(long projectId)
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

            localVarRequestOptions.PathParameters.Add("projectId", Todoist.Client.ClientUtils.ParameterToString(projectId)); // path parameter

            // authentication (OAuth) required
            // oauth required
            if (!string.IsNullOrEmpty(this.Configuration.AccessToken))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }

            // make the HTTP request
            var localVarResponse = this.Client.Get<List<Collaborator>>("/projects/{projectId}/collaborators", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetCollaborators", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// Get all collaborators
        /// </summary>
        /// <remarks>
        /// Returns JSON-encoded array containing all collaborators of a shared project.
        /// </remarks>
        /// <exception cref="Todoist.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId"></param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of List&lt;Collaborator&gt;</returns>
        public async System.Threading.Tasks.Task<List<Collaborator>> GetCollaboratorsAsync(long projectId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Todoist.Client.ApiResponse<List<Collaborator>> localVarResponse = await GetCollaboratorsWithHttpInfoAsync(projectId, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Get all collaborators
        /// </summary>
        /// <remarks>
        /// Returns JSON-encoded array containing all collaborators of a shared project.
        /// </remarks>
        /// <exception cref="Todoist.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId"></param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (List&lt;Collaborator&gt;)</returns>
        public async System.Threading.Tasks.Task<Todoist.Client.ApiResponse<List<Collaborator>>> GetCollaboratorsWithHttpInfoAsync(long projectId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
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

            localVarRequestOptions.PathParameters.Add("projectId", Todoist.Client.ClientUtils.ParameterToString(projectId)); // path parameter

            // authentication (OAuth) required
            // oauth required
            if (!string.IsNullOrEmpty(this.Configuration.AccessToken))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }

            // make the HTTP request

            var localVarResponse = await this.AsynchronousClient.GetAsync<List<Collaborator>>("/projects/{projectId}/collaborators", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetCollaborators", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// Get a project
        /// </summary>
        /// <remarks>
        /// Returns a JSON object containing a project object related to the given ID.
        /// </remarks>
        /// <exception cref="Todoist.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId"></param>
        /// <returns>Project</returns>
        public Project GetProject(long projectId)
        {
            Todoist.Client.ApiResponse<Project> localVarResponse = GetProjectWithHttpInfo(projectId);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Get a project
        /// </summary>
        /// <remarks>
        /// Returns a JSON object containing a project object related to the given ID.
        /// </remarks>
        /// <exception cref="Todoist.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId"></param>
        /// <returns>ApiResponse of Project</returns>
        public Todoist.Client.ApiResponse<Project> GetProjectWithHttpInfo(long projectId)
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

            localVarRequestOptions.PathParameters.Add("projectId", Todoist.Client.ClientUtils.ParameterToString(projectId)); // path parameter

            // authentication (OAuth) required
            // oauth required
            if (!string.IsNullOrEmpty(this.Configuration.AccessToken))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }

            // make the HTTP request
            var localVarResponse = this.Client.Get<Project>("/projects/{projectId}", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetProject", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// Get a project
        /// </summary>
        /// <remarks>
        /// Returns a JSON object containing a project object related to the given ID.
        /// </remarks>
        /// <exception cref="Todoist.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId"></param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of Project</returns>
        public async System.Threading.Tasks.Task<Project> GetProjectAsync(long projectId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Todoist.Client.ApiResponse<Project> localVarResponse = await GetProjectWithHttpInfoAsync(projectId, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Get a project
        /// </summary>
        /// <remarks>
        /// Returns a JSON object containing a project object related to the given ID.
        /// </remarks>
        /// <exception cref="Todoist.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId"></param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (Project)</returns>
        public async System.Threading.Tasks.Task<Todoist.Client.ApiResponse<Project>> GetProjectWithHttpInfoAsync(long projectId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
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

            localVarRequestOptions.PathParameters.Add("projectId", Todoist.Client.ClientUtils.ParameterToString(projectId)); // path parameter

            // authentication (OAuth) required
            // oauth required
            if (!string.IsNullOrEmpty(this.Configuration.AccessToken))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }

            // make the HTTP request

            var localVarResponse = await this.AsynchronousClient.GetAsync<Project>("/projects/{projectId}", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetProject", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// Get all projects
        /// </summary>
        /// <remarks>
        /// Returns JSON-encoded array containing all user projects.
        /// </remarks>
        /// <exception cref="Todoist.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>List&lt;Project&gt;</returns>
        public List<Project> GetProjects()
        {
            Todoist.Client.ApiResponse<List<Project>> localVarResponse = GetProjectsWithHttpInfo();
            return localVarResponse.Data;
        }

        /// <summary>
        /// Get all projects
        /// </summary>
        /// <remarks>
        /// Returns JSON-encoded array containing all user projects.
        /// </remarks>
        /// <exception cref="Todoist.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>ApiResponse of List&lt;Project&gt;</returns>
        public Todoist.Client.ApiResponse<List<Project>> GetProjectsWithHttpInfo()
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


            // authentication (OAuth) required
            // oauth required
            if (!string.IsNullOrEmpty(this.Configuration.AccessToken))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }

            // make the HTTP request
            var localVarResponse = this.Client.Get<List<Project>>("/projects", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetProjects", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// Get all projects
        /// </summary>
        /// <remarks>
        /// Returns JSON-encoded array containing all user projects.
        /// </remarks>
        /// <exception cref="Todoist.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of List&lt;Project&gt;</returns>
        public async System.Threading.Tasks.Task<List<Project>> GetProjectsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Todoist.Client.ApiResponse<List<Project>> localVarResponse = await GetProjectsWithHttpInfoAsync(cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Get all projects
        /// </summary>
        /// <remarks>
        /// Returns JSON-encoded array containing all user projects.
        /// </remarks>
        /// <exception cref="Todoist.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (List&lt;Project&gt;)</returns>
        public async System.Threading.Tasks.Task<Todoist.Client.ApiResponse<List<Project>>> GetProjectsWithHttpInfoAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
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


            // authentication (OAuth) required
            // oauth required
            if (!string.IsNullOrEmpty(this.Configuration.AccessToken))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }

            // make the HTTP request

            var localVarResponse = await this.AsynchronousClient.GetAsync<List<Project>>("/projects", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetProjects", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// Update a project
        /// </summary>
        /// <remarks>
        /// Updates the project for the given ID.
        /// </remarks>
        /// <exception cref="Todoist.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId"></param>
        /// <param name="xRequestId"> (optional)</param>
        /// <param name="projectUpdate"> (optional)</param>
        /// <returns></returns>
        public void UpdateProject(long projectId, string xRequestId = default(string), ProjectUpdate projectUpdate = default(ProjectUpdate))
        {
            UpdateProjectWithHttpInfo(projectId, xRequestId, projectUpdate);
        }

        /// <summary>
        /// Update a project
        /// </summary>
        /// <remarks>
        /// Updates the project for the given ID.
        /// </remarks>
        /// <exception cref="Todoist.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId"></param>
        /// <param name="xRequestId"> (optional)</param>
        /// <param name="projectUpdate"> (optional)</param>
        /// <returns>ApiResponse of Object(void)</returns>
        public Todoist.Client.ApiResponse<Object> UpdateProjectWithHttpInfo(long projectId, string xRequestId = default(string), ProjectUpdate projectUpdate = default(ProjectUpdate))
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

            localVarRequestOptions.PathParameters.Add("projectId", Todoist.Client.ClientUtils.ParameterToString(projectId)); // path parameter
            if (xRequestId != null)
            {
                localVarRequestOptions.HeaderParameters.Add("X-Request-Id", Todoist.Client.ClientUtils.ParameterToString(xRequestId)); // header parameter
            }
            localVarRequestOptions.Data = projectUpdate;

            // authentication (OAuth) required
            // oauth required
            if (!string.IsNullOrEmpty(this.Configuration.AccessToken))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }

            // make the HTTP request
            var localVarResponse = this.Client.Post<Object>("/projects/{projectId}", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("UpdateProject", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// Update a project
        /// </summary>
        /// <remarks>
        /// Updates the project for the given ID.
        /// </remarks>
        /// <exception cref="Todoist.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId"></param>
        /// <param name="xRequestId"> (optional)</param>
        /// <param name="projectUpdate"> (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of void</returns>
        public async System.Threading.Tasks.Task UpdateProjectAsync(long projectId, string xRequestId = default(string), ProjectUpdate projectUpdate = default(ProjectUpdate), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            await UpdateProjectWithHttpInfoAsync(projectId, xRequestId, projectUpdate, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Update a project
        /// </summary>
        /// <remarks>
        /// Updates the project for the given ID.
        /// </remarks>
        /// <exception cref="Todoist.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId"></param>
        /// <param name="xRequestId"> (optional)</param>
        /// <param name="projectUpdate"> (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse</returns>
        public async System.Threading.Tasks.Task<Todoist.Client.ApiResponse<Object>> UpdateProjectWithHttpInfoAsync(long projectId, string xRequestId = default(string), ProjectUpdate projectUpdate = default(ProjectUpdate), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
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

            localVarRequestOptions.PathParameters.Add("projectId", Todoist.Client.ClientUtils.ParameterToString(projectId)); // path parameter
            if (xRequestId != null)
            {
                localVarRequestOptions.HeaderParameters.Add("X-Request-Id", Todoist.Client.ClientUtils.ParameterToString(xRequestId)); // header parameter
            }
            localVarRequestOptions.Data = projectUpdate;

            // authentication (OAuth) required
            // oauth required
            if (!string.IsNullOrEmpty(this.Configuration.AccessToken))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }

            // make the HTTP request

            var localVarResponse = await this.AsynchronousClient.PostAsync<Object>("/projects/{projectId}", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("UpdateProject", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

    }
}
