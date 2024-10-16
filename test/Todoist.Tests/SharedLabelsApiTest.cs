using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Todoist.Test;

public class SharedLabelsApiTest
{
    [Fact]
    public async Task GetAllAsyncTest()
    {
        var handlerMock = new MockHttpMessageHandler
        {
            SendDelegate = static (r, _) =>
            {
                Assert.Equal("https://api.todoist.com/rest/v2/labels/shared", r.RequestUri?.AbsoluteUri);
                Assert.Equal(r.Method, HttpMethod.Get);
                Assert.Equal("Bearer", r.Headers.Authorization?.Scheme);
                Assert.Equal("TestToken", r.Headers.Authorization?.Parameter);

                var response = new HttpResponseMessage(HttpStatusCode.OK);
                response.Content = new StringContent(
                    content: @"[
    ""Label1"",
    ""Label2"",
    ""Label3""
]",
                    encoding: Encoding.UTF8,
                    mediaType: "application/json");
                return Task.FromResult(response);
            }
        };
        var client = new TodoistClient("TestToken", handlerMock);

        var labels = await client.Labels.SharedLabels.GetAllAsync();

        Assert.Equal(3, labels.Count);
        Assert.Equal("Label1", labels[0]);
        Assert.Equal("Label2", labels[1]);
        Assert.Equal("Label3", labels[2]);
    }

    [Fact]
    public async Task RenameAsyncTest()
    {
        var handlerMock = new MockHttpMessageHandler
        {
            SendDelegate = async (r, _) =>
            {
                Assert.Equal("https://api.todoist.com/rest/v2/labels/shared/rename", r.RequestUri?.AbsoluteUri);
                Assert.Equal(HttpMethod.Post, r.Method);
                Assert.Equal("Bearer", r.Headers.Authorization?.Scheme);
                Assert.Equal("TestToken", r.Headers.Authorization?.Parameter);
                Assert.Contains("\"name\":\"MyLabel\"", await r.Content!.ReadAsStringAsync());
                Assert.Contains("\"new_name\":\"RenamedLabel\"", await r.Content!.ReadAsStringAsync());

                var response = new HttpResponseMessage(HttpStatusCode.NoContent);
                return response;
            }
        };
        var client = new TodoistClient("TestToken", handlerMock);

        var actual = await client.Labels.SharedLabels.RenameAsync(new(
            name: "MyLabel",
            newName: "RenamedLabel"));

        Assert.True(actual);
    }

    [Fact]
    public async Task RemoveAsyncTest()
    {
        var handlerMock = new MockHttpMessageHandler
        {
            SendDelegate = async (r, _) =>
            {
                Assert.Equal("https://api.todoist.com/rest/v2/labels/shared/remove", r.RequestUri?.AbsoluteUri);
                Assert.Equal(HttpMethod.Post, r.Method);
                Assert.Equal("Bearer", r.Headers.Authorization?.Scheme);
                Assert.Equal("TestToken", r.Headers.Authorization?.Parameter);
                Assert.Contains("\"name\":\"MyLabel\"", await r.Content!.ReadAsStringAsync());

                var response = new HttpResponseMessage(HttpStatusCode.NoContent);
                return response;
            }
        };
        var client = new TodoistClient("TestToken", handlerMock);

        var actual = await client.Labels.SharedLabels.RemoveAsync(new(
            name: "MyLabel"));

        Assert.True(actual);
    }
}


