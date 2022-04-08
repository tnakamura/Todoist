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
    public class SectionsApiTest
    {
        [Fact]
        public async Task GetSectionsAsyncTest()
        {
            var handlerMock = new Mock<HttpMessageHandler>();
            handlerMock.Protected()
                .As<IHttpMessageHandler>()
                .Setup(m => m.SendAsync(
                    It.Is<HttpRequestMessage>(r =>
                        r.RequestUri.AbsoluteUri == (API_REST_BASE_URI + ENDPOINT_REST_SECTIONS + "?project_id=2203306141") &&
                        r.Method == HttpMethod.Get &&
                        r.Headers.Authorization.Scheme == "Bearer" &&
                        r.Headers.Authorization.Parameter == "TestToken"
                    ),
                    It.IsAny<CancellationToken>()))
                .Returns(() =>
                {
                    var response = new HttpResponseMessage(HttpStatusCode.OK);
                    response.Content = new StringContent(
                        content: @"[
    {
        ""id"": 7025,
        ""project_id"": 2203306141,
        ""order"": 1,
        ""name"": ""Groceries""
    }
]",
                        encoding: Encoding.UTF8,
                        mediaType: "application/json");
                    return Task.FromResult(response);
                });
            var client = new HttpClient(handlerMock.Object);
            client.SetBearerToken("TestToken");

            var sections = await client.GetSectionsAsync(projectId: 2203306141);

            Assert.Single(sections);
            Assert.Equal(7025, sections[0].Id);
            Assert.Equal(2203306141, sections[0].ProjectId);
            Assert.Equal(1, sections[0].Order);
            Assert.Equal("Groceries", sections[0].Name);
            handlerMock.VerifyAll();
        }

        [Fact]
        public async Task GetSectionAsyncTest()
        {
            var handlerMock = new Mock<HttpMessageHandler>();
            handlerMock.Protected()
                .As<IHttpMessageHandler>()
                .Setup(m => m.SendAsync(
                    It.Is<HttpRequestMessage>(r =>
                        r.RequestUri.AbsoluteUri == (API_REST_BASE_URI + ENDPOINT_REST_SECTIONS + "/7025") &&
                        r.Method == HttpMethod.Get &&
                        r.Headers.Authorization.Scheme == "Bearer" &&
                        r.Headers.Authorization.Parameter == "TestToken"
                    ),
                    It.IsAny<CancellationToken>()))
                .Returns(() =>
                {
                    var response = new HttpResponseMessage(HttpStatusCode.OK);
                    response.Content = new StringContent(
                        content: @"{
    ""id"": 7025,
    ""project_id"": 2203306141,
    ""order"": 1,
    ""name"": ""Groceries""
}",
                        encoding: Encoding.UTF8,
                        mediaType: "application/json");
                    return Task.FromResult(response);
                });
            var client = new HttpClient(handlerMock.Object);
            client.SetBearerToken("TestToken");

            var section = await client.GetSectionAsync(7025);

            Assert.Equal(7025, section.Id);
            Assert.Equal(2203306141, section.ProjectId);
            Assert.Equal(1, section.Order);
            Assert.Equal("Groceries", section.Name);
            handlerMock.VerifyAll();
        }

        [Fact]
        public async Task AddSectionAsyncTest()
        {
            var handlerMock = new Mock<HttpMessageHandler>();
            handlerMock.Protected()
                .As<IHttpMessageHandler>()
                .Setup(m => m.SendAsync(
                    It.Is<HttpRequestMessage>(r =>
                        r.RequestUri.AbsoluteUri == (API_REST_BASE_URI + ENDPOINT_REST_SECTIONS) &&
                        r.Method == HttpMethod.Post &&
                        r.Headers.Authorization.Scheme == "Bearer" &&
                        r.Headers.Authorization.Parameter == "TestToken" &&
                        r.Content.ReadAsStringAsync().GetAwaiter().GetResult().Contains("\"name\":\"Groceries\"") &&
                        r.Content.ReadAsStringAsync().GetAwaiter().GetResult().Contains("\"project_id\":2203306141")
                    ),
                    It.IsAny<CancellationToken>()))
                .Returns(() =>
                {
                    var response = new HttpResponseMessage(HttpStatusCode.OK);
                    response.Content = new StringContent(
                        content: @"{
    ""id"": 7025,
    ""project_id"": 2203306141,
    ""order"": 1,
    ""name"": ""Groceries""
}",
                        encoding: Encoding.UTF8,
                        mediaType: "application/json");
                    return Task.FromResult(response);
                });
            var client = new HttpClient(handlerMock.Object);
            client.SetBearerToken("TestToken");

            var section = await client.AddSectionAsync(
                new Models.AddSectionArgs(
                    name: "Groceries",
                    projectId: 2203306141));

            Assert.Equal(7025, section.Id);
            Assert.Equal(2203306141, section.ProjectId);
            Assert.Equal(1, section.Order);
            Assert.Equal("Groceries", section.Name);
            handlerMock.VerifyAll();
        }

        [Fact]
        public async Task UpdateSectionAsyncTest()
        {
            var handlerMock = new Mock<HttpMessageHandler>();
            handlerMock.Protected()
                .As<IHttpMessageHandler>()
                .Setup(m => m.SendAsync(
                    It.Is<HttpRequestMessage>(r =>
                        r.RequestUri.AbsoluteUri == (API_REST_BASE_URI + ENDPOINT_REST_SECTIONS + "/7025") &&
                        r.Method == HttpMethod.Post &&
                        r.Headers.Authorization.Scheme == "Bearer" &&
                        r.Headers.Authorization.Parameter == "TestToken" &&
                        r.Content.ReadAsStringAsync().GetAwaiter().GetResult().Contains("\"name\":\"Supermarket\"")
                    ),
                    It.IsAny<CancellationToken>()))
                .Returns(() =>
                {
                    var response = new HttpResponseMessage(HttpStatusCode.NoContent);
                    return Task.FromResult(response);
                });
            var client = new HttpClient(handlerMock.Object);
            client.SetBearerToken("TestToken");

            var actual = await client.UpdateSectionAsync(
                7025,
                new Models.UpdateSectionArgs(
                    name: "Supermarket"));

            Assert.True(actual);
            handlerMock.VerifyAll();
        }

        [Fact]
        public async Task DeleteSectionAsyncTest()
        {
            var handlerMock = new Mock<HttpMessageHandler>();
            handlerMock.Protected()
                .As<IHttpMessageHandler>()
                .Setup(m => m.SendAsync(
                    It.Is<HttpRequestMessage>(r =>
                        r.RequestUri.AbsoluteUri == (API_REST_BASE_URI + ENDPOINT_REST_SECTIONS + "/7025") &&
                        r.Method == HttpMethod.Delete &&
                        r.Headers.Authorization.Scheme == "Bearer" &&
                        r.Headers.Authorization.Parameter == "TestToken"
                    ),
                    It.IsAny<CancellationToken>()))
                .Returns(() =>
                {
                    var response = new HttpResponseMessage(HttpStatusCode.NoContent);
                    return Task.FromResult(response);
                });
            var client = new HttpClient(handlerMock.Object);
            client.SetBearerToken("TestToken");

            var actual = await client.DeleteSectionAsync(7025);

            Assert.True(actual);
            handlerMock.VerifyAll();
        }
    }
}
