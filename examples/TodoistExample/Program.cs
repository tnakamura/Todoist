using System.Diagnostics;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Todoist;

var app = ConsoleApp.CreateBuilder(args)
    .ConfigureServices((hostContext, services) =>
    {
        services.Configure<MyConfig>(hostContext.Configuration);
    })
    .Build();
app.AddRootCommand(async (ConsoleAppContext ctx, IOptions<MyConfig> config) =>
{
    var state = Authentication.GetAuthStateParameter();
    var authorizationUrl = Authentication.GetAuthorizationUrl(
        clientId: config.Value.ClientId,
        permissions: new[]
        {
                Todoist.Models.Permission.TaskAdd,
                Todoist.Models.Permission.DataReadWrite,
                Todoist.Models.Permission.ProjectDelete,
        },
        state: state);

    var escapedUrl = authorizationUrl.Replace("&", "^&");
    Process.Start(new ProcessStartInfo("cmd", $"/c start {escapedUrl}")
    {
        CreateNoWindow = true,
    });

    Console.Write("Code:");
    var code = Console.ReadLine();

    var httpClient = new HttpClient();
    var authToken = await httpClient.GetAuthTokenAsync(
        new Todoist.Models.AuthTokenRequestArgs(
            clientId: config.Value.ClientId,
            clientSecret: config.Value.ClientSecret,
            code: code));
    Console.WriteLine($"AccessToken:{authToken.AccessToken}");

    httpClient.SetBearerToken(authToken.AccessToken);

    var projects = await httpClient.GetProjectsAsync();
    foreach (var project in projects)
    {
        Console.WriteLine($"Project:{project.Name}");
    }

    var sections = await httpClient.GetSectionsAsync();
    foreach (var section in sections)
    {
        Console.WriteLine($"Section:{section.Name}");
    }

    var labels = await httpClient.GetLabelsAsync();
    foreach (var label in labels)
    {
        Console.WriteLine($"Label:{label.Name}");
    }

    var tasks = await httpClient.GetTasksAsync();
    foreach (var task in tasks)
    {
        Console.WriteLine($"Task:{task.Content}");
    }
});
app.Run();

public class MyConfig
{
    public string? ClientId { get; set; }

    public string? ClientSecret { get; set; }
}

