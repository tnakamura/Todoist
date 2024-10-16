using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Todoist.Test;

public class TasksApiTest
{
    [Fact]
    public async Task GetAllAsyncTest()
    {
        var handlerMock = new MockHttpMessageHandler
        {
            SendDelegate = (r, _) =>
            {
                Assert.Equal(
                    "https://api.todoist.com/rest/v2/tasks",
                    r.RequestUri?.AbsoluteUri);
                Assert.Equal(HttpMethod.Get, r.Method);
                Assert.Equal("Bearer", r.Headers.Authorization?.Scheme);
                Assert.Equal("TestToken", r.Headers.Authorization?.Parameter);

                var response = new HttpResponseMessage(HttpStatusCode.OK);
                response.Content = new StringContent(
                    content: @"[
    {
        ""creator_id"": ""2671355"",
        ""created_at"": ""2019-12-11T22:36:50.000000Z"",
        ""assignee_id"": ""2671362"",
        ""assigner_id"": ""2671355"",
        ""comment_count"": 10,
        ""is_completed"": false,
        ""content"": ""Buy Milk"",
        ""description"": """",
        ""due"": {
            ""date"": ""2016-09-01"",
            ""is_recurring"": false,
            ""datetime"": ""2016-09-01T12:00:00.000000Z"",
            ""string"": ""tomorrow at 12"",
            ""timezone"": ""Europe/Moscow""
        },
        ""duration"": null,
        ""id"": ""2995104339"",
        ""labels"": [""Food"", ""Shopping""],
        ""order"": 1,
        ""priority"": 1,
        ""project_id"": ""2203306141"",
        ""section_id"": ""7025"",
        ""parent_id"": ""2995104589"",
        ""url"": ""https://todoist.com/showTask?id=2995104339""
    }
]",
                    encoding: Encoding.UTF8,
                    mediaType: "application/json");
                return Task.FromResult(response);
            }
        };
        var client = new TodoistClient("TestToken", handlerMock);

        var tasks = await client.Tasks.GetAllAsync();

        Assert.Single(tasks);
        Assert.Equal("2671355", tasks[0].CreatorId);
        Assert.Equal(DateTimeOffset.Parse("2019-12-11T22:36:50.000000Z"), tasks[0].CreatedAt);
        Assert.Equal("2671362", tasks[0].AssigneeId);
        Assert.Equal("2671355", tasks[0].AssignerId);
        Assert.Equal(10, tasks[0].CommentCount);
        Assert.False(tasks[0].IsCompleted);
        Assert.Equal("Buy Milk", tasks[0].Content);
        Assert.Equal("", tasks[0].Description);
        Assert.NotNull(tasks[0].Due);
        Assert.Equal(DateTimeOffset.Parse("2016-09-01"), tasks[0].Due?.Date);
        Assert.False(tasks[0].Due?.IsRecurring);
        Assert.Equal(DateTimeOffset.Parse("2016-09-01T12:00:00.000000Z"), tasks[0].Due?.DateTime);
        Assert.Equal("tomorrow at 12", tasks[0].Due?.String);
        Assert.Equal("Europe/Moscow", tasks[0].Due?.TimeZone);
        Assert.Null(tasks[0].Duration);
        Assert.Equal("2995104339", tasks[0].Id);
        Assert.Equal(2, tasks[0].Labels.Count);
        Assert.Equal("Food", tasks[0].Labels[0]);
        Assert.Equal("Shopping", tasks[0].Labels[1]);
        Assert.Equal(1, tasks[0].Order);
        Assert.Equal(1, tasks[0].Priority);
        Assert.Equal("2203306141", tasks[0].ProjectId);
        Assert.Equal("7025", tasks[0].SectionId);
        Assert.Equal("2995104589", tasks[0].ParentId);
        Assert.Equal("https://todoist.com/showTask?id=2995104339", tasks[0].Url);
    }

    [Fact]
    public async Task GetAsyncTest()
    {
        var handlerMock = new MockHttpMessageHandler
        {
            SendDelegate = (r, _) =>
            {
                Assert.Equal(
                    "https://api.todoist.com/rest/v2/tasks/2995104339",
                    r.RequestUri?.AbsoluteUri);
                Assert.Equal(r.Method, HttpMethod.Get);
                Assert.Equal("Bearer", r.Headers.Authorization?.Scheme);
                Assert.Equal("TestToken", r.Headers.Authorization?.Parameter);

                var response = new HttpResponseMessage(HttpStatusCode.OK);
                response.Content = new StringContent(
                    content: @"{
    ""creator_id"": ""2671355"",
    ""created_at"": ""2019-12-11T22:36:50.000000Z"",
    ""assignee_id"": ""2671362"",
    ""assigner_id"": ""2671355"",
    ""comment_count"": 10,
    ""is_completed"": false,
    ""content"": ""Buy Milk"",
    ""description"": """",
    ""due"": {
        ""date"": ""2016-09-01"",
        ""is_recurring"": false,
        ""datetime"": ""2016-09-01T12:00:00.000000Z"",
        ""string"": ""tomorrow at 12"",
        ""timezone"": ""Europe/Moscow""
    },
    ""duration"": null,
    ""id"": ""2995104339"",
    ""labels"": [""Food"", ""Shopping""],
    ""order"": 1,
    ""priority"": 1,
    ""project_id"": ""2203306141"",
    ""section_id"": ""7025"",
    ""parent_id"": ""2995104589"",
    ""url"": ""https://todoist.com/showTask?id=2995104339""
}",
                    encoding: Encoding.UTF8,
                    mediaType: "application/json");
                return Task.FromResult(response);
            }
        };
        var client = new TodoistClient("TestToken", handlerMock);

        var task = await client.Tasks.GetAsync("2995104339");

        Assert.Equal("2671355", task.CreatorId);
        Assert.Equal(DateTimeOffset.Parse("2019-12-11T22:36:50.000000Z"), task.CreatedAt);
        Assert.Equal("2671362", task.AssigneeId);
        Assert.Equal("2671355", task.AssignerId);
        Assert.Equal(10, task.CommentCount);
        Assert.False(task.IsCompleted);
        Assert.Equal("Buy Milk", task.Content);
        Assert.Equal("", task.Description);
        Assert.NotNull(task.Due);
        Assert.Equal(DateTimeOffset.Parse("2016-09-01"), task.Due.Date);
        Assert.False(task.Due.IsRecurring);
        Assert.Equal(DateTimeOffset.Parse("2016-09-01T12:00:00.000000Z"), task.Due.DateTime);
        Assert.Equal("tomorrow at 12", task.Due.String);
        Assert.Equal("Europe/Moscow", task.Due.TimeZone);
        Assert.Null(task.Duration);
        Assert.Equal("2995104339", task.Id);
        Assert.Equal(2, task.Labels.Count);
        Assert.Equal("Food", task.Labels[0]);
        Assert.Equal("Shopping", task.Labels[1]);
        Assert.Equal(1, task.Order);
        Assert.Equal(1, task.Priority);
        Assert.Equal("2203306141", task.ProjectId);
        Assert.Equal("7025", task.SectionId);
        Assert.Equal("2995104589", task.ParentId);
        Assert.Equal("https://todoist.com/showTask?id=2995104339", task.Url);
    }

