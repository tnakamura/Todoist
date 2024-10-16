using System.Collections.Generic;
using System.Net.Http;
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
            ["client_id"] = args.ClientId,
            ["client_secret"] = args.ClientSecret,
            ["access_token"] = args.AccessToken,
        });
        var response = await _client.PostAsync(
            requestUri: $"{GetAuthBaseUri()}{ENDPOINT_REVOKE_TOKEN}",
            payload: formContent,
            cancellationToken: cancellationToken)
            .ConfigureAwait(false);
        return response.IsSuccessStatusCode;
    }
}
