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
    public class LabelsApiTest
    {
        [Fact]
        public async Task GetLabelsAsyncTest()
        {
            var handlerMock = new Mock<HttpMessageHandler>();
            handlerMock.Protected()
                .As<IHttpMessageHandler>()
                .Setup(m => m.SendAsync(
                    It.Is<HttpRequestMessage>(r =>
                        r.RequestUri.AbsoluteUri == (API_REST_BASE_URI + ENDPOINT_REST_LABELS) &&
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
        ""id"": 2156154810,
        ""name"": ""Food"",
        ""color"": 47,
        ""order"": 1,
        ""favorite"": false
    }
]",
                        encoding: Encoding.UTF8,
                        mediaType: "application/json");
                    return Task.FromResult(response);
                });
            var client = new HttpClient(handlerMock.Object);
            client.SetBearerToken("TestToken");

            var labels = await client.GetLabelsAsync();

            Assert.Single(labels);
            Assert.Equal(2156154810, labels[0].Id);
            Assert.Equal("Food", labels[0].Name);
            Assert.Equal(47, labels[0].Color);
            Assert.Equal(1, labels[0].Order);
            Assert.False(labels[0].Favorite);
            handlerMock.VerifyAll();
        }

        [Fact]
        public async Task GetLabelAsyncTest()
        {
            var handlerMock = new Mock<HttpMessageHandler>();
            handlerMock.Protected()
                .As<IHttpMessageHandler>()
                .Setup(m => m.SendAsync(
                    It.Is<HttpRequestMessage>(r =>
                        r.RequestUri.AbsoluteUri == (API_REST_BASE_URI + ENDPOINT_REST_LABELS + "/2156154810") &&
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
    ""id"": 2156154810,
    ""name"": ""Food"",
    ""color"": 47,
    ""order"": 1,
    ""favorite"": false
}",
                        encoding: Encoding.UTF8,
                        mediaType: "application/json");
                    return Task.FromResult(response);
                });
            var client = new HttpClient(handlerMock.Object);
            client.SetBearerToken("TestToken");

            var label = await client.GetLabelAsync(2156154810);

            Assert.Equal(2156154810, label.Id);
            Assert.Equal("Food", label.Name);
            Assert.Equal(47, label.Color);
            Assert.Equal(1, label.Order);
            Assert.False(label.Favorite);
            handlerMock.VerifyAll();
        }

        [Fact]
        public async Task AddLabelAsyncTest()
        {
            var handlerMock = new Mock<HttpMessageHandler>();
            handlerMock.Protected()
                .As<IHttpMessageHandler>()
                .Setup(m => m.SendAsync(
                    It.Is<HttpRequestMessage>(r =>
                        r.RequestUri.AbsoluteUri == (API_REST_BASE_URI + ENDPOINT_REST_LABELS) &&
                        r.Method == HttpMethod.Post &&
                        r.Headers.Authorization.Scheme == "Bearer" &&
                        r.Headers.Authorization.Parameter == "TestToken" &&
                        r.Content.ReadAsStringAsync().GetAwaiter().GetResult().Contains("\"name\":\"Food\"")
                    ),
                    It.IsAny<CancellationToken>()))
                .Returns(() =>
                {
                    var response = new HttpResponseMessage(HttpStatusCode.OK);
                    response.Content = new StringContent(
                        content: @"{
    ""id"": 2156154810,
    ""name"": ""Food"",
    ""color"": 47,
    ""order"": 1,
    ""favorite"": false
}",
                        encoding: Encoding.UTF8,
                        mediaType: "application/json");
                    return Task.FromResult(response);
                });
            var client = new HttpClient(handlerMock.Object);
            client.SetBearerToken("TestToken");

            var label = await client.AddLabelAsync(
                new Models.AddLabelArgs(
                    name: "Food"));

            Assert.Equal(2156154810, label.Id);
            Assert.Equal("Food", label.Name);
            Assert.Equal(47, label.Color);
            Assert.Equal(1, label.Order);
            Assert.False(label.Favorite);
            handlerMock.VerifyAll();
        }

        [Fact]
        public async Task UpdateLabelAsyncTest()
        {
            var handlerMock = new Mock<HttpMessageHandler>();
            handlerMock.Protected()
                .As<IHttpMessageHandler>()
                .Setup(m => m.SendAsync(
                    It.Is<HttpRequestMessage>(r =>
                        r.RequestUri.AbsoluteUri == (API_REST_BASE_URI + ENDPOINT_REST_LABELS + "/2156154810") &&
                        r.Method == HttpMethod.Post &&
                        r.Headers.Authorization.Scheme == "Bearer" &&
                        r.Headers.Authorization.Parameter == "TestToken" &&
                        r.Content.ReadAsStringAsync().GetAwaiter().GetResult().Contains("\"name\":\"Drinks\"")
                    ),
                    It.IsAny<CancellationToken>()))
                .Returns(() =>
                {
                    var response = new HttpResponseMessage(HttpStatusCode.NoContent);
                    return Task.FromResult(response);
                });
            var client = new HttpClient(handlerMock.Object);
            client.SetBearerToken("TestToken");

            var actual = await client.UpdateLabelAsync(
                2156154810,
                new Models.UpdateLabelArgs(
                    name: "Drinks"));

            Assert.True(actual);
            handlerMock.VerifyAll();
        }

        [Fact]
        public async Task DeleteLabelAsyncTest()
        {
            var handlerMock = new Mock<HttpMessageHandler>();
            handlerMock.Protected()
                .As<IHttpMessageHandler>()
                .Setup(m => m.SendAsync(
                    It.Is<HttpRequestMessage>(r =>
                        r.RequestUri.AbsoluteUri == (API_REST_BASE_URI + ENDPOINT_REST_LABELS + "/2156154810") &&
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

            var actual = await client.DeleteLabelAsync(2156154810);

            Assert.True(actual);
            handlerMock.VerifyAll();
        }
    }
}
