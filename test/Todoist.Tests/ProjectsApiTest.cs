using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NSubstitute;
using Xunit;
using static Todoist.Constants.Endpoints;

namespace Todoist.Test;

public class ProjectsApiTest
{
    [Fact]
    public async Task GetAllAsyncTest()
    {
        var handlerMock = new MockHttpMessageHandler
        {
            SendDelegate = (r, _) =>
            {
                Assert.Equal((API_REST_BASE_URI + ENDPOINT_REST_PROJECTS), r.RequestUri?.AbsoluteUri);
                Assert.Equal(r.Method, HttpMethod.Get);
                Assert.Equal("Bearer", r.Headers.Authorization?.Scheme);
                Assert.Equal("TestToken", r.Headers.Authorization?.Parameter);

                var response = new HttpResponseMessage(HttpStatusCode.OK);
                response.Content = new StringContent(
                    content: @"[
    {
        ""id"": 220474322,
        ""name"": ""Inbox"",
        ""comment_count"": 10,
        ""order"": 1,
        ""color"": 47,
        ""shared"": false,
        ""favorite"": false,
        ""inbox_project"": true,
        ""team_inbox"": false,
        ""url"": ""https://todoist.com/showProject?id=220474322"",
        ""parent_id"": null
    }
]",
                    encoding: Encoding.UTF8,
                    mediaType: "application/json");
                return Task.FromResult(response);
            }
        };
        var client = new TodoistClient("TestToken", handlerMock);

        var projects = await client.Projects.GetAllAsync();

