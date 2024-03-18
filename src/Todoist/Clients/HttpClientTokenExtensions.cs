using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Todoist.Models;
using static Todoist.Constants.Endpoints;

namespace Todoist
{
    /// <summary>
    /// HttpClient extensions for Token requests
    /// </summary>
    public static class HttpClientTokenExtensions
    {
        /// <summary>
        /// Token exchange.
        /// </summary>
        public static async ValueTask<AuthTokenResponse> GetAuthTokenAsync(
            this HttpMessageInvoker client,
            AuthTokenRequestArgs args,
            CancellationToken cancellationToken = default)
        {
            var formContent = new FormUrlEncodedContent(new Dictionary<string, string>
            {
                ["client_id"] = args.ClientId,
                ["client_secret"] = args.ClientSecret,
                ["code"] = args.Code,
            });
            var response = await client.PostAsync(
                requestUri: $"{API_AUTHORIZATION_BASE_URI}{ENDPOINT_GET_TOKEN}",
                payload: formContent,
                cancellationToken: cancellationToken)
                .ConfigureAwait(false);
            return await response.DeserializeAsync<AuthTokenResponse>(cancellationToken)
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Revoke token.
        /// </summary>
        public static async ValueTask<bool> RevokeAuthTokenAsync(
            this HttpMessageInvoker client,
            RevokeAuthTokenRequestArgs args,
            CancellationToken cancellationToken = default)
        {
            var formContent = new FormUrlEncodedContent(new Dictionary<string, string>
            {
                ["client_id"] = args.ClientId,
                ["client_secret"] = args.ClientSecret,
                ["access_token"] = args.AccessToken,
            });
            var response = await client.PostAsync(
                requestUri: $"{API_AUTHORIZATION_BASE_URI}{ENDPOINT_REVOKE_TOKEN}",
                payload: formContent,
                cancellationToken: cancellationToken)
                .ConfigureAwait(false);
            return response.IsSuccessStatusCode;
        }
    }
}
