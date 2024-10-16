using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Todoist.Test;

public class TokenApiTest
{
    [Fact]
    public async Task GetAuthTokenAsyncTest()
    {
        var handlerMock = new MockHttpMessageHandler
        {
            SendDelegate = async (r, _) =>
            {
                Assert.Equal("https://todoist.com/oauth/access_token", r.RequestUri?.AbsoluteUri);
                Assert.Equal(r.Method, HttpMethod.Post);
                var content = await r.Content!.ReadAsStringAsync();
                Assert.Contains("client_id=0123456789abcdef", content);
                Assert.Contains("client_secret=secret", content);
                Assert.Contains("code=abcdef", content);

                var response = new HttpResponseMessage(HttpStatusCode.OK);
                response.Content = new StringContent(
                    content: @"{
  ""access_token"": ""0123456789abcdef0123456789abcdef01234567"",
  ""token_type"": ""Bearer""
}",
                    encoding: Encoding.UTF8,
                    mediaType: "application/json");
                return response;
            }
        };
        var client = new TodoistClient(handlerMock);

        var response = await client.AuthToken.GetAsync(
            new Models.AuthTokenRequestArgs(
                clientId: "0123456789abcdef",
                clientSecret: "secret",
                code: "abcdef"));

        Assert.Equal("0123456789abcdef0123456789abcdef01234567", response.AccessToken);
        Assert.Equal("Bearer", response.TokenType);
    }

    [Fact]
    public async Task RevokeAuthTokenAsyncTest()
    {
        var handlerMock = new MockHttpMessageHandler
        {
            SendDelegate = async (r, _) =>
            {
                Assert.Equal("https://todoist.com/oauth/access_tokens/revoke", r.RequestUri?.AbsoluteUri);
                Assert.Equal(HttpMethod.Post, r.Method);
                var content = await r.Content!.ReadAsStringAsync();
                Assert.Contains("client_id=0123456789abcdef", content);
                Assert.Contains("client_secret=secret", content);
                Assert.Contains("access_token=0123456789abcdef0123456789abcdef01234567", content);

                var response = new HttpResponseMessage(HttpStatusCode.NoContent);
                return response;
            }
        };
        var client = new TodoistClient("TestToken", handlerMock);

        var actual = await client.AuthToken.RevokeAsync(
            new Models.RevokeAuthTokenRequestArgs(
                clientId: "0123456789abcdef",
                clientSecret: "secret",
                accessToken: "0123456789abcdef0123456789abcdef01234567"));

        Assert.True(actual);
    }
}
