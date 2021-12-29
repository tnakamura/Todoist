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
        ISectionsApi Sections { get; }
    }
    public partial class TodoistClient
    {
        private ISectionsApi _sections;

        public ISectionsApi Sections =>
            _sections ?? (_sections = CreateSectionsApi());

        private SectionsApi CreateSectionsApi()
        {
            if (_client != null && _configuration != null && _handler != null)
                return new SectionsApi(_client, _configuration, _handler); 
            if (_client != null && _basePath != null && _handler != null)
                return new SectionsApi(_client, _basePath, _handler); 
            if (_client != null &&  _handler != null)
                return new SectionsApi(_client, _handler); 
            if (_configuration != null)
                return new SectionsApi(_configuration); 
            if (_basePath != null)
                return new SectionsApi(_basePath); 
            return new SectionsApi();
        }
    }
}

namespace Todoist.Api
{

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface ISectionsApiSync : IApiAccessor
    {
        #region Synchronous Operations
        /// <summary>
        /// Create a new section
        /// </summary>
        /// <remarks>
        /// Creates a new section and returns it as a JSON object.
        /// </remarks>
        /// <exception cref="Todoist.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="xRequestId"> (optional)</param>
        /// <param name="newSection"> (optional)</param>
        /// <returns>Section</returns>
        Section CreateSection(string xRequestId = default(string), NewSection newSection = default(NewSection));

        /// <summary>
        /// Create a new section
        /// </summary>
        /// <remarks>
        /// Creates a new section and returns it as a JSON object.
        /// </remarks>
        /// <exception cref="Todoist.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="xRequestId"> (optional)</param>
        /// <param name="newSection"> (optional)</param>
        /// <returns>ApiResponse of Section</returns>
        ApiResponse<Section> CreateSectionWithHttpInfo(string xRequestId = default(string), NewSection newSection = default(NewSection));
        /// <summary>
        /// Delete a section
        /// </summary>
        /// <remarks>
        /// Delete a section.
        /// </remarks>
        /// <exception cref="Todoist.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="sectionId"></param>
        /// <returns></returns>
        void DeleteSection(long sectionId);

        /// <summary>
        /// Delete a section
        /// </summary>
        /// <remarks>
        /// Delete a section.
        /// </remarks>
        /// <exception cref="Todoist.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="sectionId"></param>
        /// <returns>ApiResponse of Object(void)</returns>
        ApiResponse<Object> DeleteSectionWithHttpInfo(long sectionId);
        /// <summary>
        /// Get a single section
        /// </summary>
        /// <remarks>
        /// Returns a single section as a JSON object
        /// </remarks>
        /// <exception cref="Todoist.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="sectionId"></param>
        /// <returns>Section</returns>
        Section GetSection(long sectionId);

        /// <summary>
        /// Get a single section
        /// </summary>
        /// <remarks>
        /// Returns a single section as a JSON object
        /// </remarks>
        /// <exception cref="Todoist.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="sectionId"></param>
        /// <returns>ApiResponse of Section</returns>
        ApiResponse<Section> GetSectionWithHttpInfo(long sectionId);
        /// <summary>
        /// Get all sections
        /// </summary>
        /// <remarks>
        /// Returns a JSON array of all sections.
        /// </remarks>
        /// <exception cref="Todoist.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>List&lt;Section&gt;</returns>
        List<Section> GetSections();

        /// <summary>
        /// Get all sections
        /// </summary>
        /// <remarks>
        /// Returns a JSON array of all sections.
        /// </remarks>
        /// <exception cref="Todoist.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>ApiResponse of List&lt;Section&gt;</returns>
        ApiResponse<List<Section>> GetSectionsWithHttpInfo();
        /// <summary>
        /// Update a section
        /// </summary>
        /// <remarks>
        /// Updates the section for the given ID.
        /// </remarks>
        /// <exception cref="Todoist.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="sectionId"></param>
        /// <param name="xRequestId"> (optional)</param>
        /// <param name="sectionUpdate"> (optional)</param>
        /// <returns></returns>
        void UpdateSection(long sectionId, string xRequestId = default(string), SectionUpdate sectionUpdate = default(SectionUpdate));

        /// <summary>
        /// Update a section
        /// </summary>
        /// <remarks>
        /// Updates the section for the given ID.
        /// </remarks>
        /// <exception cref="Todoist.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="sectionId"></param>
        /// <param name="xRequestId"> (optional)</param>
        /// <param name="sectionUpdate"> (optional)</param>
        /// <returns>ApiResponse of Object(void)</returns>
        ApiResponse<Object> UpdateSectionWithHttpInfo(long sectionId, string xRequestId = default(string), SectionUpdate sectionUpdate = default(SectionUpdate));
        #endregion Synchronous Operations
    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface ISectionsApiAsync : IApiAccessor
    {
        #region Asynchronous Operations
        /// <summary>
        /// Create a new section
        /// </summary>
        /// <remarks>
        /// Creates a new section and returns it as a JSON object.
        /// </remarks>
        /// <exception cref="Todoist.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="xRequestId"> (optional)</param>
        /// <param name="newSection"> (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of Section</returns>
        System.Threading.Tasks.Task<Section> CreateSectionAsync(string xRequestId = default(string), NewSection newSection = default(NewSection), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// Create a new section
        /// </summary>
        /// <remarks>
        /// Creates a new section and returns it as a JSON object.
        /// </remarks>
        /// <exception cref="Todoist.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="xRequestId"> (optional)</param>
        /// <param name="newSection"> (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (Section)</returns>
        System.Threading.Tasks.Task<ApiResponse<Section>> CreateSectionWithHttpInfoAsync(string xRequestId = default(string), NewSection newSection = default(NewSection), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// Delete a section
        /// </summary>
        /// <remarks>
        /// Delete a section.
        /// </remarks>
        /// <exception cref="Todoist.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="sectionId"></param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of void</returns>
        System.Threading.Tasks.Task DeleteSectionAsync(long sectionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// Delete a section
        /// </summary>
        /// <remarks>
        /// Delete a section.
        /// </remarks>
        /// <exception cref="Todoist.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="sectionId"></param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse</returns>
        System.Threading.Tasks.Task<ApiResponse<Object>> DeleteSectionWithHttpInfoAsync(long sectionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// Get a single section
        /// </summary>
        /// <remarks>
        /// Returns a single section as a JSON object
        /// </remarks>
        /// <exception cref="Todoist.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="sectionId"></param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of Section</returns>
        System.Threading.Tasks.Task<Section> GetSectionAsync(long sectionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// Get a single section
        /// </summary>
        /// <remarks>
        /// Returns a single section as a JSON object
        /// </remarks>
        /// <exception cref="Todoist.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="sectionId"></param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (Section)</returns>
        System.Threading.Tasks.Task<ApiResponse<Section>> GetSectionWithHttpInfoAsync(long sectionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// Get all sections
        /// </summary>
        /// <remarks>
        /// Returns a JSON array of all sections.
        /// </remarks>
        /// <exception cref="Todoist.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of List&lt;Section&gt;</returns>
        System.Threading.Tasks.Task<List<Section>> GetSectionsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// Get all sections
        /// </summary>
        /// <remarks>
        /// Returns a JSON array of all sections.
        /// </remarks>
        /// <exception cref="Todoist.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (List&lt;Section&gt;)</returns>
        System.Threading.Tasks.Task<ApiResponse<List<Section>>> GetSectionsWithHttpInfoAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// Update a section
        /// </summary>
        /// <remarks>
        /// Updates the section for the given ID.
        /// </remarks>
        /// <exception cref="Todoist.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="sectionId"></param>
        /// <param name="xRequestId"> (optional)</param>
        /// <param name="sectionUpdate"> (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of void</returns>
        System.Threading.Tasks.Task UpdateSectionAsync(long sectionId, string xRequestId = default(string), SectionUpdate sectionUpdate = default(SectionUpdate), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// Update a section
        /// </summary>
        /// <remarks>
        /// Updates the section for the given ID.
        /// </remarks>
        /// <exception cref="Todoist.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="sectionId"></param>
        /// <param name="xRequestId"> (optional)</param>
        /// <param name="sectionUpdate"> (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse</returns>
        System.Threading.Tasks.Task<ApiResponse<Object>> UpdateSectionWithHttpInfoAsync(long sectionId, string xRequestId = default(string), SectionUpdate sectionUpdate = default(SectionUpdate), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        #endregion Asynchronous Operations
    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface ISectionsApi : ISectionsApiSync, ISectionsApiAsync
    {

    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    internal partial class SectionsApi : IDisposable, ISectionsApi
    {
        private Todoist.Client.ExceptionFactory _exceptionFactory = (name, response) => null;

        /// <summary>
        /// Initializes a new instance of the <see cref="SectionsApi"/> class.
        /// **IMPORTANT** This will also create an instance of HttpClient, which is less than ideal.
        /// It's better to reuse the <see href="https://docs.microsoft.com/en-us/dotnet/architecture/microservices/implement-resilient-applications/use-httpclientfactory-to-implement-resilient-http-requests#issues-with-the-original-httpclient-class-available-in-net">HttpClient and HttpClientHandler</see>.
        /// </summary>
        /// <returns></returns>
        public SectionsApi() : this((string)null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SectionsApi"/> class.
        /// **IMPORTANT** This will also create an instance of HttpClient, which is less than ideal.
        /// It's better to reuse the <see href="https://docs.microsoft.com/en-us/dotnet/architecture/microservices/implement-resilient-applications/use-httpclientfactory-to-implement-resilient-http-requests#issues-with-the-original-httpclient-class-available-in-net">HttpClient and HttpClientHandler</see>.
        /// </summary>
        /// <param name="basePath">The target service's base path in URL format.</param>
        /// <exception cref="ArgumentException"></exception>
        /// <returns></returns>
        public SectionsApi(string basePath)
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
        /// Initializes a new instance of the <see cref="SectionsApi"/> class using Configuration object.
        /// **IMPORTANT** This will also create an instance of HttpClient, which is less than ideal.
        /// It's better to reuse the <see href="https://docs.microsoft.com/en-us/dotnet/architecture/microservices/implement-resilient-applications/use-httpclientfactory-to-implement-resilient-http-requests#issues-with-the-original-httpclient-class-available-in-net">HttpClient and HttpClientHandler</see>.
        /// </summary>
        /// <param name="configuration">An instance of Configuration.</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <returns></returns>
        public SectionsApi(Todoist.Client.Configuration configuration)
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
        /// Initializes a new instance of the <see cref="SectionsApi"/> class.
        /// </summary>
        /// <param name="client">An instance of HttpClient.</param>
        /// <param name="handler">An optional instance of HttpClientHandler that is used by HttpClient.</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <returns></returns>
        /// <remarks>
        /// Some configuration settings will not be applied without passing an HttpClientHandler.
        /// The features affected are: Setting and Retrieving Cookies, Client Certificates, Proxy settings.
        /// </remarks>
        public SectionsApi(HttpClient client, HttpClientHandler handler = null) : this(client, (string)null, handler)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SectionsApi"/> class.
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
        public SectionsApi(HttpClient client, string basePath, HttpClientHandler handler = null)
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
        /// Initializes a new instance of the <see cref="SectionsApi"/> class using Configuration object.
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
        public SectionsApi(HttpClient client, Todoist.Client.Configuration configuration, HttpClientHandler handler = null)
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
        /// Initializes a new instance of the <see cref="SectionsApi"/> class
        /// using a Configuration object and client instance.
        /// </summary>
        /// <param name="client">The client interface for synchronous API access.</param>
        /// <param name="asyncClient">The client interface for asynchronous API access.</param>
        /// <param name="configuration">The configuration object.</param>
        /// <exception cref="ArgumentNullException"></exception>
        internal SectionsApi(Todoist.Client.ISynchronousClient client, Todoist.Client.IAsynchronousClient asyncClient, Todoist.Client.IReadableConfiguration configuration)
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
        /// Create a new section
        /// </summary>
        /// <remarks>
        /// Creates a new section and returns it as a JSON object.
        /// </remarks>
        /// <exception cref="Todoist.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="xRequestId"> (optional)</param>
        /// <param name="newSection"> (optional)</param>
        /// <returns>Section</returns>
        public Section CreateSection(string xRequestId = default(string), NewSection newSection = default(NewSection))
        {
            Todoist.Client.ApiResponse<Section> localVarResponse = CreateSectionWithHttpInfo(xRequestId, newSection);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Create a new section
        /// </summary>
        /// <remarks>
        /// Creates a new section and returns it as a JSON object.
        /// </remarks>
        /// <exception cref="Todoist.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="xRequestId"> (optional)</param>
        /// <param name="newSection"> (optional)</param>
        /// <returns>ApiResponse of Section</returns>
        public Todoist.Client.ApiResponse<Section> CreateSectionWithHttpInfo(string xRequestId = default(string), NewSection newSection = default(NewSection))
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
            localVarRequestOptions.Data = newSection;

            // authentication (OAuth) required
            // oauth required
            if (!string.IsNullOrEmpty(this.Configuration.AccessToken))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }

            // make the HTTP request
            var localVarResponse = this.Client.Post<Section>("/sections", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("CreateSection", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// Create a new section
        /// </summary>
        /// <remarks>
        /// Creates a new section and returns it as a JSON object.
        /// </remarks>
        /// <exception cref="Todoist.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="xRequestId"> (optional)</param>
        /// <param name="newSection"> (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of Section</returns>
        public async System.Threading.Tasks.Task<Section> CreateSectionAsync(string xRequestId = default(string), NewSection newSection = default(NewSection), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Todoist.Client.ApiResponse<Section> localVarResponse = await CreateSectionWithHttpInfoAsync(xRequestId, newSection, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Create a new section
        /// </summary>
        /// <remarks>
        /// Creates a new section and returns it as a JSON object.
        /// </remarks>
        /// <exception cref="Todoist.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="xRequestId"> (optional)</param>
        /// <param name="newSection"> (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (Section)</returns>
        public async System.Threading.Tasks.Task<Todoist.Client.ApiResponse<Section>> CreateSectionWithHttpInfoAsync(string xRequestId = default(string), NewSection newSection = default(NewSection), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
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
            localVarRequestOptions.Data = newSection;

            // authentication (OAuth) required
            // oauth required
            if (!string.IsNullOrEmpty(this.Configuration.AccessToken))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }

            // make the HTTP request

            var localVarResponse = await this.AsynchronousClient.PostAsync<Section>("/sections", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("CreateSection", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// Delete a section
        /// </summary>
        /// <remarks>
        /// Delete a section.
        /// </remarks>
        /// <exception cref="Todoist.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="sectionId"></param>
        /// <returns></returns>
        public void DeleteSection(long sectionId)
        {
            DeleteSectionWithHttpInfo(sectionId);
        }

        /// <summary>
        /// Delete a section
        /// </summary>
        /// <remarks>
        /// Delete a section.
        /// </remarks>
        /// <exception cref="Todoist.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="sectionId"></param>
        /// <returns>ApiResponse of Object(void)</returns>
        public Todoist.Client.ApiResponse<Object> DeleteSectionWithHttpInfo(long sectionId)
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

            localVarRequestOptions.PathParameters.Add("sectionId", Todoist.Client.ClientUtils.ParameterToString(sectionId)); // path parameter

            // authentication (OAuth) required
            // oauth required
            if (!string.IsNullOrEmpty(this.Configuration.AccessToken))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }

            // make the HTTP request
            var localVarResponse = this.Client.Delete<Object>("/sections/{sectionId}", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("DeleteSection", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// Delete a section
        /// </summary>
        /// <remarks>
        /// Delete a section.
        /// </remarks>
        /// <exception cref="Todoist.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="sectionId"></param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of void</returns>
        public async System.Threading.Tasks.Task DeleteSectionAsync(long sectionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            await DeleteSectionWithHttpInfoAsync(sectionId, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Delete a section
        /// </summary>
        /// <remarks>
        /// Delete a section.
        /// </remarks>
        /// <exception cref="Todoist.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="sectionId"></param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse</returns>
        public async System.Threading.Tasks.Task<Todoist.Client.ApiResponse<Object>> DeleteSectionWithHttpInfoAsync(long sectionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
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

            localVarRequestOptions.PathParameters.Add("sectionId", Todoist.Client.ClientUtils.ParameterToString(sectionId)); // path parameter

            // authentication (OAuth) required
            // oauth required
            if (!string.IsNullOrEmpty(this.Configuration.AccessToken))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }

            // make the HTTP request

            var localVarResponse = await this.AsynchronousClient.DeleteAsync<Object>("/sections/{sectionId}", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("DeleteSection", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// Get a single section
        /// </summary>
        /// <remarks>
        /// Returns a single section as a JSON object
        /// </remarks>
        /// <exception cref="Todoist.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="sectionId"></param>
        /// <returns>Section</returns>
        public Section GetSection(long sectionId)
        {
            Todoist.Client.ApiResponse<Section> localVarResponse = GetSectionWithHttpInfo(sectionId);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Get a single section
        /// </summary>
        /// <remarks>
        /// Returns a single section as a JSON object
        /// </remarks>
        /// <exception cref="Todoist.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="sectionId"></param>
        /// <returns>ApiResponse of Section</returns>
        public Todoist.Client.ApiResponse<Section> GetSectionWithHttpInfo(long sectionId)
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

            localVarRequestOptions.PathParameters.Add("sectionId", Todoist.Client.ClientUtils.ParameterToString(sectionId)); // path parameter

            // authentication (OAuth) required
            // oauth required
            if (!string.IsNullOrEmpty(this.Configuration.AccessToken))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }

            // make the HTTP request
            var localVarResponse = this.Client.Get<Section>("/sections/{sectionId}", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetSection", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// Get a single section
        /// </summary>
        /// <remarks>
        /// Returns a single section as a JSON object
        /// </remarks>
        /// <exception cref="Todoist.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="sectionId"></param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of Section</returns>
        public async System.Threading.Tasks.Task<Section> GetSectionAsync(long sectionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Todoist.Client.ApiResponse<Section> localVarResponse = await GetSectionWithHttpInfoAsync(sectionId, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Get a single section
        /// </summary>
        /// <remarks>
        /// Returns a single section as a JSON object
        /// </remarks>
        /// <exception cref="Todoist.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="sectionId"></param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (Section)</returns>
        public async System.Threading.Tasks.Task<Todoist.Client.ApiResponse<Section>> GetSectionWithHttpInfoAsync(long sectionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
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

            localVarRequestOptions.PathParameters.Add("sectionId", Todoist.Client.ClientUtils.ParameterToString(sectionId)); // path parameter

            // authentication (OAuth) required
            // oauth required
            if (!string.IsNullOrEmpty(this.Configuration.AccessToken))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }

            // make the HTTP request

            var localVarResponse = await this.AsynchronousClient.GetAsync<Section>("/sections/{sectionId}", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetSection", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// Get all sections
        /// </summary>
        /// <remarks>
        /// Returns a JSON array of all sections.
        /// </remarks>
        /// <exception cref="Todoist.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>List&lt;Section&gt;</returns>
        public List<Section> GetSections()
        {
            Todoist.Client.ApiResponse<List<Section>> localVarResponse = GetSectionsWithHttpInfo();
            return localVarResponse.Data;
        }

        /// <summary>
        /// Get all sections
        /// </summary>
        /// <remarks>
        /// Returns a JSON array of all sections.
        /// </remarks>
        /// <exception cref="Todoist.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>ApiResponse of List&lt;Section&gt;</returns>
        public Todoist.Client.ApiResponse<List<Section>> GetSectionsWithHttpInfo()
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
            var localVarResponse = this.Client.Get<List<Section>>("/sections", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetSections", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// Get all sections
        /// </summary>
        /// <remarks>
        /// Returns a JSON array of all sections.
        /// </remarks>
        /// <exception cref="Todoist.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of List&lt;Section&gt;</returns>
        public async System.Threading.Tasks.Task<List<Section>> GetSectionsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Todoist.Client.ApiResponse<List<Section>> localVarResponse = await GetSectionsWithHttpInfoAsync(cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Get all sections
        /// </summary>
        /// <remarks>
        /// Returns a JSON array of all sections.
        /// </remarks>
        /// <exception cref="Todoist.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (List&lt;Section&gt;)</returns>
        public async System.Threading.Tasks.Task<Todoist.Client.ApiResponse<List<Section>>> GetSectionsWithHttpInfoAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
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

            var localVarResponse = await this.AsynchronousClient.GetAsync<List<Section>>("/sections", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetSections", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// Update a section
        /// </summary>
        /// <remarks>
        /// Updates the section for the given ID.
        /// </remarks>
        /// <exception cref="Todoist.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="sectionId"></param>
        /// <param name="xRequestId"> (optional)</param>
        /// <param name="sectionUpdate"> (optional)</param>
        /// <returns></returns>
        public void UpdateSection(long sectionId, string xRequestId = default(string), SectionUpdate sectionUpdate = default(SectionUpdate))
        {
            UpdateSectionWithHttpInfo(sectionId, xRequestId, sectionUpdate);
        }

        /// <summary>
        /// Update a section
        /// </summary>
        /// <remarks>
        /// Updates the section for the given ID.
        /// </remarks>
        /// <exception cref="Todoist.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="sectionId"></param>
        /// <param name="xRequestId"> (optional)</param>
        /// <param name="sectionUpdate"> (optional)</param>
        /// <returns>ApiResponse of Object(void)</returns>
        public Todoist.Client.ApiResponse<Object> UpdateSectionWithHttpInfo(long sectionId, string xRequestId = default(string), SectionUpdate sectionUpdate = default(SectionUpdate))
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

            localVarRequestOptions.PathParameters.Add("sectionId", Todoist.Client.ClientUtils.ParameterToString(sectionId)); // path parameter
            if (xRequestId != null)
            {
                localVarRequestOptions.HeaderParameters.Add("X-Request-Id", Todoist.Client.ClientUtils.ParameterToString(xRequestId)); // header parameter
            }
            localVarRequestOptions.Data = sectionUpdate;

            // authentication (OAuth) required
            // oauth required
            if (!string.IsNullOrEmpty(this.Configuration.AccessToken))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }

            // make the HTTP request
            var localVarResponse = this.Client.Post<Object>("/sections/{sectionId}", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("UpdateSection", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// Update a section
        /// </summary>
        /// <remarks>
        /// Updates the section for the given ID.
        /// </remarks>
        /// <exception cref="Todoist.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="sectionId"></param>
        /// <param name="xRequestId"> (optional)</param>
        /// <param name="sectionUpdate"> (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of void</returns>
        public async System.Threading.Tasks.Task UpdateSectionAsync(long sectionId, string xRequestId = default(string), SectionUpdate sectionUpdate = default(SectionUpdate), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            await UpdateSectionWithHttpInfoAsync(sectionId, xRequestId, sectionUpdate, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Update a section
        /// </summary>
        /// <remarks>
        /// Updates the section for the given ID.
        /// </remarks>
        /// <exception cref="Todoist.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="sectionId"></param>
        /// <param name="xRequestId"> (optional)</param>
        /// <param name="sectionUpdate"> (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse</returns>
        public async System.Threading.Tasks.Task<Todoist.Client.ApiResponse<Object>> UpdateSectionWithHttpInfoAsync(long sectionId, string xRequestId = default(string), SectionUpdate sectionUpdate = default(SectionUpdate), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
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

            localVarRequestOptions.PathParameters.Add("sectionId", Todoist.Client.ClientUtils.ParameterToString(sectionId)); // path parameter
            if (xRequestId != null)
            {
                localVarRequestOptions.HeaderParameters.Add("X-Request-Id", Todoist.Client.ClientUtils.ParameterToString(xRequestId)); // header parameter
            }
            localVarRequestOptions.Data = sectionUpdate;

            // authentication (OAuth) required
            // oauth required
            if (!string.IsNullOrEmpty(this.Configuration.AccessToken))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }

            // make the HTTP request

            var localVarResponse = await this.AsynchronousClient.PostAsync<Object>("/sections/{sectionId}", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("UpdateSection", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

    }
}