        Assert.Single(projects);
        Assert.Equal(220474322, projects[0].Id);
        Assert.Equal("Inbox", projects[0].Name);
        Assert.Equal(10, projects[0].CommentCount);
        Assert.Equal(1, projects[0].Order);
        Assert.Equal(47, projects[0].Color);
        Assert.False(projects[0].Shared);
        Assert.False(projects[0].Favorite);
        Assert.True(projects[0].InboxProject);
        Assert.False(projects[0].TeamInbox);
        Assert.Equal("https://todoist.com/showProject?id=220474322", projects[0].Url);
        Assert.Null(projects[0].ParentId);
    }

    [Fact]
    public async Task GetAsyncTest()
    {
        var handlerMock = new MockHttpMessageHandler
        {
            SendDelegate = (r, _) =>
            {
                Assert.Equal((API_REST_BASE_URI + ENDPOINT_REST_PROJECTS + "/2203306141"), r.RequestUri?.AbsoluteUri);
                Assert.Equal(HttpMethod.Get,r.Method );
                Assert.Equal("Bearer", r.Headers.Authorization?.Scheme);
                Assert.Equal("TestToken", r.Headers.Authorization?.Parameter);

                var response = new HttpResponseMessage(HttpStatusCode.OK);
                response.Content = new StringContent(
                    content: @"{
    ""id"": 2203306141,
    ""name"": ""Shopping List"",
    ""comment_count"": 0,
    ""color"": 47,
    ""shared"": false,
    ""order"": 1,
    ""favorite"": false,
    ""url"": ""https://todoist.com/showProject?id=2203306141""
}",
                    encoding: Encoding.UTF8,
                    mediaType: "application/json");
                return Task.FromResult(response);
            }
        };
        var client = new TodoistClient("TestToken", handlerMock);

        var project = await client.Projects.GetAsync(2203306141);

        Assert.Equal(2203306141, project.Id);
        Assert.Equal("Shopping List", project.Name);
        Assert.Equal(0, project.CommentCount);
        Assert.Equal(1, project.Order);
        Assert.Equal(47, project.Color);
        Assert.False(project.Shared);
        Assert.False(project.Favorite);
        Assert.False(project.InboxProject);
        Assert.False(project.TeamInbox);
        Assert.Equal("https://todoist.com/showProject?id=2203306141", project.Url);
        Assert.Null(project.ParentId);
    }

    [Fact]
    public async Task DeleteAsyncTest()
    {
        var handlerMock = new MockHttpMessageHandler
        {
            SendDelegate = (r, _) =>
            {
                Assert.Equal((API_REST_BASE_URI + ENDPOINT_REST_PROJECTS + "/2203306141"), r.RequestUri?.AbsoluteUri);
                Assert.Equal(HttpMethod.Delete, r.Method);
                Assert.Equal("Bearer", r.Headers.Authorization?.Scheme);
                Assert.Equal("TestToken", r.Headers.Authorization?.Parameter);

                var response = new HttpResponseMessage(HttpStatusCode.NoContent);
                return Task.FromResult(response);
            }
        };
        var client = new TodoistClient("TestToken", handlerMock);

        var actual = await client.Projects.DeleteAsync(2203306141);

        Assert.True(actual);
    }

    [Fact]
    public async Task CreateAsyncTest()
    {
        var handlerMock = new MockHttpMessageHandler
        {
            SendDelegate = async (r, _) =>
            {
                Assert.Equal((API_REST_BASE_URI + ENDPOINT_REST_PROJECTS), r.RequestUri?.AbsoluteUri);
                Assert.Equal(HttpMethod.Post, r.Method);
                Assert.Equal("Bearer", r.Headers.Authorization?.Scheme);
                Assert.Equal("TestToken", r.Headers.Authorization?.Parameter);
                Assert.Contains("\"name\":\"Shopping List\"", await r.Content!.ReadAsStringAsync());

                var response = new HttpResponseMessage(HttpStatusCode.OK);
                response.Content = new StringContent(
                    content: @"{
    ""id"": 2203306141,
    ""name"": ""Shopping List"",
    ""comment_count"": 0,
    ""color"": 47,
    ""shared"": false,
    ""sync_id"": 0,
    ""order"": 1,
    ""favorite"": true,
    ""url"": ""https://todoist.com/showProject?id=2203306141""
}",
                    encoding: Encoding.UTF8,
                    mediaType: "application/json");
                return response;
            }
        };
        var client = new TodoistClient("TestToken", handlerMock);

        var project = await client.Projects.CreateAsync(
            new Models.CreateProjectArgs(
                name: "Shopping List"));

        Assert.Equal(2203306141, project.Id);
        Assert.Equal("Shopping List", project.Name);
        Assert.Equal(0, project.CommentCount);
        Assert.Equal(1, project.Order);
        Assert.Equal(47, project.Color);
        Assert.False(project.Shared);
        Assert.True(project.Favorite);
        Assert.False(project.InboxProject);
        Assert.False(project.TeamInbox);
        Assert.Equal("https://todoist.com/showProject?id=2203306141", project.Url);
        Assert.Null(project.ParentId);
    }

    [Fact]
    public async Task UpdateAsyncTest()
    {
        var handlerMock = new MockHttpMessageHandler
        {
            SendDelegate = async (r, _) =>
            {
                Assert.Equal((API_REST_BASE_URI + ENDPOINT_REST_PROJECTS + "/2203306141"), r.RequestUri?.AbsoluteUri);
                Assert.Equal(HttpMethod.Post, r.Method);
                Assert.Equal("Bearer", r.Headers.Authorization?.Scheme);
                Assert.Equal("TestToken", r.Headers.Authorization?.Parameter);
                var content = await r.Content!.ReadAsStringAsync();
                Assert.Contains("\"name\":", content);
                Assert.Contains("\"Things To Buy\"", content);

                var response = new HttpResponseMessage(HttpStatusCode.NoContent);
                return response;
            }
        };
        var client = new TodoistClient("TestToken", handlerMock);

        var actual = await client.Projects.UpdateAsync(
            2203306141,
            new Models.UpdateProjectArgs(
                name: "Things To Buy"));

        Assert.True(actual);
    }

    [Fact]
    public async Task GetCollaboratorsAsyncTest()
    {
        var handlerMock = new MockHttpMessageHandler
        {
            SendDelegate = (r, _) =>
            {
                Assert.Equal((API_REST_BASE_URI + ENDPOINT_REST_PROJECTS + "/2203306141/" + ENDPOINT_REST_PROJECT_COLLABORATORS), r.RequestUri?.AbsoluteUri);
                Assert.Equal(HttpMethod.Get, r.Method);
                Assert.Equal("Bearer", r.Headers.Authorization?.Scheme);
                Assert.Equal("TestToken", r.Headers.Authorization?.Parameter);

                var response = new HttpResponseMessage(HttpStatusCode.OK);
                response.Content = new StringContent(
                    content: @"[
    {
        ""id"": 2671362,
        ""name"": ""Alice"",
        ""email"": ""alice@example.com""
    },
    {
        ""id"": 2671366,
        ""name"": ""Bob"",
        ""email"": ""bob@example.com""
    }
]",
                    encoding: Encoding.UTF8,
                    mediaType: "application/json");
                return Task.FromResult(response);
            },
        };
        var client = new TodoistClient("TestToken", handlerMock);

        var users = await client.Projects.Collaborators.GetAllAsync(2203306141);

        Assert.Equal(2, users.Count);
        Assert.Equal(2671362, users[0].Id);
        Assert.Equal("Alice", users[0].Name);
        Assert.Equal("alice@example.com", users[0].Email);
        Assert.Equal(2671366, users[1].Id);
        Assert.Equal("Bob", users[1].Name);
        Assert.Equal("bob@example.com", users[1].Email);
    }
}
