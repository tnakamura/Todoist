using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Todoist.Test;

public class CommentsApiTest
{
    [Fact]
    public async Task GetAllAsyncTest()
    {
        var handlerMock = new MockHttpMessageHandler
        {
            SendDelegate = (r, _) =>
            {
                Assert.Equal(HttpMethod.Get, r.Method);
                Assert.Equal("Bearer", r.Headers.Authorization?.Scheme);
                Assert.Equal("TestToken", r.Headers.Authorization?.Parameter);
                Assert.Equal(
                    "https://api.todoist.com/rest/v2/comments?task_id=2995104339",
                    r.RequestUri?.AbsoluteUri);

                var response = new HttpResponseMessage(HttpStatusCode.OK);
                response.Content = new StringContent(
                    content: @"[
    {
        ""content"": ""Need one bottle of milk"",
        ""id"": ""2992679862"",
        ""posted_at"": ""2016-09-22T07:00:00.000000Z"",
        ""project_id"": null,
        ""task_id"": ""2995104339"",
        ""attachment"": {
            ""file_name"": ""File.pdf"",
            ""file_type"": ""application/pdf"",
            ""file_url"": ""https://cdn-domain.tld/path/to/file.pdf"",
            ""resource_type"": ""file""
        }
    }
]",
                    encoding: Encoding.UTF8,
                    mediaType: "application/json");
                return Task.FromResult(response);
            },
        };
        var client = new TodoistClient("TestToken", handlerMock);

        var comments = await client.Comments.GetAllAsync(
            new Models.GetTaskCommentsArgs("2995104339"));

