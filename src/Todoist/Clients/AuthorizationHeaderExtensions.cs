using System.Net.Http;
using System.Net.Http.Headers;

namespace Todoist;

internal static class AuthorizationHeaderExtensions
{
    /// <summary>
    /// Sets an authorization header with a bearer token.
    /// </summary>
    /// <param name="client">The client.</param>
    /// <param name="token">The token</param>
    public static void SetBearerToken(this HttpClient client, string token) =>
        client.SetToken("Bearer", token);

    private static void SetToken(this HttpClient client, string schema, string token) =>
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(schema, token);
}
