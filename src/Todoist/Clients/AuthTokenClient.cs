using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Todoist.Clients;
using Todoist.Models;
using static Todoist.Endpoints;

namespace Todoist;

public partial class TodoistClient : IAuthTokenClient
{
    async ValueTask<AuthTokenResponse> IAuthTokenClient.GetAsync(AuthTokenRequestArgs args, CancellationToken cancellationToken)
    {
        var formContent = new FormUrlEncodedContent(new Dictionary<string, string>
        {
            ["client_id"] = args.ClientId,
            ["client_secret"] = args.ClientSecret,
            ["code"] = args.Code,
        });
        var response = await _client.PostAsync(
            requestUri: $"{GetAuthBaseUri()}{ENDPOINT_GET_TOKEN}",
            payload: formContent,
            cancellationToken: cancellationToken)
            .ConfigureAwait(false);
        return await response.DeserializeAsync<AuthTokenResponse>(cancellationToken)
            .ConfigureAwait(false);
    }

    async ValueTask<bool> IAuthTokenClient.RevokeAsync(RevokeAuthTokenRequestArgs args, CancellationToken cancellationToken)
    {
        var formContent = new FormUrlEncodedContent(new Dictionary<string, string>
        {
            ["token"] = args.AccessToken,
            ["token_type_hint"] = "access_token",
        });
        var basicAuthCredentials = Convert.ToBase64String(Encoding.UTF8.GetBytes($"{args.ClientId}:{args.ClientSecret}"));
        var request = new HttpRequestMessage(HttpMethod.Post, $"{GetSyncBaseUri()}{ENDPOINT_REVOKE_TOKEN}")
        {
            Content = formContent
        };
        request.Headers.Authorization = new AuthenticationHeaderValue("Basic", basicAuthCredentials);
        var response = await _client.SendAsync(request, cancellationToken)
            .ConfigureAwait(false);
        return response.IsSuccessStatusCode;
    }
}
