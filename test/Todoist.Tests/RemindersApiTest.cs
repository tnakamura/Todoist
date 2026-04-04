using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Todoist.Test;

public class RemindersApiTest
{
    [Fact]
    public async Task GetAllAsyncTest()
    {
        var handlerMock = new MockHttpMessageHandler
        {
            SendDelegate = (r, _) =>
            {
                Assert.Equal("https://api.todoist.com/api/v1/reminders", r.RequestUri?.AbsoluteUri);
                Assert.Equal(HttpMethod.Get, r.Method);
                Assert.Equal("Bearer", r.Headers.Authorization?.Scheme);
                Assert.Equal("TestToken", r.Headers.Authorization?.Parameter);

                var response = new HttpResponseMessage(HttpStatusCode.OK);
                response.Content = new StringContent(
                    content: @"[
    {
        ""id"": ""1"",
        ""notify_uid"": ""2671362"",
        ""item_id"": ""2995104339"",
        ""service"": ""push"",
        ""type"": ""relative""
    }
]",
                    encoding: Encoding.UTF8,
                    mediaType: "application/json");
                return Task.FromResult(response);
            }
        };
        var client = new TodoistClient("TestToken", handlerMock);

        var reminders = await client.Reminders.GetAllAsync();

        Assert.Single(reminders);
        Assert.Equal("1", reminders[0].Id);
    }

    [Fact]
    public async Task GetPageAsyncTest()
    {
        var handlerMock = new MockHttpMessageHandler
        {
            SendDelegate = (r, _) =>
            {
                Assert.Equal("https://api.todoist.com/api/v1/reminders?cursor=CURSOR1", r.RequestUri?.AbsoluteUri);
                var response = new HttpResponseMessage(HttpStatusCode.OK);
                response.Headers.Add("Link", "<https://api.todoist.com/api/v1/reminders?cursor=CURSOR2>; rel=\"next\"");
                response.Content = new StringContent(
                    content: @"[
    {
        ""id"": ""1"",
        ""notify_uid"": ""2671362"",
        ""item_id"": ""2995104339"",
        ""service"": ""push"",
        ""type"": ""relative""
    }
]",
                    encoding: Encoding.UTF8,
                    mediaType: "application/json");
                return Task.FromResult(response);
            }
        };
        var client = new TodoistClient("TestToken", handlerMock);

        var page = await client.Reminders.GetPageAsync("CURSOR1");

        Assert.Single(page.Items);
        Assert.Equal("CURSOR2", page.NextCursor);
    }
}
