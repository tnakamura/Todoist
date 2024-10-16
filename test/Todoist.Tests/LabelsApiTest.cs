using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using static Todoist.Constants.Endpoints;

namespace Todoist.Test;

public class LabelsApiTest
{
    [Fact]
    public async Task GetAllAsyncTest()
    {
        var handlerMock = new MockHttpMessageHandler
        {
            SendDelegate = static (r, _) =>
            {
                Assert.Equal("https://api.todoist.com/rest/v2/labels", r.RequestUri?.AbsoluteUri);
                Assert.Equal(r.Method, HttpMethod.Get);
                Assert.Equal("Bearer", r.Headers.Authorization?.Scheme);
                Assert.Equal("TestToken", r.Headers.Authorization?.Parameter);

                var response = new HttpResponseMessage(HttpStatusCode.OK);
                response.Content = new StringContent(
                    content: @"[
    {
        ""id"": ""2156154810"",
        ""name"": ""Food"",
        ""color"": ""charcoal"",
        ""order"": 1,
        ""is_favorite"": false
    }
]",
                    encoding: Encoding.UTF8,
                    mediaType: "application/json");
                return Task.FromResult(response);
            }
        };
        var client = new TodoistClient("TestToken", handlerMock);

        var labels = await client.Labels.GetAllAsync();

        Assert.Single(labels);
        Assert.Equal("2156154810", labels[0].Id);
        Assert.Equal("Food", labels[0].Name);
        Assert.Equal("charcoal", labels[0].Color);
        Assert.Equal(1, labels[0].Order);
        Assert.False(labels[0].IsFavorite);
    }

    [Fact]
    public async Task GetAsyncTest()
    {
        var handlerMock = new MockHttpMessageHandler
        {
            SendDelegate = (r, _) =>
            {
                Assert.Equal("https://api.todoist.com/rest/v2/labels/2156154810", r.RequestUri?.AbsoluteUri);
                Assert.Equal(r.Method, HttpMethod.Get);
                Assert.Equal("Bearer", r.Headers.Authorization?.Scheme);
                Assert.Equal("TestToken", r.Headers.Authorization?.Parameter);

                var response = new HttpResponseMessage(HttpStatusCode.OK);
                response.Content = new StringContent(
                    content: @"{
    ""id"": ""2156154810"",
    ""name"": ""Food"",
    ""color"": ""charcoal"",
    ""order"": 1,
    ""is_favorite"": false
}",
                    encoding: Encoding.UTF8,
                    mediaType: "application/json");
                return Task.FromResult(response);
            }
        };
        var client = new TodoistClient("TestToken", handlerMock);

        var label = await client.Labels.GetAsync("2156154810");

        Assert.Equal("2156154810", label.Id);
        Assert.Equal("Food", label.Name);
        Assert.Equal("charcoal", label.Color);
        Assert.Equal(1, label.Order);
        Assert.False(label.IsFavorite);
    }

    [Fact]
    public async Task CreateAsyncTest()
    {
        var handlerMock = new MockHttpMessageHandler
        {
            SendDelegate = async (r, _) =>
            {
                Assert.Equal("https://api.todoist.com/rest/v2/labels", r.RequestUri?.AbsoluteUri);
                Assert.Equal(HttpMethod.Post, r.Method);
                Assert.Equal("Bearer", r.Headers.Authorization?.Scheme);
                Assert.Equal("TestToken", r.Headers.Authorization?.Parameter);
                Assert.Contains("\"name\":\"Food\"", await r.Content!.ReadAsStringAsync());

                var response = new HttpResponseMessage(HttpStatusCode.OK);
                response.Content = new StringContent(
                    content: @"{
    ""id"": ""2156154810"",
    ""name"": ""Food"",
    ""color"": ""charcoal"",
    ""order"": 1,
    ""is_favorite"": false
}",
                    encoding: Encoding.UTF8,
                    mediaType: "application/json");
                return response;
            }
        };
        var client = new TodoistClient("TestToken", handlerMock);

        var label = await client.Labels.CreateAsync(
            new Models.CreateLabelArgs(
                name: "Food"));

        Assert.Equal("2156154810", label.Id);
        Assert.Equal("Food", label.Name);
        Assert.Equal("charcoal", label.Color);
        Assert.Equal(1, label.Order);
        Assert.False(label.IsFavorite);
    }

    [Fact]
    public async Task UpdateAsyncTest()
    {
        var handlerMock = new MockHttpMessageHandler
        {
            SendDelegate = async (r, _) =>
            {
                Assert.Equal("https://api.todoist.com/rest/v2/labels/2156154810", r.RequestUri?.AbsoluteUri);
                Assert.Equal(HttpMethod.Post, r.Method);
                Assert.Equal("Bearer", r.Headers.Authorization?.Scheme);
                Assert.Equal("TestToken", r.Headers.Authorization?.Parameter);
                Assert.Contains("\"name\":\"Drinks\"", await r.Content!.ReadAsStringAsync());

                var response = new HttpResponseMessage(HttpStatusCode.NoContent);
                response.Content = new StringContent(
                    content: @"{
    ""id"": ""2156154810"",
    ""name"": ""Drinks"",
    ""color"": ""charcoal"",
    ""order"": 1,
    ""is_favorite"": false
}",
                    encoding: Encoding.UTF8,
                    mediaType: "application/json");
                return response;
            }
        };
        var client = new TodoistClient("TestToken", handlerMock);

        var label = await client.Labels.UpdateAsync(
            "2156154810",
            new Models.UpdateLabelArgs(
                name: "Drinks"));

        Assert.Equal("2156154810", label.Id);
        Assert.Equal("Drinks", label.Name);
        Assert.Equal("charcoal", label.Color);
        Assert.Equal(1, label.Order);
        Assert.False(label.IsFavorite);
    }

    [Fact]
    public async Task DeleteAsyncTest()
    {
        var handlerMock = new MockHttpMessageHandler
        {
            SendDelegate = (r, _) =>
            {
                Assert.Equal("https://api.todoist.com/rest/v2/labels/2156154810", r.RequestUri?.AbsoluteUri);
                Assert.Equal(HttpMethod.Delete, r.Method);
                Assert.Equal("Bearer", r.Headers.Authorization?.Scheme);
                Assert.Equal("TestToken", r.Headers.Authorization?.Parameter);

                var response = new HttpResponseMessage(HttpStatusCode.NoContent);
                return Task.FromResult(response);
            }
        };
        var client = new TodoistClient("TestToken", handlerMock);

        var actual = await client.Labels.DeleteAsync("2156154810");

        Assert.True(actual);
    }
}
