using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Moq;
using Moq.Protected;
using Xunit;
using static Todoist.Constants.Endpoints;

namespace Todoist.Test
{
    public class TokenApiTest
    {
        [Fact]
        public async Task GetAuthTokenAsyncTest()
        {
            var handlerMock = new Mock<HttpMessageHandler>();
            handlerMock.Protected()
                .As<IHttpMessageHandler>()
                .Setup(m => m.SendAsync(
                    It.Is<HttpRequestMessage>(r =>
                        r.RequestUri.AbsoluteUri == (API_AUTHORIZATION_BASE_URI + ENDPOINT_GET_TOKEN) &&
                        r.Method == HttpMethod.Post &&
                        r.Content.ReadAsStringAsync().GetAwaiter().GetResult().Contains("client_id=0123456789abcdef") &&
                        r.Content.ReadAsStringAsync().GetAwaiter().GetResult().Contains("client_secret=secret") &&
                        r.Content.ReadAsStringAsync().GetAwaiter().GetResult().Contains("code=abcdef")
                    ),
                    It.IsAny<CancellationToken>()))
                .Returns(() =>
                {
                    var response = new HttpResponseMessage(HttpStatusCode.OK);
                    response.Content = new StringContent(
                        content: @"{
  ""access_token"": ""0123456789abcdef0123456789abcdef01234567"",
  ""token_type"": ""Bearer""
}",
                        encoding: Encoding.UTF8,
                        mediaType: "application/json");
                    return Task.FromResult(response);
                });
            var client = new TodoistClient(handlerMock.Object);

            var response = await client.AuthToken.GetAsync(
                new Models.AuthTokenRequestArgs(
                    clientId: "0123456789abcdef",
                    clientSecret: "secret",
                    code: "abcdef"));

            Assert.Equal("0123456789abcdef0123456789abcdef01234567", response.AccessToken);
            Assert.Equal("Bearer", response.TokenType);
            handlerMock.VerifyAll();
        }

        [Fact]
        public async Task RevokeAuthTokenAsyncTest()
        {
            var handlerMock = new Mock<HttpMessageHandler>();
            handlerMock.Protected()
                .As<IHttpMessageHandler>()
                .Setup(m => m.SendAsync(
                    It.Is<HttpRequestMessage>(r =>
                        r.RequestUri.AbsoluteUri == (API_AUTHORIZATION_BASE_URI + ENDPOINT_REVOKE_TOKEN) &&
                        r.Method == HttpMethod.Post &&
                        r.Content.ReadAsStringAsync().GetAwaiter().GetResult().Contains("client_id=0123456789abcdef") &&
                        r.Content.ReadAsStringAsync().GetAwaiter().GetResult().Contains("client_secret=secret") &&
                        r.Content.ReadAsStringAsync().GetAwaiter().GetResult().Contains("access_token=0123456789abcdef0123456789abcdef01234567")
                    ),
                    It.IsAny<CancellationToken>()))
                .Returns(() =>
                {
                    var response = new HttpResponseMessage(HttpStatusCode.NoContent);
                    return Task.FromResult(response);
                });
            var client = new TodoistClient("TestToken", handlerMock.Object);

            var actual = await client.AuthToken.RevokeAsync(
                new Models.RevokeAuthTokenRequestArgs(
                    clientId: "0123456789abcdef",
                    clientSecret: "secret",
                    accessToken: "0123456789abcdef0123456789abcdef01234567"));

            Assert.True(actual);
            handlerMock.VerifyAll();
        }
    }
}
