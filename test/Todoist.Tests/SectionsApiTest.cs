using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Todoist.Test;

public class SectionsApiTest
{
    [Fact]
    public async Task GetAllAsyncTest()
    {
        var handlerMock = new MockHttpMessageHandler
        {
            SendDelegate = (r, _) =>
            {
                Assert.Equal("https://api.todoist.com/rest/v2/sections?project_id=2203306141", r.RequestUri?.AbsoluteUri);
                Assert.Equal(HttpMethod.Get, r.Method);
                Assert.Equal("Bearer", r.Headers.Authorization?.Scheme);
                Assert.Equal("TestToken", r.Headers.Authorization?.Parameter);

                var response = new HttpResponseMessage(HttpStatusCode.OK);
                response.Content = new StringContent(
                    content: @"[
    {
        ""id"": ""7025"",
        ""project_id"": ""2203306141"",
        ""order"": 1,
        ""name"": ""Groceries""
    }
]",
                    encoding: Encoding.UTF8,
                    mediaType: "application/json");
                return Task.FromResult(response);
            }
        };
        var client = new TodoistClient("TestToken", handlerMock);

        var sections = await client.Sections.GetAllAsync(projectId: "2203306141");

        Assert.Single(sections);
        Assert.Equal("7025", sections[0].Id);
        Assert.Equal("2203306141", sections[0].ProjectId);
        Assert.Equal(1, sections[0].Order);
        Assert.Equal("Groceries", sections[0].Name);
    }

    [Fact]
    public async Task GetAsyncTest()
    {
        var handlerMock = new MockHttpMessageHandler
        {
            SendDelegate = (r, _) =>
            {
                Assert.Equal("https://api.todoist.com/rest/v2/sections/7025", r.RequestUri?.AbsoluteUri);
                Assert.Equal(HttpMethod.Get, r.Method);
                Assert.Equal("Bearer", r.Headers.Authorization?.Scheme);
                Assert.Equal("TestToken", r.Headers.Authorization?.Parameter);

                var response = new HttpResponseMessage(HttpStatusCode.OK);
                response.Content = new StringContent(
                    content: @"{
    ""id"": ""7025"",
    ""project_id"": ""2203306141"",
    ""order"": 1,
    ""name"": ""Groceries""
}",
                    encoding: Encoding.UTF8,
                    mediaType: "application/json");
                return Task.FromResult(response);
            }
        };
        var client = new TodoistClient("TestToken", handlerMock);

        var section = await client.Sections.GetAsync("7025");

        Assert.Equal("7025", section.Id);
        Assert.Equal("2203306141", section.ProjectId);
        Assert.Equal(1, section.Order);
        Assert.Equal("Groceries", section.Name);
    }

    [Fact]
    public async Task CreateAsyncTest()
    {
        var handlerMock = new MockHttpMessageHandler
        {
            SendDelegate = async (r, _) =>
            {
                Assert.Equal("https://api.todoist.com/rest/v2/sections", r.RequestUri?.AbsoluteUri);
                Assert.Equal(HttpMethod.Post, r.Method);
                Assert.Equal("Bearer", r.Headers.Authorization?.Scheme);
                Assert.Equal("TestToken", r.Headers.Authorization?.Parameter);
                var content = await r.Content!.ReadAsStringAsync();
                Assert.Contains("\"name\":\"Groceries\"", content);
                Assert.Contains("\"project_id\":\"2203306141\"", content);

                var response = new HttpResponseMessage(HttpStatusCode.OK);
                response.Content = new StringContent(
                    content: @"{
    ""id"": ""7025"",
    ""project_id"": ""2203306141"",
    ""order"": 1,
    ""name"": ""Groceries""
}",
                    encoding: Encoding.UTF8,
                    mediaType: "application/json");
                return response;
            }
        };
        var client = new TodoistClient("TestToken", handlerMock);

        var section = await client.Sections.CreateAsync(
            new Models.CreateSectionArgs(
                name: "Groceries",
                projectId: "2203306141"));

        Assert.Equal("7025", section.Id);
        Assert.Equal("2203306141", section.ProjectId);
        Assert.Equal(1, section.Order);
        Assert.Equal("Groceries", section.Name);
    }

    [Fact]
    public async Task UpdateAsyncTest()
    {
        var handlerMock = new MockHttpMessageHandler
        {
            SendDelegate = async (r, _) =>
            {
                Assert.Equal("https://api.todoist.com/rest/v2/sections/7025", r.RequestUri?.AbsoluteUri);
                Assert.Equal(HttpMethod.Post, r.Method);
                Assert.Equal("Bearer", r.Headers.Authorization?.Scheme);
                Assert.Equal("TestToken", r.Headers.Authorization?.Parameter);
                Assert.Contains("\"name\":\"Supermarket\"", await r.Content!.ReadAsStringAsync());

                var response = new HttpResponseMessage(HttpStatusCode.NoContent);
                response.Content = new StringContent(
                    content: @"{
    ""id"": ""7025"",
    ""project_id"": ""2203306141"",
    ""order"": 1,
    ""name"": ""Supermarket""
}",
                    encoding: Encoding.UTF8,
                    mediaType: "application/json");
                return response;
            }
        };
        var client = new TodoistClient("TestToken", handlerMock);

        var actual = await client.Sections.UpdateAsync(
            "7025",
            new Models.UpdateSectionArgs(
                name: "Supermarket"));

        Assert.Equal("7025", actual.Id);
        Assert.Equal("2203306141", actual.ProjectId);
        Assert.Equal("Supermarket", actual.Name);
        Assert.Equal(1, actual.Order);
    }

    [Fact]
    public async Task DeleteAsyncTest()
    {
        var handlerMock = new MockHttpMessageHandler
        {
            SendDelegate = (r, _) =>
            {
                Assert.Equal("https://api.todoist.com/rest/v2/sections/7025", r.RequestUri?.AbsoluteUri);
                Assert.Equal(HttpMethod.Delete, r.Method);
                Assert.Equal("Bearer", r.Headers.Authorization?.Scheme);
                Assert.Equal("TestToken", r.Headers.Authorization?.Parameter);

                var response = new HttpResponseMessage(HttpStatusCode.NoContent);
                return Task.FromResult(response);
            }
        };
        var client = new TodoistClient("TestToken", handlerMock);

        var actual = await client.Sections.DeleteAsync("7025");

        Assert.True(actual);
    }
}
