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
        ILabelsApi Labels { get; }
    }
    public partial class TodoistClient
    {
        private ILabelsApi _labels;

        public ILabelsApi Labels =>
            _labels ?? (_labels = CreateLabelsApi());

        private LabelsApi CreateLabelsApi()
        {
            if (_client != null && _configuration != null && _handler != null)
                return new LabelsApi(_client, _configuration, _handler); 
            if (_client != null && _basePath != null && _handler != null)
                return new LabelsApi(_client, _basePath, _handler); 
            if (_client != null &&  _handler != null)
                return new LabelsApi(_client, _handler); 
            if (_configuration != null)
                return new LabelsApi(_configuration); 
            if (_basePath != null)
                return new LabelsApi(_basePath); 
            return new LabelsApi();
        }
    }
}

namespace Todoist.Api
{

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface ILabelsApiSync : IApiAccessor
    {
        #region Synchronous Operations
        /// <summary>
        /// Create a new label
        /// </summary>
        /// <remarks>
        /// Creates a new label and returns its object as JSON.
        /// </remarks>
        /// <exception cref="Todoist.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="xRequestId"> (optional)</param>
        /// <param name="newLabel"> (optional)</param>
        /// <returns>Label</returns>
        Label CreateLabel(string xRequestId = default(string), NewLabel newLabel = default(NewLabel));

        /// <summary>
        /// Create a new label
        /// </summary>
        /// <remarks>
        /// Creates a new label and returns its object as JSON.
        /// </remarks>
        /// <exception cref="Todoist.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="xRequestId"> (optional)</param>
        /// <param name="newLabel"> (optional)</param>
        /// <returns>ApiResponse of Label</returns>
        ApiResponse<Label> CreateLabelWithHttpInfo(string xRequestId = default(string), NewLabel newLabel = default(NewLabel));
        /// <summary>
        /// Delete a label
        /// </summary>
        /// <remarks>
        /// Deletes a label.
        /// </remarks>
        /// <exception cref="Todoist.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="labelId"></param>
        /// <returns></returns>
        void DeleteLabel(long labelId);

        /// <summary>
        /// Delete a label
        /// </summary>
        /// <remarks>
        /// Deletes a label.
        /// </remarks>
        /// <exception cref="Todoist.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="labelId"></param>
        /// <returns>ApiResponse of Object(void)</returns>
        ApiResponse<Object> DeleteLabelWithHttpInfo(long labelId);
        /// <summary>
        /// Get a label
        /// </summary>
        /// <remarks>
        /// Returns a label by ID.
        /// </remarks>
        /// <exception cref="Todoist.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="labelId"></param>
        /// <returns>Label</returns>
        Label GetLabel(long labelId);

        /// <summary>
        /// Get a label
        /// </summary>
        /// <remarks>
        /// Returns a label by ID.
        /// </remarks>
        /// <exception cref="Todoist.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="labelId"></param>
        /// <returns>ApiResponse of Label</returns>
        ApiResponse<Label> GetLabelWithHttpInfo(long labelId);
        /// <summary>
        /// Get all labels
        /// </summary>
        /// <remarks>
        /// Returns a JSON-encoded array containing all user labels.
        /// </remarks>
        /// <exception cref="Todoist.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>List&lt;Label&gt;</returns>
        List<Label> GetLabels();

        /// <summary>
        /// Get all labels
        /// </summary>
        /// <remarks>
        /// Returns a JSON-encoded array containing all user labels.
        /// </remarks>
        /// <exception cref="Todoist.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>ApiResponse of List&lt;Label&gt;</returns>
        ApiResponse<List<Label>> GetLabelsWithHttpInfo();
        /// <summary>
        /// Update a label
        /// </summary>
        /// <remarks>
        /// Updates a label.
        /// </remarks>
        /// <exception cref="Todoist.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="labelId"></param>
        /// <param name="xRequestId"> (optional)</param>
        /// <param name="labelUpdate"> (optional)</param>
        /// <returns></returns>
        void UpdateLabel(long labelId, string xRequestId = default(string), LabelUpdate labelUpdate = default(LabelUpdate));

        /// <summary>
        /// Update a label
        /// </summary>
        /// <remarks>
        /// Updates a label.
        /// </remarks>
        /// <exception cref="Todoist.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="labelId"></param>
        /// <param name="xRequestId"> (optional)</param>
        /// <param name="labelUpdate"> (optional)</param>
        /// <returns>ApiResponse of Object(void)</returns>
        ApiResponse<Object> UpdateLabelWithHttpInfo(long labelId, string xRequestId = default(string), LabelUpdate labelUpdate = default(LabelUpdate));
        #endregion Synchronous Operations
    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface ILabelsApiAsync : IApiAccessor
    {
        #region Asynchronous Operations
        /// <summary>
        /// Create a new label
        /// </summary>
        /// <remarks>
        /// Creates a new label and returns its object as JSON.
        /// </remarks>
        /// <exception cref="Todoist.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="xRequestId"> (optional)</param>
        /// <param name="newLabel"> (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of Label</returns>
        System.Threading.Tasks.Task<Label> CreateLabelAsync(string xRequestId = default(string), NewLabel newLabel = default(NewLabel), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// Create a new label
        /// </summary>
        /// <remarks>
        /// Creates a new label and returns its object as JSON.
        /// </remarks>
        /// <exception cref="Todoist.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="xRequestId"> (optional)</param>
        /// <param name="newLabel"> (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (Label)</returns>
        System.Threading.Tasks.Task<ApiResponse<Label>> CreateLabelWithHttpInfoAsync(string xRequestId = default(string), NewLabel newLabel = default(NewLabel), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// Delete a label
        /// </summary>
        /// <remarks>
        /// Deletes a label.
        /// </remarks>
        /// <exception cref="Todoist.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="labelId"></param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of void</returns>
        System.Threading.Tasks.Task DeleteLabelAsync(long labelId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// Delete a label
        /// </summary>
        /// <remarks>
        /// Deletes a label.
        /// </remarks>
        /// <exception cref="Todoist.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="labelId"></param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse</returns>
        System.Threading.Tasks.Task<ApiResponse<Object>> DeleteLabelWithHttpInfoAsync(long labelId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// Get a label
        /// </summary>
        /// <remarks>
        /// Returns a label by ID.
        /// </remarks>
        /// <exception cref="Todoist.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="labelId"></param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of Label</returns>
        System.Threading.Tasks.Task<Label> GetLabelAsync(long labelId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// Get a label
        /// </summary>
        /// <remarks>
        /// Returns a label by ID.
        /// </remarks>
        /// <exception cref="Todoist.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="labelId"></param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (Label)</returns>
        System.Threading.Tasks.Task<ApiResponse<Label>> GetLabelWithHttpInfoAsync(long labelId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// Get all labels
        /// </summary>
        /// <remarks>
        /// Returns a JSON-encoded array containing all user labels.
        /// </remarks>
        /// <exception cref="Todoist.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of List&lt;Label&gt;</returns>
        System.Threading.Tasks.Task<List<Label>> GetLabelsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// Get all labels
        /// </summary>
        /// <remarks>
        /// Returns a JSON-encoded array containing all user labels.
        /// </remarks>
        /// <exception cref="Todoist.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (List&lt;Label&gt;)</returns>
        System.Threading.Tasks.Task<ApiResponse<List<Label>>> GetLabelsWithHttpInfoAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// Update a label
        /// </summary>
        /// <remarks>
        /// Updates a label.
        /// </remarks>
        /// <exception cref="Todoist.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="labelId"></param>
        /// <param name="xRequestId"> (optional)</param>
        /// <param name="labelUpdate"> (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of void</returns>
        System.Threading.Tasks.Task UpdateLabelAsync(long labelId, string xRequestId = default(string), LabelUpdate labelUpdate = default(LabelUpdate), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// Update a label
        /// </summary>
        /// <remarks>
        /// Updates a label.
        /// </remarks>
        /// <exception cref="Todoist.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="labelId"></param>
        /// <param name="xRequestId"> (optional)</param>
        /// <param name="labelUpdate"> (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse</returns>
        System.Threading.Tasks.Task<ApiResponse<Object>> UpdateLabelWithHttpInfoAsync(long labelId, string xRequestId = default(string), LabelUpdate labelUpdate = default(LabelUpdate), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        #endregion Asynchronous Operations
    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface ILabelsApi : ILabelsApiSync, ILabelsApiAsync
    {

    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    internal partial class LabelsApi : IDisposable, ILabelsApi
    {
        private Todoist.Client.ExceptionFactory _exceptionFactory = (name, response) => null;

        /// <summary>
        /// Initializes a new instance of the <see cref="LabelsApi"/> class.
        /// **IMPORTANT** This will also create an instance of HttpClient, which is less than ideal.
        /// It's better to reuse the <see href="https://docs.microsoft.com/en-us/dotnet/architecture/microservices/implement-resilient-applications/use-httpclientfactory-to-implement-resilient-http-requests#issues-with-the-original-httpclient-class-available-in-net">HttpClient and HttpClientHandler</see>.
        /// </summary>
        /// <returns></returns>
        public LabelsApi() : this((string)null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LabelsApi"/> class.
        /// **IMPORTANT** This will also create an instance of HttpClient, which is less than ideal.
        /// It's better to reuse the <see href="https://docs.microsoft.com/en-us/dotnet/architecture/microservices/implement-resilient-applications/use-httpclientfactory-to-implement-resilient-http-requests#issues-with-the-original-httpclient-class-available-in-net">HttpClient and HttpClientHandler</see>.
        /// </summary>
        /// <param name="basePath">The target service's base path in URL format.</param>
        /// <exception cref="ArgumentException"></exception>
        /// <returns></returns>
        public LabelsApi(string basePath)
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
        /// Initializes a new instance of the <see cref="LabelsApi"/> class using Configuration object.
        /// **IMPORTANT** This will also create an instance of HttpClient, which is less than ideal.
        /// It's better to reuse the <see href="https://docs.microsoft.com/en-us/dotnet/architecture/microservices/implement-resilient-applications/use-httpclientfactory-to-implement-resilient-http-requests#issues-with-the-original-httpclient-class-available-in-net">HttpClient and HttpClientHandler</see>.
        /// </summary>
        /// <param name="configuration">An instance of Configuration.</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <returns></returns>
        public LabelsApi(Todoist.Client.Configuration configuration)
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
        /// Initializes a new instance of the <see cref="LabelsApi"/> class.
        /// </summary>
        /// <param name="client">An instance of HttpClient.</param>
        /// <param name="handler">An optional instance of HttpClientHandler that is used by HttpClient.</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <returns></returns>
        /// <remarks>
        /// Some configuration settings will not be applied without passing an HttpClientHandler.
        /// The features affected are: Setting and Retrieving Cookies, Client Certificates, Proxy settings.
        /// </remarks>
        public LabelsApi(HttpClient client, HttpClientHandler handler = null) : this(client, (string)null, handler)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LabelsApi"/> class.
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
        public LabelsApi(HttpClient client, string basePath, HttpClientHandler handler = null)
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
        /// Initializes a new instance of the <see cref="LabelsApi"/> class using Configuration object.
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
        public LabelsApi(HttpClient client, Todoist.Client.Configuration configuration, HttpClientHandler handler = null)
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
        /// Initializes a new instance of the <see cref="LabelsApi"/> class
        /// using a Configuration object and client instance.
        /// </summary>
        /// <param name="client">The client interface for synchronous API access.</param>
        /// <param name="asyncClient">The client interface for asynchronous API access.</param>
        /// <param name="configuration">The configuration object.</param>
        /// <exception cref="ArgumentNullException"></exception>
        internal LabelsApi(Todoist.Client.ISynchronousClient client, Todoist.Client.IAsynchronousClient asyncClient, Todoist.Client.IReadableConfiguration configuration)
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
        /// Create a new label
        /// </summary>
        /// <remarks>
        /// Creates a new label and returns its object as JSON.
        /// </remarks>
        /// <exception cref="Todoist.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="xRequestId"> (optional)</param>
        /// <param name="newLabel"> (optional)</param>
        /// <returns>Label</returns>
        public Label CreateLabel(string xRequestId = default(string), NewLabel newLabel = default(NewLabel))
        {
            Todoist.Client.ApiResponse<Label> localVarResponse = CreateLabelWithHttpInfo(xRequestId, newLabel);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Create a new label
        /// </summary>
        /// <remarks>
        /// Creates a new label and returns its object as JSON.
        /// </remarks>
        /// <exception cref="Todoist.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="xRequestId"> (optional)</param>
        /// <param name="newLabel"> (optional)</param>
        /// <returns>ApiResponse of Label</returns>
        public Todoist.Client.ApiResponse<Label> CreateLabelWithHttpInfo(string xRequestId = default(string), NewLabel newLabel = default(NewLabel))
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
            localVarRequestOptions.Data = newLabel;

            // authentication (OAuth) required
            // oauth required
            if (!string.IsNullOrEmpty(this.Configuration.AccessToken))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }

            // make the HTTP request
            var localVarResponse = this.Client.Post<Label>("/labels", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("CreateLabel", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// Create a new label
        /// </summary>
        /// <remarks>
        /// Creates a new label and returns its object as JSON.
        /// </remarks>
        /// <exception cref="Todoist.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="xRequestId"> (optional)</param>
        /// <param name="newLabel"> (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of Label</returns>
        public async System.Threading.Tasks.Task<Label> CreateLabelAsync(string xRequestId = default(string), NewLabel newLabel = default(NewLabel), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Todoist.Client.ApiResponse<Label> localVarResponse = await CreateLabelWithHttpInfoAsync(xRequestId, newLabel, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Create a new label
        /// </summary>
        /// <remarks>
        /// Creates a new label and returns its object as JSON.
        /// </remarks>
        /// <exception cref="Todoist.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="xRequestId"> (optional)</param>
        /// <param name="newLabel"> (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (Label)</returns>
        public async System.Threading.Tasks.Task<Todoist.Client.ApiResponse<Label>> CreateLabelWithHttpInfoAsync(string xRequestId = default(string), NewLabel newLabel = default(NewLabel), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
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
            localVarRequestOptions.Data = newLabel;

            // authentication (OAuth) required
            // oauth required
            if (!string.IsNullOrEmpty(this.Configuration.AccessToken))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }

            // make the HTTP request

            var localVarResponse = await this.AsynchronousClient.PostAsync<Label>("/labels", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("CreateLabel", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// Delete a label
        /// </summary>
        /// <remarks>
        /// Deletes a label.
        /// </remarks>
        /// <exception cref="Todoist.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="labelId"></param>
        /// <returns></returns>
        public void DeleteLabel(long labelId)
        {
            DeleteLabelWithHttpInfo(labelId);
        }

        /// <summary>
        /// Delete a label
        /// </summary>
        /// <remarks>
        /// Deletes a label.
        /// </remarks>
        /// <exception cref="Todoist.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="labelId"></param>
        /// <returns>ApiResponse of Object(void)</returns>
        public Todoist.Client.ApiResponse<Object> DeleteLabelWithHttpInfo(long labelId)
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

            localVarRequestOptions.PathParameters.Add("labelId", Todoist.Client.ClientUtils.ParameterToString(labelId)); // path parameter

            // authentication (OAuth) required
            // oauth required
            if (!string.IsNullOrEmpty(this.Configuration.AccessToken))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }

            // make the HTTP request
            var localVarResponse = this.Client.Delete<Object>("/labels/{labelId}", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("DeleteLabel", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// Delete a label
        /// </summary>
        /// <remarks>
        /// Deletes a label.
        /// </remarks>
        /// <exception cref="Todoist.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="labelId"></param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of void</returns>
        public async System.Threading.Tasks.Task DeleteLabelAsync(long labelId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            await DeleteLabelWithHttpInfoAsync(labelId, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Delete a label
        /// </summary>
        /// <remarks>
        /// Deletes a label.
        /// </remarks>
        /// <exception cref="Todoist.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="labelId"></param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse</returns>
        public async System.Threading.Tasks.Task<Todoist.Client.ApiResponse<Object>> DeleteLabelWithHttpInfoAsync(long labelId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
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

            localVarRequestOptions.PathParameters.Add("labelId", Todoist.Client.ClientUtils.ParameterToString(labelId)); // path parameter

            // authentication (OAuth) required
            // oauth required
            if (!string.IsNullOrEmpty(this.Configuration.AccessToken))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }

            // make the HTTP request

            var localVarResponse = await this.AsynchronousClient.DeleteAsync<Object>("/labels/{labelId}", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("DeleteLabel", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// Get a label
        /// </summary>
        /// <remarks>
        /// Returns a label by ID.
        /// </remarks>
        /// <exception cref="Todoist.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="labelId"></param>
        /// <returns>Label</returns>
        public Label GetLabel(long labelId)
        {
            Todoist.Client.ApiResponse<Label> localVarResponse = GetLabelWithHttpInfo(labelId);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Get a label
        /// </summary>
        /// <remarks>
        /// Returns a label by ID.
        /// </remarks>
        /// <exception cref="Todoist.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="labelId"></param>
        /// <returns>ApiResponse of Label</returns>
        public Todoist.Client.ApiResponse<Label> GetLabelWithHttpInfo(long labelId)
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

            localVarRequestOptions.PathParameters.Add("labelId", Todoist.Client.ClientUtils.ParameterToString(labelId)); // path parameter

            // authentication (OAuth) required
            // oauth required
            if (!string.IsNullOrEmpty(this.Configuration.AccessToken))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }

            // make the HTTP request
            var localVarResponse = this.Client.Get<Label>("/labels/{labelId}", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetLabel", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// Get a label
        /// </summary>
        /// <remarks>
        /// Returns a label by ID.
        /// </remarks>
        /// <exception cref="Todoist.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="labelId"></param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of Label</returns>
        public async System.Threading.Tasks.Task<Label> GetLabelAsync(long labelId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Todoist.Client.ApiResponse<Label> localVarResponse = await GetLabelWithHttpInfoAsync(labelId, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Get a label
        /// </summary>
        /// <remarks>
        /// Returns a label by ID.
        /// </remarks>
        /// <exception cref="Todoist.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="labelId"></param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (Label)</returns>
        public async System.Threading.Tasks.Task<Todoist.Client.ApiResponse<Label>> GetLabelWithHttpInfoAsync(long labelId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
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

            localVarRequestOptions.PathParameters.Add("labelId", Todoist.Client.ClientUtils.ParameterToString(labelId)); // path parameter

            // authentication (OAuth) required
            // oauth required
            if (!string.IsNullOrEmpty(this.Configuration.AccessToken))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }

            // make the HTTP request

            var localVarResponse = await this.AsynchronousClient.GetAsync<Label>("/labels/{labelId}", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetLabel", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// Get all labels
        /// </summary>
        /// <remarks>
        /// Returns a JSON-encoded array containing all user labels.
        /// </remarks>
        /// <exception cref="Todoist.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>List&lt;Label&gt;</returns>
        public List<Label> GetLabels()
        {
            Todoist.Client.ApiResponse<List<Label>> localVarResponse = GetLabelsWithHttpInfo();
            return localVarResponse.Data;
        }

        /// <summary>
        /// Get all labels
        /// </summary>
        /// <remarks>
        /// Returns a JSON-encoded array containing all user labels.
        /// </remarks>
        /// <exception cref="Todoist.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>ApiResponse of List&lt;Label&gt;</returns>
        public Todoist.Client.ApiResponse<List<Label>> GetLabelsWithHttpInfo()
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
            var localVarResponse = this.Client.Get<List<Label>>("/labels", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetLabels", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// Get all labels
        /// </summary>
        /// <remarks>
        /// Returns a JSON-encoded array containing all user labels.
        /// </remarks>
        /// <exception cref="Todoist.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of List&lt;Label&gt;</returns>
        public async System.Threading.Tasks.Task<List<Label>> GetLabelsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Todoist.Client.ApiResponse<List<Label>> localVarResponse = await GetLabelsWithHttpInfoAsync(cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Get all labels
        /// </summary>
        /// <remarks>
        /// Returns a JSON-encoded array containing all user labels.
        /// </remarks>
        /// <exception cref="Todoist.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (List&lt;Label&gt;)</returns>
        public async System.Threading.Tasks.Task<Todoist.Client.ApiResponse<List<Label>>> GetLabelsWithHttpInfoAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
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

            var localVarResponse = await this.AsynchronousClient.GetAsync<List<Label>>("/labels", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetLabels", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// Update a label
        /// </summary>
        /// <remarks>
        /// Updates a label.
        /// </remarks>
        /// <exception cref="Todoist.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="labelId"></param>
        /// <param name="xRequestId"> (optional)</param>
        /// <param name="labelUpdate"> (optional)</param>
        /// <returns></returns>
        public void UpdateLabel(long labelId, string xRequestId = default(string), LabelUpdate labelUpdate = default(LabelUpdate))
        {
            UpdateLabelWithHttpInfo(labelId, xRequestId, labelUpdate);
        }

        /// <summary>
        /// Update a label
        /// </summary>
        /// <remarks>
        /// Updates a label.
        /// </remarks>
        /// <exception cref="Todoist.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="labelId"></param>
        /// <param name="xRequestId"> (optional)</param>
        /// <param name="labelUpdate"> (optional)</param>
        /// <returns>ApiResponse of Object(void)</returns>
        public Todoist.Client.ApiResponse<Object> UpdateLabelWithHttpInfo(long labelId, string xRequestId = default(string), LabelUpdate labelUpdate = default(LabelUpdate))
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

            localVarRequestOptions.PathParameters.Add("labelId", Todoist.Client.ClientUtils.ParameterToString(labelId)); // path parameter
            if (xRequestId != null)
            {
                localVarRequestOptions.HeaderParameters.Add("X-Request-Id", Todoist.Client.ClientUtils.ParameterToString(xRequestId)); // header parameter
            }
            localVarRequestOptions.Data = labelUpdate;

            // authentication (OAuth) required
            // oauth required
            if (!string.IsNullOrEmpty(this.Configuration.AccessToken))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }

            // make the HTTP request
            var localVarResponse = this.Client.Post<Object>("/labels/{labelId}", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("UpdateLabel", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// Update a label
        /// </summary>
        /// <remarks>
        /// Updates a label.
        /// </remarks>
        /// <exception cref="Todoist.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="labelId"></param>
        /// <param name="xRequestId"> (optional)</param>
        /// <param name="labelUpdate"> (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of void</returns>
        public async System.Threading.Tasks.Task UpdateLabelAsync(long labelId, string xRequestId = default(string), LabelUpdate labelUpdate = default(LabelUpdate), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            await UpdateLabelWithHttpInfoAsync(labelId, xRequestId, labelUpdate, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Update a label
        /// </summary>
        /// <remarks>
        /// Updates a label.
        /// </remarks>
        /// <exception cref="Todoist.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="labelId"></param>
        /// <param name="xRequestId"> (optional)</param>
        /// <param name="labelUpdate"> (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse</returns>
        public async System.Threading.Tasks.Task<Todoist.Client.ApiResponse<Object>> UpdateLabelWithHttpInfoAsync(long labelId, string xRequestId = default(string), LabelUpdate labelUpdate = default(LabelUpdate), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
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

            localVarRequestOptions.PathParameters.Add("labelId", Todoist.Client.ClientUtils.ParameterToString(labelId)); // path parameter
            if (xRequestId != null)
            {
                localVarRequestOptions.HeaderParameters.Add("X-Request-Id", Todoist.Client.ClientUtils.ParameterToString(xRequestId)); // header parameter
            }
            localVarRequestOptions.Data = labelUpdate;

            // authentication (OAuth) required
            // oauth required
            if (!string.IsNullOrEmpty(this.Configuration.AccessToken))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }

            // make the HTTP request

            var localVarResponse = await this.AsynchronousClient.PostAsync<Object>("/labels/{labelId}", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("UpdateLabel", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

    }
}