    [Fact]
    public async Task CreateAsyncTest()
    {
        var handlerMock = new MockHttpMessageHandler
        {
            SendDelegate = async (r, _) =>
            {
                Assert.Equal(
                    "https://api.todoist.com/rest/v2/tasks",
                    r.RequestUri?.AbsoluteUri);
                Assert.Equal(HttpMethod.Post, r.Method);
                Assert.Equal("Bearer", r.Headers.Authorization?.Scheme);
                Assert.Equal("TestToken", r.Headers.Authorization?.Parameter);
                Assert.Contains("\"content\":\"Buy Milk\"", await r.Content!.ReadAsStringAsync());
                Assert.Contains("\"due_string\":\"tomorrow at 12:00\"", await r.Content.ReadAsStringAsync());
                Assert.Contains("\"due_lang\":\"en\"", await r.Content.ReadAsStringAsync());
                Assert.Contains("\"priority\":4", await r.Content.ReadAsStringAsync());

                var response = new HttpResponseMessage(HttpStatusCode.OK);
                response.Content = new StringContent(
                    content: @"{
    ""creator_id"": ""2671355"",
    ""created_at"": ""2019-12-11T22:36:50.000000Z"",
    ""assignee_id"": null,
    ""assigner_id"": null,
    ""comment_count"": 0,
    ""is_completed"": false,
    ""content"": ""Buy Milk"",
    ""description"": """",
    ""due"": {
        ""date"": ""2016-09-01"",
        ""is_recurring"": false,
        ""datetime"": ""2016-09-01T12:00:00.000000Z"",
        ""string"": ""tomorrow at 12"",
        ""timezone"": ""Europe/Moscow""
    },
    ""duration"": null,
    ""id"": ""2995104339"",
    ""labels"": [],
    ""order"": 1,
    ""priority"": 4,
    ""project_id"": ""2203306141"",
    ""section_id"": null,
    ""parent_id"": null,
    ""url"": ""https://todoist.com/showTask?id=2995104339""
}",
                    encoding: Encoding.UTF8,
                    mediaType: "application/json");
                return response;
            }
        };
        var client = new TodoistClient("TestToken", handlerMock);

        var task = await client.Tasks.CreateAsync(
            new Models.CreateTaskArgs(
                content: "Buy Milk",
                dueString: "tomorrow at 12:00",
                dueLang: "en",
                priority: 4));

        Assert.Equal("2671355", task.CreatorId);
        Assert.Equal(DateTimeOffset.Parse("2019-12-11T22:36:50.000000Z"), task.CreatedAt);
        Assert.Null(task.AssigneeId);
        Assert.Null(task.AssignerId);
        Assert.Equal(0, task.CommentCount);
        Assert.False(task.IsCompleted);
        Assert.Equal("Buy Milk", task.Content);
        Assert.Equal("", task.Description);
        Assert.NotNull(task.Due);
        Assert.Equal(DateTimeOffset.Parse("2016-09-01"), task.Due.Date);
        Assert.False(task.Due.IsRecurring);
        Assert.Equal(DateTimeOffset.Parse("2016-09-01T12:00:00.000000Z"), task.Due.DateTime);
        Assert.Equal("tomorrow at 12", task.Due.String);
        Assert.Equal("Europe/Moscow", task.Due.TimeZone);
        Assert.Null(task.Duration);
        Assert.Equal("2995104339", task.Id);
        Assert.Empty(task.Labels);
        Assert.Equal(1, task.Order);
        Assert.Equal(4, task.Priority);
        Assert.Equal("2203306141", task.ProjectId);
        Assert.Null(task.SectionId);
        Assert.Null(task.ParentId);
        Assert.Equal("https://todoist.com/showTask?id=2995104339", task.Url);
    }

    [Fact]
    public async Task UpdateAsyncTest()
    {
        var handlerMock = new MockHttpMessageHandler
        {
            SendDelegate = async (r, _) =>
            {
                Assert.Equal(
                    "https://api.todoist.com/rest/v2/tasks/2995104339",
                    r.RequestUri?.AbsoluteUri);
                Assert.Equal(HttpMethod.Post, r.Method);
                Assert.Equal("Bearer", r.Headers.Authorization?.Scheme);
                Assert.Equal("TestToken", r.Headers.Authorization?.Parameter);
                Assert.Contains("\"content\":\"Buy Coffee\"", await r.Content!.ReadAsStringAsync());

                var response = new HttpResponseMessage(HttpStatusCode.NoContent);
                response.Content = new StringContent(
                    content: @"{
    ""creator_id"": ""2671355"",
    ""created_at"": ""2019-12-11T22:36:50.000000Z"",
    ""assignee_id"": ""2671362"",
    ""assigner_id"": ""2671355"",
    ""comment_count"": 10,
    ""is_completed"": false,
    ""content"": ""Buy Coffee"",
    ""description"": """",
    ""due"": {
        ""date"": ""2016-09-01"",
        ""is_recurring"": false,
        ""datetime"": ""2016-09-01T12:00:00.000000Z"",
        ""string"": ""tomorrow at 12"",
        ""timezone"": ""Europe/Moscow""
    },
    ""duration"": null,
    ""id"": ""2995104339"",
    ""labels"": [""Food"", ""Shopping""],
    ""order"": 1,
    ""priority"": 1,
    ""project_id"": ""2203306141"",
    ""section_id"": ""7025"",
    ""parent_id"": ""2995104589"",
    ""url"": ""https://todoist.com/showTask?id=2995104339""
}",
                    encoding: Encoding.UTF8,
                    mediaType: "application/json");
                return response;
            }
        };
        var client = new TodoistClient("TestToken", handlerMock);

