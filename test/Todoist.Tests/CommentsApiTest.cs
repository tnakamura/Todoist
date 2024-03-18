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
    public class CommentsApiTest
    {
        [Fact]
        public async Task GetAllAsyncTest()
        {
            var handlerMock = new Mock<HttpMessageHandler>();
            handlerMock.Protected()
                .As<IHttpMessageHandler>()
                .Setup(m => m.SendAsync(
                    It.Is<HttpRequestMessage>(r =>
                        r.RequestUri.AbsoluteUri == (API_REST_BASE_URI + ENDPOINT_REST_COMMENTS + "?task_id=2995104339") &&
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
        ""id"": 2992679862,
        ""task_id"": 2995104339,
        ""content"": ""Need one bottle of milk"",
        ""posted"": ""2016-09-22T07:00:00Z"",
        ""attachment"": {
            ""resource_type"": ""file"",
            ""file_url"": ""https://cdn-domain.tld/path/to/file.pdf"",
            ""file_type"": ""application/pdf"",
            ""file_name"": ""File.pdf""
        }
    }
]",
                        encoding: Encoding.UTF8,
                        mediaType: "application/json");
                    return Task.FromResult(response);
                });
            var client = new TodoistClient("TestToken", handlerMock.Object);

            var comments = await client.Comments.GetAllAsync(
                new Models.GetTaskCommentsArgs(2995104339));

            Assert.Single(comments);
            Assert.Equal(2992679862, comments[0].Id);
            Assert.Equal(2995104339, comments[0].TaskId);
            Assert.Equal("Need one bottle of milk", comments[0].Content);
            Assert.Equal(new DateTimeOffset(2016, 9, 22, 7, 0, 0, TimeSpan.Zero), comments[0].Posted);
            Assert.NotNull(comments[0].Attachment);
            Assert.Equal("file", comments[0].Attachment.ResourceType);
            Assert.Equal("https://cdn-domain.tld/path/to/file.pdf", comments[0].Attachment.FileUrl);
            Assert.Equal("application/pdf", comments[0].Attachment.FileType);
            Assert.Equal("File.pdf", comments[0].Attachment.FileName);
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
                        r.RequestUri.AbsoluteUri == (API_REST_BASE_URI + ENDPOINT_REST_COMMENTS + "/2992679862") &&
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
    ""id"": 2992679862,
    ""content"": ""Need one bottle of milk"",
    ""task_id"": 2995104339,
    ""posted"": ""2016-09-22T07:00:00Z"",
    ""attachment"": {
        ""resource_type"": ""file"",
        ""file_url"": ""https://cdn-domain.tld/path/to/file.pdf"",
        ""file_type"": ""application/pdf"",
        ""file_name"": ""File.pdf""
    }
}",
                        encoding: Encoding.UTF8,
                        mediaType: "application/json");
                    return Task.FromResult(response);
                });
            var client = new TodoistClient("TestToken", handlerMock.Object);

            var comment = await client.Comments.GetAsync(2992679862);

            Assert.Equal(2992679862, comment.Id);
            Assert.Equal(2995104339, comment.TaskId);
            Assert.Equal("Need one bottle of milk", comment.Content);
            Assert.Equal(new DateTimeOffset(2016, 9, 22, 7, 0, 0, TimeSpan.Zero), comment.Posted);
            Assert.NotNull(comment.Attachment);
            Assert.Equal("file", comment.Attachment.ResourceType);
            Assert.Equal("https://cdn-domain.tld/path/to/file.pdf", comment.Attachment.FileUrl);
            Assert.Equal("application/pdf", comment.Attachment.FileType);
            Assert.Equal("File.pdf", comment.Attachment.FileName);
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
                        r.RequestUri.AbsoluteUri == (API_REST_BASE_URI + ENDPOINT_REST_COMMENTS) &&
                        r.Method == HttpMethod.Post &&
                        r.Headers.Authorization.Scheme == "Bearer" &&
                        r.Headers.Authorization.Parameter == "TestToken" &&
                        r.Content.ReadAsStringAsync().GetAwaiter().GetResult().Contains("\"content\":\"Need one bottle of milk\"") &&
                        r.Content.ReadAsStringAsync().GetAwaiter().GetResult().Contains("\"task_id\":2995104339") &&
                        r.Content.ReadAsStringAsync().GetAwaiter().GetResult().Contains("\"attachment\":") &&
                        r.Content.ReadAsStringAsync().GetAwaiter().GetResult().Contains("\"resource_type\":\"file\"") &&
                        //r.Content.ReadAsStringAsync().GetAwaiter().GetResult().Contains("\"file_url\":\"https://s3.amazonaws.com/domorebetter/Todoist+Setup+Guide.pdf\"") &&
                        r.Content.ReadAsStringAsync().GetAwaiter().GetResult().Contains("\"file_type\":\"application/pdf\"") &&
                        r.Content.ReadAsStringAsync().GetAwaiter().GetResult().Contains("\"file_name\":\"File.pdf\"")
                    ),
                    It.IsAny<CancellationToken>()))
                .Returns(() =>
                {
                    var response = new HttpResponseMessage(HttpStatusCode.OK);
                    response.Content = new StringContent(
                        content: @"{
    ""id"": 2992679862,
    ""content"": ""Need one bottle of milk"",
    ""task_id"": 2995104339,
    ""posted"": ""2016-09-22T07:00:00Z"",
    ""attachment"": {
        ""resource_type"": ""file"",
        ""file_url"": ""https://s3.amazonaws.com/domorebetter/Todoist+Setup+Guide.pdf"",
        ""file_type"": ""application/pdf"",
        ""file_name"": ""File.pdf""
    }
}",
                        encoding: Encoding.UTF8,
                        mediaType: "application/json");
                    return Task.FromResult(response);
                });
            var client = new TodoistClient("TestToken", handlerMock.Object);

            var comment = await client.Comments.CreateAsync(
                new Models.AddTaskCommentArgs(
                    content: "Need one bottle of milk",
                    taskId: 2995104339,
                    attachment: new Models.Attachment(
                        resourceType: "file",
                        fileUrl: "https://s3.amazonaws.com/domorebetter/Todoist+Setup+Guide.pdf",
                        fileType: "application/pdf",
                        fileName: "File.pdf")));

            Assert.Equal(2992679862, comment.Id);
            Assert.Equal(2995104339, comment.TaskId);
            Assert.Equal("Need one bottle of milk", comment.Content);
            Assert.Equal(new DateTimeOffset(2016, 9, 22, 7, 0, 0, TimeSpan.Zero), comment.Posted);
            Assert.NotNull(comment.Attachment);
            Assert.Equal("file", comment.Attachment.ResourceType);
            Assert.Equal("https://s3.amazonaws.com/domorebetter/Todoist+Setup+Guide.pdf", comment.Attachment.FileUrl);
            Assert.Equal("application/pdf", comment.Attachment.FileType);
            Assert.Equal("File.pdf", comment.Attachment.FileName);
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
                        r.RequestUri.AbsoluteUri == (API_REST_BASE_URI + ENDPOINT_REST_COMMENTS + "/2992679862") &&
                        r.Method == HttpMethod.Post &&
                        r.Headers.Authorization.Scheme == "Bearer" &&
                        r.Headers.Authorization.Parameter == "TestToken" &&
                        r.Content.ReadAsStringAsync().GetAwaiter().GetResult().Contains("\"content\":\"Need two bottles of milk\"")
                    ),
                    It.IsAny<CancellationToken>()))
                .Returns(() =>
                {
                    var response = new HttpResponseMessage(HttpStatusCode.NoContent);
                    return Task.FromResult(response);
                });
            var client = new TodoistClient("TestToken", handlerMock.Object);

            var actual = await client.Comments.UpdateAsync(
                2992679862,
                new Models.UpdateCommentArgs(
                    content: "Need two bottles of milk"));

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
                        r.RequestUri.AbsoluteUri == (API_REST_BASE_URI + ENDPOINT_REST_COMMENTS + "/2992679862") &&
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
            var client = new TodoistClient("TestToken", handlerMock.Object);

            var actual = await client.Comments.DeleteAsync(2992679862);

            Assert.True(actual);
            handlerMock.VerifyAll();
        }
    }
}
