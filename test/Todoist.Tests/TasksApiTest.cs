using System;
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
    public class TasksApiTest
    {
        [Fact]
        public async Task GetAllAsyncTest()
        {
            var handlerMock = new Mock<HttpMessageHandler>();
            handlerMock.Protected()
                .As<IHttpMessageHandler>()
                .Setup(m => m.SendAsync(
                    It.Is<HttpRequestMessage>(r =>
                        r.RequestUri.AbsoluteUri == (API_REST_BASE_URI + ENDPOINT_REST_TASKS) &&
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
        ""id"": 2995104339,
        ""project_id"": 2203306141,
        ""section_id"": 7025,
        ""parent_id"": 2995104589,
        ""content"": ""Buy Milk"",
        ""description"": """",
        ""comment_count"": 10,
        ""assignee"": 2671142,
        ""assigner"": 2671362,
        ""order"": 1,
        ""priority"": 1,
        ""url"": ""https://todoist.com/showTask?id=2995104339""
    }
]",
                        encoding: Encoding.UTF8,
                        mediaType: "application/json");
                    return Task.FromResult(response);
                });
            var client = new TodoistClient("TestToken",handlerMock.Object);

            var tasks = await client.Tasks.GetAllAsync();

            Assert.Single(tasks);
            Assert.Equal(2995104339, tasks[0].Id);
            Assert.Equal(2203306141, tasks[0].ProjectId);
            Assert.Equal(7025, tasks[0].SectionId);
            Assert.Equal(2995104589, tasks[0].ParentId);
            Assert.Equal("Buy Milk", tasks[0].Content);
            Assert.Equal("", tasks[0].Description);
            Assert.Equal(10, tasks[0].CommentCount);
            Assert.Equal(2671142, tasks[0].Assignee);
            Assert.Equal(2671362, tasks[0].Assigner);
            Assert.Equal(1, tasks[0].Order);
            Assert.Equal(1, tasks[0].Priority);
            Assert.Equal("https://todoist.com/showTask?id=2995104339", tasks[0].Url);
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
                        r.RequestUri.AbsoluteUri == (API_REST_BASE_URI + ENDPOINT_REST_TASKS + "/2995104339") &&
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
    ""assignee"": 2671142,
    ""assigner"": 2671362,
    ""comment_count"": 0,
    ""completed"": false,
    ""content"": ""Buy Milk"",
    ""description"": """",
    ""due"": {
        ""date"": ""2016-09-01"",
        ""datetime"": ""2016-09-01T11:00:00Z"",
        ""recurring"": false,
        ""string"": ""2017-07-01 12:00"",
        ""timezone"": ""Europe/Lisbon""
    },
    ""id"": 2995104339,
    ""order"": 1,
    ""priority"": 1,
    ""project_id"": 2203306141,
    ""section_id"": 7025,
    ""parent_id"": 2995104589,
    ""url"": ""https://todoist.com/showTask?id=2995104339""
}",
                        encoding: Encoding.UTF8,
                        mediaType: "application/json");
                    return Task.FromResult(response);
                });
            var client = new TodoistClient("TestToken",handlerMock.Object);

            var task = await client.Tasks.GetAsync(2995104339);

            Assert.Equal(2995104339, task.Id);
            Assert.Equal(2203306141, task.ProjectId);
            Assert.Equal(7025, task.SectionId);
            Assert.Equal(2995104589, task.ParentId);
            Assert.Equal("Buy Milk", task.Content);
            Assert.Equal("", task.Description);
            Assert.Equal(0, task.CommentCount);
            Assert.Equal(2671142, task.Assignee);
            Assert.Equal(2671362, task.Assigner);
            Assert.Equal(1, task.Order);
            Assert.Equal(1, task.Priority);
            Assert.Equal("https://todoist.com/showTask?id=2995104339", task.Url);
            Assert.NotNull(task.Due);
            Assert.Equal(new DateTimeOffset(2016, 9, 1, 0, 0, 0, DateTimeOffset.Now.Offset), task.Due.Date);
            Assert.Equal(new DateTimeOffset(2016, 9, 1, 11, 0, 0, TimeSpan.Zero), task.Due.Datetime);
            Assert.False(task.Due.Recurring);
            Assert.Equal("2017-07-01 12:00", task.Due.String);
            Assert.Equal("Europe/Lisbon", task.Due.Timezone);
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
                        r.RequestUri.AbsoluteUri == (API_REST_BASE_URI + ENDPOINT_REST_TASKS) &&
                        r.Method == HttpMethod.Post &&
                        r.Headers.Authorization.Scheme == "Bearer" &&
                        r.Headers.Authorization.Parameter == "TestToken" &&
                        r.Content.ReadAsStringAsync().GetAwaiter().GetResult().Contains("\"content\":\"Buy Milk\"") &&
                        r.Content.ReadAsStringAsync().GetAwaiter().GetResult().Contains("\"due_string\":\"tomorrow at 12:00\"") &&
                        r.Content.ReadAsStringAsync().GetAwaiter().GetResult().Contains("\"due_lang\":\"en\"") &&
                        r.Content.ReadAsStringAsync().GetAwaiter().GetResult().Contains("\"priority\":4")
                    ),
                    It.IsAny<CancellationToken>()))
                .Returns(() =>
                {
                    var response = new HttpResponseMessage(HttpStatusCode.OK);
                    response.Content = new StringContent(
                        content: @"{
    ""comment_count"": 0,
    ""completed"": false,
    ""content"": ""Buy Milk"",
    ""description"": """",
    ""due"": {
        ""date"": ""2016-09-01"",
        ""datetime"": ""2016-09-01T11:00:00Z"",
        ""recurring"": false,
        ""string"": ""2017-07-01 12:00"",
        ""timezone"": ""Europe/Lisbon""
    },
    ""id"": 2995104339,
    ""order"": 1,
    ""priority"": 4,
    ""project_id"": 2203306141,
    ""section_id"": 7025,
    ""parent_id"": 2995104589,
    ""url"": ""https://todoist.com/showTask?id=2995104339""
}",
                        encoding: Encoding.UTF8,
                        mediaType: "application/json");
                    return Task.FromResult(response);
                });
            var client = new TodoistClient("TestToken",handlerMock.Object);

            var task = await client.Tasks.CreateAsync(
                new Models.CreateTaskArgs(
                    content: "Buy Milk",
                    dueString: "tomorrow at 12:00",
                    dueLang: "en",
                    priority: 4));

            Assert.Equal(2995104339, task.Id);
            Assert.Equal(2203306141, task.ProjectId);
            Assert.Equal(7025, task.SectionId);
            Assert.Equal(2995104589, task.ParentId);
            Assert.Equal("Buy Milk", task.Content);
            Assert.Equal("", task.Description);
            Assert.Equal(0, task.CommentCount);
            Assert.Null(task.Assignee);
            Assert.Null(task.Assigner);
            Assert.Equal(1, task.Order);
            Assert.Equal(4, task.Priority);
            Assert.Equal("https://todoist.com/showTask?id=2995104339", task.Url);
            Assert.NotNull(task.Due);
            Assert.Equal(new DateTimeOffset(2016, 9, 1, 0, 0, 0, DateTimeOffset.Now.Offset), task.Due.Date);
            Assert.Equal(new DateTimeOffset(2016, 9, 1, 11, 0, 0, TimeSpan.Zero), task.Due.Datetime);
            Assert.False(task.Due.Recurring);
            Assert.Equal("2017-07-01 12:00", task.Due.String);
            Assert.Equal("Europe/Lisbon", task.Due.Timezone);
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
                        r.RequestUri.AbsoluteUri == (API_REST_BASE_URI + ENDPOINT_REST_TASKS + "/2995104339") &&
                        r.Method == HttpMethod.Post &&
                        r.Headers.Authorization.Scheme == "Bearer" &&
                        r.Headers.Authorization.Parameter == "TestToken" &&
                        r.Content.ReadAsStringAsync().GetAwaiter().GetResult().Contains("\"content\":\"Buy Coffee\"")
                    ),
                    It.IsAny<CancellationToken>()))
                .Returns(() =>
                {
                    var response = new HttpResponseMessage(HttpStatusCode.NoContent);
                    return Task.FromResult(response);
                });
            var client = new TodoistClient("TestToken",handlerMock.Object);

            var actual = await client.Tasks.UpdateAsync(
                2995104339,
                new Models.UpdateTaskArgs(
                    content: "Buy Coffee"));

            Assert.True(actual);
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
                        r.RequestUri.AbsoluteUri == (API_REST_BASE_URI + ENDPOINT_REST_TASKS + "/2995104339") &&
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

            var actual = await client.Tasks.DeleteAsync(2995104339);

            Assert.True(actual);
            handlerMock.VerifyAll();
        }

        [Fact]
        public async Task CloseAsyncTest()
        {
            var handlerMock = new Mock<HttpMessageHandler>();
            handlerMock.Protected()
                .As<IHttpMessageHandler>()
                .Setup(m => m.SendAsync(
                    It.Is<HttpRequestMessage>(r =>
                        r.RequestUri.AbsoluteUri == (API_REST_BASE_URI + ENDPOINT_REST_TASKS + "/2995104339/" + ENDPOINT_REST_TASK_CLOSE) &&
                        r.Method == HttpMethod.Post &&
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

            var actual = await client.Tasks.CloseAsync(2995104339);

            Assert.True(actual);
            handlerMock.VerifyAll();
        }

        [Fact]
        public async Task ReopenAsyncTest()
        {
            var handlerMock = new Mock<HttpMessageHandler>();
            handlerMock.Protected()
                .As<IHttpMessageHandler>()
                .Setup(m => m.SendAsync(
                    It.Is<HttpRequestMessage>(r =>
                        r.RequestUri.AbsoluteUri == (API_REST_BASE_URI + ENDPOINT_REST_TASKS + "/2995104339/" + ENDPOINT_REST_TASK_REOPEN) &&
                        r.Method == HttpMethod.Post &&
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

            var actual = await client.Tasks.ReopenAsync(2995104339);

            Assert.True(actual);
            handlerMock.VerifyAll();
        }
    }
}