        var actual = await client.Tasks.UpdateAsync(
            "2995104339",
            new Models.UpdateTaskArgs(
                content: "Buy Coffee"));

        Assert.Equal("2671355", actual.CreatorId);
        Assert.Equal(DateTimeOffset.Parse("2019-12-11T22:36:50.000000Z"), actual.CreatedAt);
        Assert.Equal("2671362", actual.AssigneeId);
        Assert.Equal("2671355", actual.AssignerId);
        Assert.Equal(10, actual.CommentCount);
        Assert.False(actual.IsCompleted);
        Assert.Equal("Buy Coffee", actual.Content);
        Assert.Equal("", actual.Description);
        Assert.NotNull(actual.Due);
        Assert.Equal(DateTimeOffset.Parse("2016-09-01"), actual.Due.Date);
        Assert.False(actual.Due.IsRecurring);
        Assert.Equal(DateTimeOffset.Parse("2016-09-01T12:00:00.000000Z"), actual.Due.DateTime);
        Assert.Equal("tomorrow at 12", actual.Due.String);
        Assert.Equal("Europe/Moscow", actual.Due.TimeZone);
        Assert.Null(actual.Duration);
        Assert.Equal("2995104339", actual.Id);
        Assert.Equal(2, actual.Labels.Count);
        Assert.Equal("Food", actual.Labels[0]);
        Assert.Equal("Shopping", actual.Labels[1]);
        Assert.Equal(1, actual.Order);
        Assert.Equal(1, actual.Priority);
        Assert.Equal("2203306141", actual.ProjectId);
        Assert.Equal("7025", actual.SectionId);
        Assert.Equal("2995104589", actual.ParentId);
        Assert.Equal("https://todoist.com/showTask?id=2995104339", actual.Url);
    }

    [Fact]
    public async Task DeleteAsyncTest()
    {
        var handlerMock = new MockHttpMessageHandler
        {
            SendDelegate = (r, _) =>
            {
                Assert.Equal(
                    "https://api.todoist.com/rest/v2/tasks/2995104339",
                    r.RequestUri?.AbsoluteUri);
                Assert.Equal(r.Method, HttpMethod.Delete);
                Assert.Equal("Bearer", r.Headers.Authorization?.Scheme);
                Assert.Equal("TestToken", r.Headers.Authorization?.Parameter);
                Assert.Null(r.Content);

                var response = new HttpResponseMessage(HttpStatusCode.NoContent);
                return Task.FromResult(response);
            }
        };
        var client = new TodoistClient("TestToken", handlerMock);

        var actual = await client.Tasks.DeleteAsync("2995104339");

        Assert.True(actual);
    }

    [Fact]
    public async Task CloseAsyncTest()
    {
        var handlerMock = new MockHttpMessageHandler
        {
            SendDelegate = (r, _) =>
            {
                Assert.Equal(
                    "https://api.todoist.com/rest/v2/tasks/2995104339/close",
                    r.RequestUri?.AbsoluteUri);
                Assert.Equal(r.Method, HttpMethod.Post);
                Assert.Equal("Bearer", r.Headers.Authorization?.Scheme);
                Assert.Equal("TestToken", r.Headers.Authorization?.Parameter);
                Assert.Null(r.Content);

                var response = new HttpResponseMessage(HttpStatusCode.NoContent);
                return Task.FromResult(response);
            },
        };
        var client = new TodoistClient("TestToken", handlerMock);

        var actual = await client.Tasks.CloseAsync("2995104339");

        Assert.True(actual);
    }

    [Fact]
    public async Task ReopenAsyncTest()
    {
        var handlerMock = new MockHttpMessageHandler
        {
            SendDelegate = (r, _) =>
            {
                Assert.Equal(
                    "https://api.todoist.com/rest/v2/tasks/2995104339/reopen",
                    r.RequestUri?.AbsoluteUri);
                Assert.Equal(HttpMethod.Post, r.Method);
                Assert.Equal("Bearer", r.Headers.Authorization?.Scheme);
                Assert.Equal("TestToken", r.Headers.Authorization?.Parameter);
                Assert.Null(r.Content);

                var response = new HttpResponseMessage(HttpStatusCode.NoContent);
                return Task.FromResult(response);
            }
        };
        var client = new TodoistClient("TestToken", handlerMock);

        var actual = await client.Tasks.ReopenAsync("2995104339");

        Assert.True(actual);
    }
}
