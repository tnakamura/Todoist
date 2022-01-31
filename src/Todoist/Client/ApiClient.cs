using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

[assembly: System.Runtime.CompilerServices.InternalsVisibleTo("Todoist.Test")]

namespace Todoist
{
    using Todoist.Client;

    /// <summary>
    /// Todoist REST API
    /// </summary>
    public partial interface ITodoistClient
    {
        IReadableConfiguration Configuration { get; }
    }

    /// <inheritdoc cref="ITodoistClient"/>
    public partial class TodoistClient : ITodoistClient
    {
        private readonly Configuration _configuration;

        private readonly string _basePath;

        private readonly HttpClient _client;

        private readonly HttpClientHandler _handler;

        public IReadableConfiguration Configuration => _configuration;

        /// <summary>
        /// Initializes a new instance of the <see cref="TodoistClient"/> class.
        /// **IMPORTANT** This will also create an instance of HttpClient, which is less than ideal.
        /// It's better to reuse the <see href="https://docs.microsoft.com/en-us/dotnet/architecture/microservices/implement-resilient-applications/use-httpclientfactory-to-implement-resilient-http-requests#issues-with-the-original-httpclient-class-available-in-net">HttpClient and HttpClientHandler</see>.
        /// </summary>
        /// <returns></returns>
        public TodoistClient() :
            this((string)null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TodoistClient"/> class.
        /// **IMPORTANT** This will also create an instance of HttpClient, which is less than ideal.
        /// It's better to reuse the <see href="https://docs.microsoft.com/en-us/dotnet/architecture/microservices/implement-resilient-applications/use-httpclientfactory-to-implement-resilient-http-requests#issues-with-the-original-httpclient-class-available-in-net">HttpClient and HttpClientHandler</see>.
        /// </summary>
        /// <param name="basePath">The target service's base path in URL format.</param>
        /// <exception cref="ArgumentException"></exception>
        /// <returns></returns>
        public TodoistClient(string basePath)
        {
            _basePath = basePath;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TodoistClient"/> class using Configuration object.
        /// **IMPORTANT** This will also create an instance of HttpClient, which is less than ideal.
        /// It's better to reuse the <see href="https://docs.microsoft.com/en-us/dotnet/architecture/microservices/implement-resilient-applications/use-httpclientfactory-to-implement-resilient-http-requests#issues-with-the-original-httpclient-class-available-in-net">HttpClient and HttpClientHandler</see>.
        /// </summary>
        /// <param name="configuration">An instance of Configuration.</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <returns></returns>
        public TodoistClient(Todoist.Client.Configuration configuration)
        {
            if (configuration == null) throw new ArgumentNullException(nameof(configuration));
            _configuration = configuration;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TodoistClient"/> class.
        /// </summary>
        /// <param name="client">An instance of HttpClient.</param>
        /// <param name="handler">An optional instance of HttpClientHandler that is used by HttpClient.</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <returns></returns>
        /// <remarks>
        /// Some configuration settings will not be applied without passing an HttpClientHandler.
        /// The features affected are: Setting and Retrieving Cookies, Client Certificates, Proxy settings.
        /// </remarks>
        public TodoistClient(HttpClient client, HttpClientHandler handler = null) :
            this(client, (string)null, handler)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TodoistClient"/> class.
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
        public TodoistClient(HttpClient client, string basePath, HttpClientHandler handler = null)
        {
            if (client == null) throw new ArgumentNullException(nameof(client));
            _client = client;
            _basePath = basePath;
            _handler = handler;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TodoistClient"/> class using Configuration object.
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
        public TodoistClient(HttpClient client, Todoist.Client.Configuration configuration, HttpClientHandler handler = null)
        {
            if (configuration == null) throw new ArgumentNullException(nameof(configuration));
            if (client == null) throw new ArgumentNullException(nameof(client));
            _client = client;
            _configuration = configuration;
            _handler = handler;
        }
    }
}

namespace Todoist.Client
{
    /// <summary>
    /// To Serialize/Deserialize JSON using our custom logic, but only when ContentType is JSON.
    /// </summary>
    internal class CustomJsonCodec
    {
        private readonly IReadableConfiguration _configuration;
        private static readonly string _contentType = "application/json";
        private readonly JsonSerializerSettings _serializerSettings = new JsonSerializerSettings
        {
            // OpenAPI generated types generally hide default constructors.
            ConstructorHandling = ConstructorHandling.AllowNonPublicDefaultConstructor,
            ContractResolver = new DefaultContractResolver
            {
                NamingStrategy = new CamelCaseNamingStrategy
                {
                    OverrideSpecifiedNames = false
                }
            }
        };

        public CustomJsonCodec(IReadableConfiguration configuration)
        {
            _configuration = configuration;
        }

        public CustomJsonCodec(JsonSerializerSettings serializerSettings, IReadableConfiguration configuration)
        {
            _serializerSettings = serializerSettings;
            _configuration = configuration;
        }

        /// <summary>
        /// Serialize the object into a JSON string.
        /// </summary>
        /// <param name="obj">Object to be serialized.</param>
        /// <returns>A JSON string.</returns>
        public string Serialize(object obj)
        {
            return JsonConvert.SerializeObject(obj, _serializerSettings);
        }

        public async Task<T> Deserialize<T>(HttpResponseMessage response)
        {
            var result = (T)await Deserialize(response, typeof(T));
            return result;
        }

        /// <summary>
        /// Deserialize the JSON string into a proper object.
        /// </summary>
        /// <param name="response">The HTTP response.</param>
        /// <param name="type">Object type.</param>
        /// <returns>Object representation of the JSON string.</returns>
        internal async Task<object> Deserialize(HttpResponseMessage response, Type type)
        {
            IList<string> headers = response.Headers.Select(x => x.Key + "=" + x.Value).ToList();

            if (type == typeof(byte[])) // return byte array
            {
                return await response.Content.ReadAsByteArrayAsync();
            }

            // TODO: ? if (type.IsAssignableFrom(typeof(Stream)))
            if (type == typeof(Stream))
            {
                var bytes = await response.Content.ReadAsByteArrayAsync();
                if (headers != null)
                {
                    var filePath = string.IsNullOrEmpty(_configuration.TempFolderPath)
                        ? Path.GetTempPath()
                        : _configuration.TempFolderPath;
                    var regex = new Regex(@"Content-Disposition=.*filename=['""]?([^'""\s]+)['""]?$");
                    foreach (var header in headers)
                    {
                        var match = regex.Match(header.ToString());
                        if (match.Success)
                        {
                            string fileName = filePath + ClientUtils.SanitizeFilename(match.Groups[1].Value.Replace("\"", "").Replace("'", ""));
                            File.WriteAllBytes(fileName, bytes);
                            return new FileStream(fileName, FileMode.Open);
                        }
                    }
                }
                var stream = new MemoryStream(bytes);
                return stream;
            }

            if (type.Name.StartsWith("System.Nullable`1[[System.DateTime")) // return a datetime object
            {
                return DateTime.Parse(await response.Content.ReadAsStringAsync(), null, System.Globalization.DateTimeStyles.RoundtripKind);
            }

            if (type == typeof(string) || type.Name.StartsWith("System.Nullable")) // return primitive type
            {
                return Convert.ChangeType(await response.Content.ReadAsStringAsync(), type);
            }

            // at this point, it must be a model (json)
            try
            {
                return JsonConvert.DeserializeObject(await response.Content.ReadAsStringAsync(), type, _serializerSettings);
            }
            catch (Exception e)
            {
                throw new ApiException(500, e.Message);
            }
        }

        public string RootElement { get; set; }
        public string Namespace { get; set; }
        public string DateFormat { get; set; }

        public string ContentType
        {
            get { return _contentType; }
            set { throw new InvalidOperationException("Not allowed to set content type."); }
        }
    }
    /// <summary>
    /// Provides a default implementation of an Api client (both synchronous and asynchronous implementations),
    /// encapsulating general REST accessor use cases.
    /// </summary>
    /// <remarks>
    /// The Dispose method will manage the HttpClient lifecycle when not passed by constructor.
    /// </remarks>
    internal partial class ApiClient : IDisposable, ISynchronousClient, IAsynchronousClient
    {
        private readonly string _baseUrl;

        private readonly HttpClientHandler _httpClientHandler;
        private readonly HttpClient _httpClient;
        private readonly bool _disposeClient;

        /// <summary>
        /// Specifies the settings on a <see cref="JsonSerializer" /> object.
        /// These settings can be adjusted to accommodate custom serialization rules.
        /// </summary>
        public JsonSerializerSettings SerializerSettings { get; set; } = new JsonSerializerSettings
        {
            // OpenAPI generated types generally hide default constructors.
            ConstructorHandling = ConstructorHandling.AllowNonPublicDefaultConstructor,
            ContractResolver = new DefaultContractResolver
            {
                NamingStrategy = new CamelCaseNamingStrategy
                {
                    OverrideSpecifiedNames = false
                }
            }
        };

        /// <summary>
        /// Initializes a new instance of the <see cref="ApiClient" />, defaulting to the global configurations' base url.
        /// **IMPORTANT** This will also create an instance of HttpClient, which is less than ideal.
        /// It's better to reuse the <see href="https://docs.microsoft.com/en-us/dotnet/architecture/microservices/implement-resilient-applications/use-httpclientfactory-to-implement-resilient-http-requests#issues-with-the-original-httpclient-class-available-in-net">HttpClient and HttpClientHandler</see>.
        /// </summary>
        public ApiClient() :
                 this(Todoist.Client.GlobalConfiguration.Instance.BasePath)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ApiClient" />.
        /// **IMPORTANT** This will also create an instance of HttpClient, which is less than ideal.
        /// It's better to reuse the <see href="https://docs.microsoft.com/en-us/dotnet/architecture/microservices/implement-resilient-applications/use-httpclientfactory-to-implement-resilient-http-requests#issues-with-the-original-httpclient-class-available-in-net">HttpClient and HttpClientHandler</see>.
        /// </summary>
        /// <param name="basePath">The target service's base path in URL format.</param>
        /// <exception cref="ArgumentException"></exception>
        public ApiClient(string basePath)
        {
            if (string.IsNullOrEmpty(basePath)) throw new ArgumentException("basePath cannot be empty");

            _httpClientHandler = new HttpClientHandler();
            _httpClient = new HttpClient(_httpClientHandler, true);
            _disposeClient = true;
            _baseUrl = basePath;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ApiClient" />, defaulting to the global configurations' base url.
        /// </summary>
        /// <param name="client">An instance of HttpClient.</param>
        /// <param name="handler">An optional instance of HttpClientHandler that is used by HttpClient.</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <remarks>
        /// Some configuration settings will not be applied without passing an HttpClientHandler.
        /// The features affected are: Setting and Retrieving Cookies, Client Certificates, Proxy settings.
        /// </remarks>
        public ApiClient(HttpClient client, HttpClientHandler handler = null) :
                 this(client, Todoist.Client.GlobalConfiguration.Instance.BasePath, handler)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ApiClient" />.
        /// </summary>
        /// <param name="client">An instance of HttpClient.</param>
        /// <param name="basePath">The target service's base path in URL format.</param>
        /// <param name="handler">An optional instance of HttpClientHandler that is used by HttpClient.</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        /// <remarks>
        /// Some configuration settings will not be applied without passing an HttpClientHandler.
        /// The features affected are: Setting and Retrieving Cookies, Client Certificates, Proxy settings.
        /// </remarks>
        public ApiClient(HttpClient client, string basePath, HttpClientHandler handler = null)
        {
            if (client == null) throw new ArgumentNullException("client cannot be null");
            if (string.IsNullOrEmpty(basePath)) throw new ArgumentException("basePath cannot be empty");

            _httpClientHandler = handler;
            _httpClient = client;
            _baseUrl = basePath;
        }

        /// <summary>
        /// Disposes resources if they were created by us
        /// </summary>
        public void Dispose()
        {
            if (_disposeClient)
            {
                _httpClient.Dispose();
            }
        }

        /// Prepares multipart/form-data content
        HttpContent PrepareMultipartFormDataContent(RequestOptions options)
        {
            string boundary = "---------" + Guid.NewGuid().ToString().ToUpperInvariant();
            var multipartContent = new MultipartFormDataContent(boundary);
            foreach (var formParameter in options.FormParameters)
            {
                multipartContent.Add(new StringContent(formParameter.Value), formParameter.Key);
            }

            if (options.FileParameters != null && options.FileParameters.Count > 0)
            {
                foreach (var fileParam in options.FileParameters)
                {
                    var content = new StreamContent(fileParam.Value.Content);
                    content.Headers.ContentType = new MediaTypeHeaderValue(fileParam.Value.ContentType);
                    multipartContent.Add(content, fileParam.Key,
                        fileParam.Value.Name);
                }
            }
            return multipartContent;
        }

        /// <summary>
        /// Provides all logic for constructing a new HttpRequestMessage.
        /// At this point, all information for querying the service is known. Here, it is simply
        /// mapped into the a HttpRequestMessage.
        /// </summary>
        /// <param name="method">The http verb.</param>
        /// <param name="path">The target path (or resource).</param>
        /// <param name="options">The additional request options.</param>
        /// <param name="configuration">A per-request configuration object. It is assumed that any merge with
        /// GlobalConfiguration has been done before calling this method.</param>
        /// <returns>[private] A new HttpRequestMessage instance.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        private HttpRequestMessage NewRequest(
            HttpMethod method,
            string path,
            RequestOptions options,
            IReadableConfiguration configuration)
        {
            if (path == null) throw new ArgumentNullException("path");
            if (options == null) throw new ArgumentNullException("options");
            if (configuration == null) throw new ArgumentNullException("configuration");

            WebRequestPathBuilder builder = new WebRequestPathBuilder(_baseUrl, path);

            builder.AddPathParameters(options.PathParameters);

            builder.AddQueryParameters(options.QueryParameters);

            HttpRequestMessage request = new HttpRequestMessage(method, builder.GetFullUri());

            if (configuration.UserAgent != null)
            {
                request.Headers.TryAddWithoutValidation("User-Agent", configuration.UserAgent);
            }

            if (configuration.DefaultHeaders != null)
            {
                foreach (var headerParam in configuration.DefaultHeaders)
                {
                    request.Headers.Add(headerParam.Key, headerParam.Value);
                }
            }

            if (options.HeaderParameters != null)
            {
                foreach (var headerParam in options.HeaderParameters)
                {
                    foreach (var value in headerParam.Value)
                    {
                        // Todo make content headers actually content headers
                        request.Headers.TryAddWithoutValidation(headerParam.Key, value);
                    }
                }
            }

            List<Tuple<HttpContent, string, string>> contentList = new List<Tuple<HttpContent, string, string>>();

            string contentType = null;
            if (options.HeaderParameters != null && options.HeaderParameters.ContainsKey("Content-Type"))
            {
                var contentTypes = options.HeaderParameters["Content-Type"];
                contentType = contentTypes.FirstOrDefault();
            }

            if (contentType == "multipart/form-data")
            {
                request.Content = PrepareMultipartFormDataContent(options);
            }
            else if (contentType == "application/x-www-form-urlencoded")
            {
                request.Content = new FormUrlEncodedContent(options.FormParameters);
            }
            else
            {
                if (options.Data != null)
                {
                    if (options.Data is FileParameter fp)
                    {
                        contentType = contentType ?? "application/octet-stream";

                        var streamContent = new StreamContent(fp.Content);
                        streamContent.Headers.ContentType = new MediaTypeHeaderValue(contentType);
                        request.Content = streamContent;
                    }
                    else
                    {
                        var serializer = new CustomJsonCodec(SerializerSettings, configuration);
                        request.Content = new StringContent(serializer.Serialize(options.Data), new UTF8Encoding(),
                            "application/json");
                    }
                }
            }



            // TODO provide an alternative that allows cookies per request instead of per API client
            if (options.Cookies != null && options.Cookies.Count > 0)
            {
                request.Properties["CookieContainer"] = options.Cookies;
            }

            return request;
        }

        partial void InterceptRequest(HttpRequestMessage req);
        partial void InterceptResponse(HttpRequestMessage req, HttpResponseMessage response);

        private async Task<ApiResponse<T>> ToApiResponse<T>(HttpResponseMessage response, object responseData, Uri uri)
        {
            T result = (T)responseData;
            string rawContent = await response.Content.ReadAsStringAsync();

            var transformed = new ApiResponse<T>(response.StatusCode, new Multimap<string, string>(), result, rawContent)
            {
                ErrorText = response.ReasonPhrase,
                Cookies = new List<Cookie>()
            };

            // process response headers, e.g. Access-Control-Allow-Methods
            if (response.Headers != null)
            {
                foreach (var responseHeader in response.Headers)
                {
                    transformed.Headers.Add(responseHeader.Key, ClientUtils.ParameterToString(responseHeader.Value));
                }
            }

            // process response content headers, e.g. Content-Type
            if (response.Content.Headers != null)
            {
                foreach (var responseHeader in response.Content.Headers)
                {
                    transformed.Headers.Add(responseHeader.Key, ClientUtils.ParameterToString(responseHeader.Value));
                }
            }

            if (_httpClientHandler != null && response != null)
            {
                try
                {
                    foreach (Cookie cookie in _httpClientHandler.CookieContainer.GetCookies(uri))
                    {
                        transformed.Cookies.Add(cookie);
                    }
                }
                catch (PlatformNotSupportedException) { }
            }

            return transformed;
        }

        private ApiResponse<T> Exec<T>(HttpRequestMessage req, IReadableConfiguration configuration)
        {
            return ExecAsync<T>(req, configuration).GetAwaiter().GetResult();
        }

        private async Task<ApiResponse<T>> ExecAsync<T>(HttpRequestMessage req,
            IReadableConfiguration configuration,
            System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            var deserializer = new CustomJsonCodec(SerializerSettings, configuration);

            var finalToken = cancellationToken;

            if (configuration.Timeout > 0)
            {
                var tokenSource = new CancellationTokenSource(configuration.Timeout);
                finalToken = CancellationTokenSource.CreateLinkedTokenSource(finalToken, tokenSource.Token).Token;
            }

            if (configuration.Proxy != null)
            {
                if (_httpClientHandler == null) throw new InvalidOperationException("Configuration `Proxy` not supported when the client is explicitly created without an HttpClientHandler, use the proper constructor.");
                _httpClientHandler.Proxy = configuration.Proxy;
            }

            if (configuration.ClientCertificates != null)
            {
                if (_httpClientHandler == null) throw new InvalidOperationException("Configuration `ClientCertificates` not supported when the client is explicitly created without an HttpClientHandler, use the proper constructor.");
                _httpClientHandler.ClientCertificates.AddRange(configuration.ClientCertificates);
            }

            var cookieContainer = req.Properties.ContainsKey("CookieContainer") ? req.Properties["CookieContainer"] as List<Cookie> : null;

            if (cookieContainer != null)
            {
                if (_httpClientHandler == null) throw new InvalidOperationException("Request property `CookieContainer` not supported when the client is explicitly created without an HttpClientHandler, use the proper constructor.");
                foreach (var cookie in cookieContainer)
                {
                    _httpClientHandler.CookieContainer.Add(cookie);
                }
            }

            InterceptRequest(req);

            var response = await _httpClient.SendAsync(req, cancellationToken).ConfigureAwait(false);

            if (!response.IsSuccessStatusCode)
            {
                return await ToApiResponse<T>(response, default(T), req.RequestUri);
            }

            object responseData = await deserializer.Deserialize<T>(response);

            if (typeof(T).Name == "Stream") // for binary response
            {
                responseData = (T)(object)await response.Content.ReadAsStreamAsync();
            }

            InterceptResponse(req, response);

            return await ToApiResponse<T>(response, responseData, req.RequestUri);
        }

        #region IAsynchronousClient
        /// <summary>
        /// Make a HTTP GET request (async).
        /// </summary>
        /// <param name="path">The target path (or resource).</param>
        /// <param name="options">The additional request options.</param>
        /// <param name="configuration">A per-request configuration object. It is assumed that any merge with
        /// GlobalConfiguration has been done before calling this method.</param>
        /// <param name="cancellationToken">Token that enables callers to cancel the request.</param>
        /// <returns>A Task containing ApiResponse</returns>
        public Task<ApiResponse<T>> GetAsync<T>(string path, RequestOptions options, IReadableConfiguration configuration = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            var config = configuration ?? GlobalConfiguration.Instance;
            return ExecAsync<T>(NewRequest(HttpMethod.Get, path, options, config), config, cancellationToken);
        }

        /// <summary>
        /// Make a HTTP POST request (async).
        /// </summary>
        /// <param name="path">The target path (or resource).</param>
        /// <param name="options">The additional request options.</param>
        /// <param name="configuration">A per-request configuration object. It is assumed that any merge with
        /// GlobalConfiguration has been done before calling this method.</param>
        /// <param name="cancellationToken">Token that enables callers to cancel the request.</param>
        /// <returns>A Task containing ApiResponse</returns>
        public Task<ApiResponse<T>> PostAsync<T>(string path, RequestOptions options, IReadableConfiguration configuration = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            var config = configuration ?? GlobalConfiguration.Instance;
            return ExecAsync<T>(NewRequest(HttpMethod.Post, path, options, config), config, cancellationToken);
        }

        /// <summary>
        /// Make a HTTP PUT request (async).
        /// </summary>
        /// <param name="path">The target path (or resource).</param>
        /// <param name="options">The additional request options.</param>
        /// <param name="configuration">A per-request configuration object. It is assumed that any merge with
        /// GlobalConfiguration has been done before calling this method.</param>
        /// <param name="cancellationToken">Token that enables callers to cancel the request.</param>
        /// <returns>A Task containing ApiResponse</returns>
        public Task<ApiResponse<T>> PutAsync<T>(string path, RequestOptions options, IReadableConfiguration configuration = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            var config = configuration ?? GlobalConfiguration.Instance;
            return ExecAsync<T>(NewRequest(HttpMethod.Put, path, options, config), config, cancellationToken);
        }

        /// <summary>
        /// Make a HTTP DELETE request (async).
        /// </summary>
        /// <param name="path">The target path (or resource).</param>
        /// <param name="options">The additional request options.</param>
        /// <param name="configuration">A per-request configuration object. It is assumed that any merge with
        /// GlobalConfiguration has been done before calling this method.</param>
        /// <param name="cancellationToken">Token that enables callers to cancel the request.</param>
        /// <returns>A Task containing ApiResponse</returns>
        public Task<ApiResponse<T>> DeleteAsync<T>(string path, RequestOptions options, IReadableConfiguration configuration = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            var config = configuration ?? GlobalConfiguration.Instance;
            return ExecAsync<T>(NewRequest(HttpMethod.Delete, path, options, config), config, cancellationToken);
        }

        /// <summary>
        /// Make a HTTP HEAD request (async).
        /// </summary>
        /// <param name="path">The target path (or resource).</param>
        /// <param name="options">The additional request options.</param>
        /// <param name="configuration">A per-request configuration object. It is assumed that any merge with
        /// GlobalConfiguration has been done before calling this method.</param>
        /// <param name="cancellationToken">Token that enables callers to cancel the request.</param>
        /// <returns>A Task containing ApiResponse</returns>
        public Task<ApiResponse<T>> HeadAsync<T>(string path, RequestOptions options, IReadableConfiguration configuration = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            var config = configuration ?? GlobalConfiguration.Instance;
            return ExecAsync<T>(NewRequest(HttpMethod.Head, path, options, config), config, cancellationToken);
        }

        /// <summary>
        /// Make a HTTP OPTION request (async).
        /// </summary>
        /// <param name="path">The target path (or resource).</param>
        /// <param name="options">The additional request options.</param>
        /// <param name="configuration">A per-request configuration object. It is assumed that any merge with
        /// GlobalConfiguration has been done before calling this method.</param>
        /// <param name="cancellationToken">Token that enables callers to cancel the request.</param>
        /// <returns>A Task containing ApiResponse</returns>
        public Task<ApiResponse<T>> OptionsAsync<T>(string path, RequestOptions options, IReadableConfiguration configuration = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            var config = configuration ?? GlobalConfiguration.Instance;
            return ExecAsync<T>(NewRequest(HttpMethod.Options, path, options, config), config, cancellationToken);
        }

        /// <summary>
        /// Make a HTTP PATCH request (async).
        /// </summary>
        /// <param name="path">The target path (or resource).</param>
        /// <param name="options">The additional request options.</param>
        /// <param name="configuration">A per-request configuration object. It is assumed that any merge with
        /// GlobalConfiguration has been done before calling this method.</param>
        /// <param name="cancellationToken">Token that enables callers to cancel the request.</param>
        /// <returns>A Task containing ApiResponse</returns>
        public Task<ApiResponse<T>> PatchAsync<T>(string path, RequestOptions options, IReadableConfiguration configuration = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            var config = configuration ?? GlobalConfiguration.Instance;
            return ExecAsync<T>(NewRequest(new HttpMethod("PATCH"), path, options, config), config, cancellationToken);
        }
        #endregion IAsynchronousClient

        #region ISynchronousClient
        /// <summary>
        /// Make a HTTP GET request (synchronous).
        /// </summary>
        /// <param name="path">The target path (or resource).</param>
        /// <param name="options">The additional request options.</param>
        /// <param name="configuration">A per-request configuration object. It is assumed that any merge with
        /// GlobalConfiguration has been done before calling this method.</param>
        /// <returns>A Task containing ApiResponse</returns>
        public ApiResponse<T> Get<T>(string path, RequestOptions options, IReadableConfiguration configuration = null)
        {
            var config = configuration ?? GlobalConfiguration.Instance;
            return Exec<T>(NewRequest(HttpMethod.Get, path, options, config), config);
        }

        /// <summary>
        /// Make a HTTP POST request (synchronous).
        /// </summary>
        /// <param name="path">The target path (or resource).</param>
        /// <param name="options">The additional request options.</param>
        /// <param name="configuration">A per-request configuration object. It is assumed that any merge with
        /// GlobalConfiguration has been done before calling this method.</param>
        /// <returns>A Task containing ApiResponse</returns>
        public ApiResponse<T> Post<T>(string path, RequestOptions options, IReadableConfiguration configuration = null)
        {
            var config = configuration ?? GlobalConfiguration.Instance;
            return Exec<T>(NewRequest(HttpMethod.Post, path, options, config), config);
        }

        /// <summary>
        /// Make a HTTP PUT request (synchronous).
        /// </summary>
        /// <param name="path">The target path (or resource).</param>
        /// <param name="options">The additional request options.</param>
        /// <param name="configuration">A per-request configuration object. It is assumed that any merge with
        /// GlobalConfiguration has been done before calling this method.</param>
        /// <returns>A Task containing ApiResponse</returns>
        public ApiResponse<T> Put<T>(string path, RequestOptions options, IReadableConfiguration configuration = null)
        {
            var config = configuration ?? GlobalConfiguration.Instance;
            return Exec<T>(NewRequest(HttpMethod.Put, path, options, config), config);
        }

        /// <summary>
        /// Make a HTTP DELETE request (synchronous).
        /// </summary>
        /// <param name="path">The target path (or resource).</param>
        /// <param name="options">The additional request options.</param>
        /// <param name="configuration">A per-request configuration object. It is assumed that any merge with
        /// GlobalConfiguration has been done before calling this method.</param>
        /// <returns>A Task containing ApiResponse</returns>
        public ApiResponse<T> Delete<T>(string path, RequestOptions options, IReadableConfiguration configuration = null)
        {
            var config = configuration ?? GlobalConfiguration.Instance;
            return Exec<T>(NewRequest(HttpMethod.Delete, path, options, config), config);
        }

        /// <summary>
        /// Make a HTTP HEAD request (synchronous).
        /// </summary>
        /// <param name="path">The target path (or resource).</param>
        /// <param name="options">The additional request options.</param>
        /// <param name="configuration">A per-request configuration object. It is assumed that any merge with
        /// GlobalConfiguration has been done before calling this method.</param>
        /// <returns>A Task containing ApiResponse</returns>
        public ApiResponse<T> Head<T>(string path, RequestOptions options, IReadableConfiguration configuration = null)
        {
            var config = configuration ?? GlobalConfiguration.Instance;
            return Exec<T>(NewRequest(HttpMethod.Head, path, options, config), config);
        }

        /// <summary>
        /// Make a HTTP OPTION request (synchronous).
        /// </summary>
        /// <param name="path">The target path (or resource).</param>
        /// <param name="options">The additional request options.</param>
        /// <param name="configuration">A per-request configuration object. It is assumed that any merge with
        /// GlobalConfiguration has been done before calling this method.</param>
        /// <returns>A Task containing ApiResponse</returns>
        public ApiResponse<T> Options<T>(string path, RequestOptions options, IReadableConfiguration configuration = null)
        {
            var config = configuration ?? GlobalConfiguration.Instance;
            return Exec<T>(NewRequest(HttpMethod.Options, path, options, config), config);
        }

        /// <summary>
        /// Make a HTTP PATCH request (synchronous).
        /// </summary>
        /// <param name="path">The target path (or resource).</param>
        /// <param name="options">The additional request options.</param>
        /// <param name="configuration">A per-request configuration object. It is assumed that any merge with
        /// GlobalConfiguration has been done before calling this method.</param>
        /// <returns>A Task containing ApiResponse</returns>
        public ApiResponse<T> Patch<T>(string path, RequestOptions options, IReadableConfiguration configuration = null)
        {
            var config = configuration ?? GlobalConfiguration.Instance;
            return Exec<T>(NewRequest(new HttpMethod("PATCH"), path, options, config), config);
        }
        #endregion ISynchronousClient
    }
}
