using System.Diagnostics;
using Todoist;

var clientId = args[0];
var clientSecret = args[1];

var state = Authentication.GetAuthStateParameter();
var authorizationUrl = Authentication.GetAuthorizationUrl(
    clientId: clientId,
    permissions: [
        Todoist.Models.Permission.TaskAdd,
        Todoist.Models.Permission.DataReadWrite,
        Todoist.Models.Permission.ProjectDelete,
    ],
    state: state);

var escapedUrl = authorizationUrl.Replace("&", "^&");
Process.Start(new ProcessStartInfo("cmd", $"/c start {escapedUrl}")
{
    CreateNoWindow = true,
});

Console.Write("Code:");
var code = Console.ReadLine();

var httpClient = new TodoistClient();
var authToken = await httpClient.AuthToken.GetAsync(
    new Todoist.Models.AuthTokenRequestArgs(
        clientId: clientId,
        clientSecret: clientSecret,
        code: code!));
Console.WriteLine($"AccessToken:{authToken.AccessToken}");

httpClient = new TodoistClient(authToken.AccessToken);

var projects = await httpClient.Projects.GetAllAsync();
foreach (var project in projects)
{
    Console.WriteLine($"Project:{project.Name}");
}

var sections = await httpClient.Sections.GetAllAsync();
foreach (var section in sections)
{
    Console.WriteLine($"Section:{section.Name}");
}

var labels = await httpClient.Labels.GetAllAsync();
foreach (var label in labels)
{
    Console.WriteLine($"Label:{label.Name}");
}

var tasks = await httpClient.Tasks.GetAllAsync();
foreach (var task in tasks)
{
    Console.WriteLine($"Task:{task.Content}");
}

Console.WriteLine("Press Enter Key...");
Console.ReadLine();
