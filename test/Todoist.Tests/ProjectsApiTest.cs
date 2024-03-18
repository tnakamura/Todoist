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
    public class ProjectsApiTest
    {
        [Fact]
        public async Task GetAllAsyncTest()
        {
            var handlerMock = new Mock<HttpMessageHandler>();
            handlerMock.Protected()
                .As<IHttpMessageHandler>()
                .Setup(m => m.SendAsync(
                    It.Is<HttpRequestMessage>(r =>
                        r.RequestUri.AbsoluteUri == (API_REST_BASE_URI + ENDPOINT_REST_PROJECTS) &&
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
                });
            var client = new TodoistClient("TestToken",handlerMock.Object);

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
            handlerMock.VerifyAll();
        }

        [Fact]
        public async Task GetAsyncTest()
        {
            var handlerMock = new Mock<HttpMessageHandler>();
            handlerMock.Protected()
                .As<IHttpMessageHandler>()
                .Setup(m => m.SendAsync(
                    It.Is<HttpRequestMessage>(r =>
                        r.RequestUri.AbsoluteUri == (API_REST_BASE_URI + ENDPOINT_REST_PROJECTS + "/2203306141") &&
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
                });
            var client = new TodoistClient("TestToken",handlerMock.Object);

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
            handlerMock.VerifyAll();
        }

        [Fact]
        public async Task DeleteAsyncTest()
        {
            var handlerMock = new Mock<HttpMessageHandler>();
            handlerMock.Protected()
                .As<IHttpMessageHandler>()
                .Setup(m => m.SendAsync(
                    It.Is<HttpRequestMessage>(r =>
                        r.RequestUri.AbsoluteUri == (API_REST_BASE_URI + ENDPOINT_REST_PROJECTS + "/2203306141") &&
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
            var client = new TodoistClient("TestToken",handlerMock.Object);

            var actual = await client.Projects.DeleteAsync(2203306141);

            Assert.True(actual);
            handlerMock.VerifyAll();
        }

        [Fact]
        public async Task CreateAsyncTest()
        {
            var handlerMock = new Mock<HttpMessageHandler>();
            handlerMock.Protected()
                .As<IHttpMessageHandler>()
                .Setup(m => m.SendAsync(
                    It.Is<HttpRequestMessage>(r =>
                        r.RequestUri.AbsoluteUri == (API_REST_BASE_URI + ENDPOINT_REST_PROJECTS) &&
                        r.Method == HttpMethod.Post &&
                        r.Headers.Authorization.Scheme == "Bearer" &&
                        r.Headers.Authorization.Parameter == "TestToken" &&
                        r.Content.ReadAsStringAsync().GetAwaiter().GetResult().Contains("\"name\":\"Shopping List\"")
                    ),
                    It.IsAny<CancellationToken>()))
                .Returns(() =>
                {
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
                    return Task.FromResult(response);
                });
            var client = new TodoistClient("TestToken",handlerMock.Object);

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
            handlerMock.VerifyAll();
        }

        [Fact]
        public async Task UpdateAsyncTest()
        {
            var handlerMock = new Mock<HttpMessageHandler>();
            handlerMock.Protected()
                .As<IHttpMessageHandler>()
                .Setup(m => m.SendAsync(
                    It.Is<HttpRequestMessage>(r =>
                        r.RequestUri.AbsoluteUri == (API_REST_BASE_URI + ENDPOINT_REST_PROJECTS + "/2203306141") &&
                        r.Method == HttpMethod.Post &&
                        r.Headers.Authorization.Scheme == "Bearer" &&
                        r.Headers.Authorization.Parameter == "TestToken" &&
                        r.Content.ReadAsStringAsync().GetAwaiter().GetResult().Contains("\"name\":") &&
                        r.Content.ReadAsStringAsync().GetAwaiter().GetResult().Contains("\"Things To Buy\"")
                    ),
                    It.IsAny<CancellationToken>()))
                .Returns(() =>
                {
                    var response = new HttpResponseMessage(HttpStatusCode.NoContent);
                    return Task.FromResult(response);
                });
            var client = new TodoistClient("TestToken",handlerMock.Object);

            var actual = await client.Projects.UpdateAsync(
                2203306141,
                new Models.UpdateProjectArgs(
                    name: "Things To Buy"));

            Assert.True(actual);
            handlerMock.VerifyAll();
        }

        [Fact]
        public async Task GetCollaboratorsAsyncTest()
        {
            var handlerMock = new Mock<HttpMessageHandler>();
            handlerMock.Protected()
                .As<IHttpMessageHandler>()
                .Setup(m => m.SendAsync(
                    It.Is<HttpRequestMessage>(r =>
                        r.RequestUri.AbsoluteUri == (API_REST_BASE_URI + ENDPOINT_REST_PROJECTS + "/2203306141/" + ENDPOINT_REST_PROJECT_COLLABORATORS) &&
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
                });
            var client = new TodoistClient("TestToken",handlerMock.Object);

            var users = await client.Projects.GetCollaboratorsAsync(2203306141);

            Assert.Equal(2, users.Count);
            Assert.Equal(2671362, users[0].Id);
            Assert.Equal("Alice", users[0].Name);
            Assert.Equal("alice@example.com", users[0].Email);
            Assert.Equal(2671366, users[1].Id);
            Assert.Equal("Bob", users[1].Name);
            Assert.Equal("bob@example.com", users[1].Email);
            handlerMock.VerifyAll();
        }
    }
}
