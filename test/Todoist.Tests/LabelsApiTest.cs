using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NSubstitute;
using Xunit;
using static Todoist.Constants.Endpoints;

namespace Todoist.Test;

public class LabelsApiTest
{
    [Fact]
    public async Task GetAllAsyncTest()
    {
        var handlerMock = Substitute.For<MockHttpMessageHandler>();
        handlerMock.MockSend(
            Arg.Is<HttpRequestMessage>(r =>
                r.RequestUri.AbsoluteUri == (API_REST_BASE_URI + ENDPOINT_REST_LABELS) &&
                r.Method == HttpMethod.Get &&
                r.Headers.Authorization.Scheme == "Bearer" &&
                r.Headers.Authorization.Parameter == "TestToken"
            ),
            Arg.Any<CancellationToken>())
            .Returns(_ =>
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
                return response;
            });
        var client = new TodoistClient("TestToken", handlerMock);

        var labels = await client.Labels.GetAllAsync();

        Assert.Single(labels);
        Assert.Equal(2156154810, labels[0].Id);
        Assert.Equal("Food", labels[0].Name);
        Assert.Equal(47, labels[0].Color);
        Assert.Equal(1, labels[0].Order);
        Assert.False(labels[0].Favorite);
    }

    [Fact]
    public async Task GetAsyncTest()
    {
        var handlerMock = Substitute.For<MockHttpMessageHandler>();
        handlerMock.MockSend(
                Arg.Is<HttpRequestMessage>(r =>
                    r.RequestUri.AbsoluteUri == (API_REST_BASE_URI + ENDPOINT_REST_LABELS + "/2156154810") &&
                    r.Method == HttpMethod.Get &&
                    r.Headers.Authorization.Scheme == "Bearer" &&
                    r.Headers.Authorization.Parameter == "TestToken"
                ),
                Arg.Any<CancellationToken>())
            .Returns(_ =>
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
                return response;
            });
        var client = new TodoistClient("TestToken", handlerMock);

        var label = await client.Labels.GetAsync(2156154810);

        Assert.Equal(2156154810, label.Id);
        Assert.Equal("Food", label.Name);
        Assert.Equal(47, label.Color);
        Assert.Equal(1, label.Order);
        Assert.False(label.Favorite);
    }

    [Fact]
    public async Task CreateAsyncTest()
    {
        var handlerMock = Substitute.For<MockHttpMessageHandler>();
        handlerMock.MockSend(
                Arg.Is<HttpRequestMessage>(r =>
                    r.RequestUri.AbsoluteUri == (API_REST_BASE_URI + ENDPOINT_REST_LABELS) &&
                    r.Method == HttpMethod.Post &&
                    r.Headers.Authorization.Scheme == "Bearer" &&
                    r.Headers.Authorization.Parameter == "TestToken" &&
                    r.Content.ReadAsStringAsync().GetAwaiter().GetResult().Contains("\"name\":\"Food\"")
                ),
                Arg.Any<CancellationToken>())
            .Returns(_ =>
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
                return response;
            });
        var client = new TodoistClient("TestToken", handlerMock);

        var label = await client.Labels.CreateAsync(
            new Models.CreateLabelArgs(
                name: "Food"));

        Assert.Equal(2156154810, label.Id);
        Assert.Equal("Food", label.Name);
        Assert.Equal(47, label.Color);
        Assert.Equal(1, label.Order);
        Assert.False(label.Favorite);
    }

    [Fact]
    public async Task UpdateAsyncTest()
    {
        var handlerMock = Substitute.For<MockHttpMessageHandler>();
        handlerMock.MockSend(
                Arg.Is<HttpRequestMessage>(r =>
                    r.RequestUri.AbsoluteUri == (API_REST_BASE_URI + ENDPOINT_REST_LABELS + "/2156154810") &&
                    r.Method == HttpMethod.Post &&
                    r.Headers.Authorization.Scheme == "Bearer" &&
                    r.Headers.Authorization.Parameter == "TestToken" &&
                    r.Content.ReadAsStringAsync().GetAwaiter().GetResult().Contains("\"name\":\"Drinks\"")
                ),
                Arg.Any<CancellationToken>())
            .Returns(_ =>
            {
                var response = new HttpResponseMessage(HttpStatusCode.NoContent);
                return response;
            });
        var client = new TodoistClient("TestToken", handlerMock);

        var actual = await client.Labels.UpdateAsync(
            2156154810,
            new Models.UpdateLabelArgs(
                name: "Drinks"));

        Assert.True(actual);
    }

    [Fact]
    public async Task DeleteAsyncTest()
    {
        var handlerMock = Substitute.For<MockHttpMessageHandler>();
        handlerMock.MockSend(
                Arg.Is<HttpRequestMessage>(r =>
                    r.RequestUri.AbsoluteUri == (API_REST_BASE_URI + ENDPOINT_REST_LABELS + "/2156154810") &&
                    r.Method == HttpMethod.Delete &&
                    r.Headers.Authorization.Scheme == "Bearer" &&
                    r.Headers.Authorization.Parameter == "TestToken"
                ),
                Arg.Any<CancellationToken>())
            .Returns(_ =>
            {
                var response = new HttpResponseMessage(HttpStatusCode.NoContent);
                return response;
            });
        var client = new TodoistClient("TestToken", handlerMock);

        var actual = await client.Labels.DeleteAsync(2156154810);

        Assert.True(actual);
    }
}
