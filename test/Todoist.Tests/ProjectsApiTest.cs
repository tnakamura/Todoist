using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

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
                Assert.Equal("https://api.todoist.com/rest/v2/projects", r.RequestUri?.AbsoluteUri);
                Assert.Equal(r.Method, HttpMethod.Get);
                Assert.Equal("Bearer", r.Headers.Authorization?.Scheme);
                Assert.Equal("TestToken", r.Headers.Authorization?.Parameter);

                var response = new HttpResponseMessage(HttpStatusCode.OK);
                response.Content = new StringContent(
                    content: @"[
    {
        ""id"": ""220474322"",
        ""name"": ""Inbox"",
        ""comment_count"": 10,
        ""order"": 0,
        ""color"": ""grey"",
        ""is_shared"": false,
        ""is_favorite"": false,
        ""is_inbox_project"": true,
        ""is_team_inbox"": false,
        ""view_style"": ""list"",
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
        Assert.Equal("220474322", projects[0].Id);
        Assert.Equal("Inbox", projects[0].Name);
        Assert.Equal(10, projects[0].CommentCount);
        Assert.Equal(0, projects[0].Order);
        Assert.Equal("grey", projects[0].Color);
        Assert.False(projects[0].IsShared);
        Assert.False(projects[0].IsFavorite);
        Assert.True(projects[0].IsInboxProject);
        Assert.False(projects[0].IsTeamInbox);
        Assert.Equal("list", projects[0].ViewStyle);
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
                Assert.Equal("https://api.todoist.com/rest/v2/projects/2203306141", r.RequestUri?.AbsoluteUri);
                Assert.Equal(HttpMethod.Get, r.Method);
                Assert.Equal("Bearer", r.Headers.Authorization?.Scheme);
                Assert.Equal("TestToken", r.Headers.Authorization?.Parameter);

                var response = new HttpResponseMessage(HttpStatusCode.OK);
                response.Content = new StringContent(
                    content: @"{
    ""id"": ""2203306141"",
    ""name"": ""Shopping List"",
    ""comment_count"": 0,
    ""color"": ""charcoal"",
    ""is_shared"": false,
    ""order"": 1,
    ""is_favorite"": false,
    ""is_inbox_project"": false,
    ""is_team_inbox"": false,
    ""view_style"": ""list"",
    ""url"": ""https://todoist.com/showProject?id=2203306141"",
    ""parent_id"": null
}",
                    encoding: Encoding.UTF8,
                    mediaType: "application/json");
                return Task.FromResult(response);
            }
        };
        var client = new TodoistClient("TestToken", handlerMock);

        var project = await client.Projects.GetAsync("2203306141");

        Assert.Equal("2203306141", project.Id);
        Assert.Equal("Shopping List", project.Name);
        Assert.Equal(0, project.CommentCount);
        Assert.Equal(1, project.Order);
        Assert.Equal("charcoal", project.Color);
        Assert.False(project.IsShared);
        Assert.False(project.IsFavorite);
        Assert.False(project.IsInboxProject);
        Assert.False(project.IsTeamInbox);
        Assert.Equal("https://todoist.com/showProject?id=2203306141", project.Url);
        Assert.Equal("list", project.ViewStyle);
        Assert.Null(project.ParentId);
    }

    [Fact]
    public async Task DeleteAsyncTest()
    {
        var handlerMock = new MockHttpMessageHandler
        {
            SendDelegate = (r, _) =>
            {
                Assert.Equal("https://api.todoist.com/rest/v2/projects/2203306141", r.RequestUri?.AbsoluteUri);
                Assert.Equal(HttpMethod.Delete, r.Method);
                Assert.Equal("Bearer", r.Headers.Authorization?.Scheme);
                Assert.Equal("TestToken", r.Headers.Authorization?.Parameter);

                var response = new HttpResponseMessage(HttpStatusCode.NoContent);
                return Task.FromResult(response);
            }
        };
        var client = new TodoistClient("TestToken", handlerMock);

        var actual = await client.Projects.DeleteAsync("2203306141");

        Assert.True(actual);
    }

    [Fact]
    public async Task CreateAsyncTest()
    {
        var handlerMock = new MockHttpMessageHandler
        {
            SendDelegate = async (r, _) =>
            {
                Assert.Equal("https://api.todoist.com/rest/v2/projects", r.RequestUri?.AbsoluteUri);
                Assert.Equal(HttpMethod.Post, r.Method);
                Assert.Equal("Bearer", r.Headers.Authorization?.Scheme);
                Assert.Equal("TestToken", r.Headers.Authorization?.Parameter);
                Assert.Contains("\"name\":\"Shopping List\"", await r.Content!.ReadAsStringAsync());

                var response = new HttpResponseMessage(HttpStatusCode.OK);
                response.Content = new StringContent(
                    content: @"{
    ""id"": ""2203306141"",
    ""name"": ""Shopping List"",
    ""comment_count"": 0,
    ""color"": ""charcoal"",
    ""is_shared"": false,
    ""order"": 1,
    ""is_favorite"": true,
    ""is_inbox_project"": false,
    ""is_team_inbox"": false,
    ""view_style"": ""list"",
    ""url"": ""https://todoist.com/showProject?id=2203306141"",
    ""parent_id"": null
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

        Assert.Equal("2203306141", project.Id);
        Assert.Equal("Shopping List", project.Name);
        Assert.Equal(0, project.CommentCount);
        Assert.Equal(1, project.Order);
        Assert.Equal("charcoal", project.Color);
        Assert.False(project.IsShared);
        Assert.True(project.IsFavorite);
        Assert.False(project.IsInboxProject);
        Assert.False(project.IsTeamInbox);
        Assert.Equal("https://todoist.com/showProject?id=2203306141", project.Url);
        Assert.Equal("list", project.ViewStyle);
        Assert.Null(project.ParentId);
    }

    [Fact]
    public async Task UpdateAsyncTest()
    {
        var handlerMock = new MockHttpMessageHandler
        {
            SendDelegate = async (r, _) =>
            {
                Assert.Equal("https://api.todoist.com/rest/v2/projects/2203306141", r.RequestUri?.AbsoluteUri);
                Assert.Equal(HttpMethod.Post, r.Method);
                Assert.Equal("Bearer", r.Headers.Authorization?.Scheme);
                Assert.Equal("TestToken", r.Headers.Authorization?.Parameter);
                var content = await r.Content!.ReadAsStringAsync();
                Assert.Contains("\"name\":", content);
                Assert.Contains("\"Things To Buy\"", content);

                var response = new HttpResponseMessage(HttpStatusCode.OK);
                response.Content = new StringContent(
                    content: @"{
    ""id"": ""2203306141"",
    ""name"": ""Things to buy"",
    ""comment_count"": 0,
    ""color"": ""charcoal"",
    ""is_shared"": false,
    ""order"": 1,
    ""is_favorite"": false,
    ""is_inbox_project"": false,
    ""is_team_inbox"": false,
    ""view_style"": ""list"",
    ""url"": ""https://todoist.com/showProject?id=2203306141"",
    ""parent_id"": null
}",
                    encoding: Encoding.UTF8,
                    mediaType: "application/json");
                return response;
            }
        };
        var client = new TodoistClient("TestToken", handlerMock);

        var actual = await client.Projects.UpdateAsync(
            "2203306141",
            new Models.UpdateProjectArgs(
                name: "Things To Buy"));

        Assert.Equal("2203306141", actual.Id);
        Assert.Equal("Things to buy", actual.Name);
        Assert.Equal(0, actual.CommentCount);
        Assert.Equal(1, actual.Order);
        Assert.Equal("charcoal", actual.Color);
        Assert.False(actual.IsShared);
        Assert.False(actual.IsFavorite);
        Assert.False(actual.IsInboxProject);
        Assert.False(actual.IsTeamInbox);
        Assert.Equal("https://todoist.com/showProject?id=2203306141", actual.Url);
        Assert.Equal("list", actual.ViewStyle);
        Assert.Null(actual.ParentId);
    }

    [Fact]
    public async Task GetCollaboratorsAsyncTest()
    {
        var handlerMock = new MockHttpMessageHandler
        {
            SendDelegate = (r, _) =>
            {
                Assert.Equal("https://api.todoist.com/rest/v2/projects/2203306141/collaborators", r.RequestUri?.AbsoluteUri);
                Assert.Equal(HttpMethod.Get, r.Method);
                Assert.Equal("Bearer", r.Headers.Authorization?.Scheme);
                Assert.Equal("TestToken", r.Headers.Authorization?.Parameter);

                var response = new HttpResponseMessage(HttpStatusCode.OK);
                response.Content = new StringContent(
                    content: @"[
    {
        ""id"": ""2671362"",
        ""name"": ""Alice"",
        ""email"": ""alice@example.com""
    },
    {
        ""id"": ""2671366"",
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

        var users = await client.Projects.Collaborators.GetAllAsync("2203306141");

        Assert.Equal(2, users.Count);
        Assert.Equal("2671362", users[0].Id);
        Assert.Equal("Alice", users[0].Name);
        Assert.Equal("alice@example.com", users[0].Email);
        Assert.Equal("2671366", users[1].Id);
        Assert.Equal("Bob", users[1].Name);
        Assert.Equal("bob@example.com", users[1].Email);
    }
}
