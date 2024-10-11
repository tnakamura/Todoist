using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NSubstitute;
using Xunit;
using static Todoist.Constants.Endpoints;

namespace Todoist.Test;

public class SectionsApiTest
{
    [Fact]
    public async Task GetAllAsyncTest()
    {
        var handlerMock = Substitute.For<MockHttpMessageHandler>();
        handlerMock.MockSend(
                Arg.Is<HttpRequestMessage>(r =>
                    r.RequestUri.AbsoluteUri == (API_REST_BASE_URI + ENDPOINT_REST_SECTIONS + "?project_id=2203306141") &&
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
        ""id"": 7025,
        ""project_id"": 2203306141,
        ""order"": 1,
        ""name"": ""Groceries""
    }
]",
                    encoding: Encoding.UTF8,
                    mediaType: "application/json");
                return response;
            });
        var client = new TodoistClient("TestToken", handlerMock);

        var sections = await client.Sections.GetAllAsync(projectId: 2203306141);

        Assert.Single(sections);
        Assert.Equal(7025, sections[0].Id);
        Assert.Equal(2203306141, sections[0].ProjectId);
        Assert.Equal(1, sections[0].Order);
        Assert.Equal("Groceries", sections[0].Name);
    }

    [Fact]
    public async Task GetAsyncTest()
    {
        var handlerMock = Substitute.For<MockHttpMessageHandler>();
        handlerMock.MockSend(
                Arg.Is<HttpRequestMessage>(r =>
                    r.RequestUri.AbsoluteUri == (API_REST_BASE_URI + ENDPOINT_REST_SECTIONS + "/7025") &&
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
    ""id"": 7025,
    ""project_id"": 2203306141,
    ""order"": 1,
    ""name"": ""Groceries""
}",
                    encoding: Encoding.UTF8,
                    mediaType: "application/json");
                return response;
            });
        var client = new TodoistClient("TestToken", handlerMock);

        var section = await client.Sections.GetAsync(7025);

        Assert.Equal(7025, section.Id);
        Assert.Equal(2203306141, section.ProjectId);
        Assert.Equal(1, section.Order);
        Assert.Equal("Groceries", section.Name);
    }

    [Fact]
    public async Task CreateAsyncTest()
    {
        var handlerMock = Substitute.For<MockHttpMessageHandler>();
        handlerMock.MockSend(
                Arg.Is<HttpRequestMessage>(r =>
                    r.RequestUri.AbsoluteUri == (API_REST_BASE_URI + ENDPOINT_REST_SECTIONS) &&
                    r.Method == HttpMethod.Post &&
                    r.Headers.Authorization.Scheme == "Bearer" &&
                    r.Headers.Authorization.Parameter == "TestToken" &&
                    r.Content.ReadAsStringAsync().GetAwaiter().GetResult().Contains("\"name\":\"Groceries\"") &&
                    r.Content.ReadAsStringAsync().GetAwaiter().GetResult().Contains("\"project_id\":2203306141")
                ),
                Arg.Any<CancellationToken>())
            .Returns(_ =>
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
                return response;
            });
        var client = new TodoistClient("TestToken", handlerMock);

        var section = await client.Sections.CreateAsync(
            new Models.CreateSectionArgs(
                name: "Groceries",
                projectId: 2203306141));

        Assert.Equal(7025, section.Id);
        Assert.Equal(2203306141, section.ProjectId);
        Assert.Equal(1, section.Order);
        Assert.Equal("Groceries", section.Name);
    }

    [Fact]
    public async Task UpdateAsyncTest()
    {
        var handlerMock = Substitute.For<MockHttpMessageHandler>();
        handlerMock.MockSend(
                Arg.Is<HttpRequestMessage>(r =>
                    r.RequestUri.AbsoluteUri == (API_REST_BASE_URI + ENDPOINT_REST_SECTIONS + "/7025") &&
                    r.Method == HttpMethod.Post &&
                    r.Headers.Authorization.Scheme == "Bearer" &&
                    r.Headers.Authorization.Parameter == "TestToken" &&
                    r.Content.ReadAsStringAsync().GetAwaiter().GetResult().Contains("\"name\":\"Supermarket\"")
                ),
                Arg.Any<CancellationToken>())
            .Returns(_ =>
            {
                var response = new HttpResponseMessage(HttpStatusCode.NoContent);
                return response;
            });
        var client = new TodoistClient("TestToken", handlerMock);

        var actual = await client.Sections.UpdateAsync(
            7025,
            new Models.UpdateSectionArgs(
                name: "Supermarket"));

        Assert.True(actual);
    }

    [Fact]
    public async Task DeleteAsyncTest()
    {
        var handlerMock = Substitute.For<MockHttpMessageHandler>();
        handlerMock.MockSend(
                Arg.Is<HttpRequestMessage>(r =>
                    r.RequestUri.AbsoluteUri == (API_REST_BASE_URI + ENDPOINT_REST_SECTIONS + "/7025") &&
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

        var actual = await client.Sections.DeleteAsync(7025);

        Assert.True(actual);
    }
}