        Assert.Single(comments);
        Assert.Equal("2992679862", comments[0].Id);
        Assert.Equal("2995104339", comments[0].TaskId);
        Assert.Null(comments[0].ProjectId);
        Assert.Equal("Need one bottle of milk", comments[0].Content);
        Assert.Equal(new DateTimeOffset(2016, 9, 22, 7, 0, 0, TimeSpan.Zero), comments[0].PostedAt);
        Assert.NotNull(comments[0].Attachment);
        Assert.Equal("file", comments[0].Attachment?.ResourceType);
        Assert.Equal("https://cdn-domain.tld/path/to/file.pdf", comments[0].Attachment?.FileUrl);
        Assert.Equal("application/pdf", comments[0].Attachment?.FileType);
        Assert.Equal("File.pdf", comments[0].Attachment?.FileName);
    }

    [Fact]
    public async Task GetAsyncTest()
    {
        var handlerMock = new MockHttpMessageHandler
        {
            SendDelegate = (r, _) =>
            {
                Assert.Equal(
                    "https://api.todoist.com/rest/v2/comments/2992679862",
                    r.RequestUri?.AbsoluteUri);
                Assert.Equal(HttpMethod.Get, r.Method);
                Assert.Equal("Bearer", r.Headers.Authorization?.Scheme);
                Assert.Equal("TestToken", r.Headers.Authorization?.Parameter);

                var response = new HttpResponseMessage(HttpStatusCode.OK);
                response.Content = new StringContent(
                    content: @"{
    ""content"": ""Need one bottle of milk"",
    ""id"": ""2992679862"",
    ""posted_at"": ""2016-09-22T07:00:00.000000Z"",
    ""project_id"": null,
    ""task_id"": ""2995104339"",
    ""attachment"": {
        ""file_name"": ""File.pdf"",
        ""file_type"": ""application/pdf"",
        ""file_url"": ""https://s3.amazonaws.com/domorebetter/TodoistSetupGuide.pdf"",
        ""resource_type"": ""file""
    }
}",
                    encoding: Encoding.UTF8,
                    mediaType: "application/json");
                return Task.FromResult(response);
            }
        };
        var client = new TodoistClient("TestToken", handlerMock);

        var comment = await client.Comments.GetAsync("2992679862");

        Assert.Equal("2992679862", comment.Id);
        Assert.Equal("2995104339", comment.TaskId);
        Assert.Null(comment.ProjectId);
        Assert.Equal("Need one bottle of milk", comment.Content);
        Assert.Equal(new DateTimeOffset(2016, 9, 22, 7, 0, 0, TimeSpan.Zero), comment.PostedAt);
        Assert.NotNull(comment.Attachment);
        Assert.Equal("file", comment.Attachment.ResourceType);
        Assert.Equal(
            "https://s3.amazonaws.com/domorebetter/TodoistSetupGuide.pdf",
            comment.Attachment.FileUrl);
        Assert.Equal("application/pdf", comment.Attachment.FileType);
        Assert.Equal("File.pdf", comment.Attachment.FileName);
    }

    [Fact]
    public async Task CreateAsyncTest()
    {
        var handlerMock = new MockHttpMessageHandler
        {
            SendDelegate = async (r, _) =>
            {
                Assert.Equal(
                    "https://api.todoist.com/rest/v2/comments",
                    r.RequestUri?.AbsoluteUri);
                Assert.Equal(HttpMethod.Post, r.Method);
                Assert.Equal("Bearer", r.Headers.Authorization?.Scheme);
                Assert.Equal("TestToken", r.Headers.Authorization?.Parameter);

                var content = await r.Content!.ReadAsStringAsync();
                Assert.Contains("\"task_id\":\"2995104339\"", content);
                Assert.Contains("\"content\":\"Need one bottle of milk\"", content);
                Assert.Contains("\"attachment\":", content);
                Assert.Contains("\"resource_type\":\"file\"", content);
                Assert.Contains("\"file_type\":\"application/pdf\"", content);
                Assert.Contains(
                    $"\"file_url\":\"https://s3.amazonaws.com/domorebetter/TodoistSetupGuide.pdf\"",
                    content);
                Assert.Contains("\"file_name\":\"File.pdf\"", content);

                var response = new HttpResponseMessage(HttpStatusCode.OK);
                response.Content = new StringContent(
                    content: @"{
    ""content"": ""Need one bottle of milk"",
    ""id"": ""2992679862"",
    ""posted_at"": ""2016-09-22T07:00:00.000000Z"",
    ""project_id"": null,
    ""task_id"": ""2995104339"",
    ""attachment"": {
        ""file_name"": ""File.pdf"",
        ""file_type"": ""application/pdf"",
        ""file_url"": ""https://s3.amazonaws.com/domorebetter/TodoistSetupGuide.pdf"",
        ""resource_type"": ""file""
    }
}",
                    encoding: Encoding.UTF8,
                    mediaType: "application/json");
                return response;
            },
        };
        var client = new TodoistClient("TestToken", handlerMock);

        var comment = await client.Comments.CreateAsync(
            new Models.AddTaskCommentArgs(
                content: "Need one bottle of milk",
                taskId: "2995104339",
                attachment: new Models.Attachment(
                    resourceType: "file",
                    fileUrl: "https://s3.amazonaws.com/domorebetter/TodoistSetupGuide.pdf",
                    fileType: "application/pdf",
                    fileName: "File.pdf")));

        Assert.Equal("2992679862", comment.Id);
        Assert.Equal("2995104339", comment.TaskId);
        Assert.Null(comment.ProjectId);
        Assert.Equal("Need one bottle of milk", comment.Content);
        Assert.Equal(new DateTimeOffset(2016, 9, 22, 7, 0, 0, TimeSpan.Zero), comment.PostedAt);
        Assert.NotNull(comment.Attachment);
        Assert.Equal("file", comment.Attachment.ResourceType);
        Assert.Equal("https://s3.amazonaws.com/domorebetter/TodoistSetupGuide.pdf", comment.Attachment.FileUrl);
        Assert.Equal("application/pdf", comment.Attachment.FileType);
        Assert.Equal("File.pdf", comment.Attachment.FileName);
    }

    [Fact]
    public async Task UpdateAsyncTest()
    {
        var handlerMock = new MockHttpMessageHandler
        {
            SendDelegate = async (r, _) =>
            {
                Assert.Equal(
                    "https://api.todoist.com/rest/v2/comments/2992679862",
                    r.RequestUri?.AbsoluteUri);
                Assert.Equal(HttpMethod.Post, r.Method);
                Assert.Equal("Bearer", r.Headers.Authorization?.Scheme);
                Assert.Equal("TestToken", r.Headers.Authorization?.Parameter);
                Assert.Contains("\"content\":\"Need two bottles of milk\"", await r.Content!.ReadAsStringAsync());

                var response = new HttpResponseMessage(HttpStatusCode.NoContent);
                response.Content = new StringContent(
                    content: @"{
    ""content"": ""Need two bottles of milk"",
    ""id"": ""2992679862"",
    ""posted_at"": ""2016-09-22T07:00:00.000000Z"",
    ""project_id"": null,
    ""task_id"": ""2995104339"",
    ""attachment"": {
        ""file_name"": ""File.pdf"",
        ""file_type"": ""application/pdf"",
        ""file_url"": ""https://s3.amazonaws.com/domorebetter/TodoistSetupGuide.pdf"",
        ""resource_type"": ""file""
    }
}",
                    encoding: Encoding.UTF8,
                    mediaType: "application/json");
                return response;
            }
        };
        var client = new TodoistClient("TestToken", handlerMock);

        var comment = await client.Comments.UpdateAsync(
            "2992679862",
            new Models.UpdateCommentArgs(
                content: "Need two bottles of milk"));

        Assert.Equal("2992679862", comment.Id);
        Assert.Equal("2995104339", comment.TaskId);
        Assert.Null(comment.ProjectId);
        Assert.Equal("Need two bottles of milk", comment.Content);
        Assert.Equal(new DateTimeOffset(2016, 9, 22, 7, 0, 0, TimeSpan.Zero), comment.PostedAt);
        Assert.NotNull(comment.Attachment);
        Assert.Equal("file", comment.Attachment.ResourceType);
        Assert.Equal("https://s3.amazonaws.com/domorebetter/TodoistSetupGuide.pdf", comment.Attachment.FileUrl);
        Assert.Equal("application/pdf", comment.Attachment.FileType);
        Assert.Equal("File.pdf", comment.Attachment.FileName);
    }

    [Fact]
    public async Task DeleteAsyncTest()
    {
        var handlerMock = new MockHttpMessageHandler
        {
            SendDelegate = (r, _) =>
            {
                Assert.Equal(
                    "https://api.todoist.com/rest/v2/comments/2992679862",
                    r.RequestUri?.AbsoluteUri);
                Assert.Equal(HttpMethod.Delete, r.Method);
                Assert.Equal("Bearer", r.Headers.Authorization?.Scheme);
                Assert.Equal("TestToken", r.Headers.Authorization?.Parameter);

                var response = new HttpResponseMessage(HttpStatusCode.NoContent);
                return Task.FromResult(response);
            }
        };
        var client = new TodoistClient("TestToken", handlerMock);

        var actual = await client.Comments.DeleteAsync("2992679862");

        Assert.True(actual);
    }
}
