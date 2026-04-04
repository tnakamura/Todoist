# Todoist API C# Client

Unofficial C# client library for Todoist API v1.

## Features

This library currently supports:

- OAuth token exchange and revoke (`AuthToken`)
- Tasks (`Get`, `List`, `Create`, `Update`, `Close`, `Reopen`, `Delete`, `Quick Add`)
- Projects (`Get`, `List`, `Create`, `Update`, `Delete`)
- Project collaborators (`List`)
- Sections (`Get`, `List`, `Create`, `Update`, `Delete`)
- Labels (`Get`, `List`, `Create`, `Update`, `Delete`)
- Shared labels (`List`, `Rename`, `Remove`)
- Comments (`Get`, `List`, `Create`, `Update`, `Delete`)
- Reminders (`List` / read-only)
- Cursor-based pagination via `GetPageAsync(...)` returning `PagedResult<T>` with `NextCursor`

## Installation

```bash
dotnet add package Todoist
```

## Requirements

- .NET Standard 2.0 compatible runtime

## Quick Start (Personal Access Token)

```csharp
using Todoist;

var client = new TodoistClient("YOUR_ACCESS_TOKEN");

var tasks = await client.Tasks.GetAllAsync();
foreach (var task in tasks)
{
    Console.WriteLine(task.Content);
}
```

## Common Usage

### Create a task

```csharp
using Todoist.Models;

var created = await client.Tasks.CreateAsync(new CreateTaskArgs(
    content: "Review pull request",
    priority: 4));
```

### Quick Add

```csharp
using Todoist.Models;

var quick = await client.Tasks.QuickAddAsync(new QuickAddTaskArgs(
    text: "Pay rent tomorrow 9am #Admin"));
```

### Pagination

```csharp
using Todoist.Models;

string? cursor = null;
do
{
    var page = await client.Tasks.GetPageAsync(
        args: new GetTasksArgs { Filter = "today" },
        cursor: cursor);

    foreach (var item in page.Items)
    {
        Console.WriteLine(item.Content);
    }

    cursor = page.NextCursor;
}
while (!string.IsNullOrEmpty(cursor));
```

## OAuth Flow Helpers

The library includes helper methods for Todoist OAuth URL generation:

- `Authentication.GetAuthStateParameter()`
- `Authentication.GetAuthorizationUrl(clientId, permissions, state)`

Token exchange/revoke endpoints are available from `client.AuthToken`.

## Error Handling

- API failures throw `TodoistException`
- `TodoistException.StatusCode` contains the HTTP status when available

Example:

```csharp
try
{
    var task = await client.Tasks.GetAsync("task-id");
}
catch (TodoistException ex)
{
    Console.WriteLine($"Error: {ex.StatusCode} - {ex.Message}");
}
```

## Running Tests Locally

From repository root:

```bash
dotnet test --nologo
```

## License

MIT License. See [LICENSE](LICENSE).
