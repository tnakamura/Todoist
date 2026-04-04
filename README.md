# Todoist API C# Client

This is the unofficial C# API client for the Todoist API v1.

## API Coverage

Implemented clients:

- AuthToken
- Tasks (including Quick Add)
- Projects (including Collaborators)
- Sections
- Labels (including Shared Labels)
- Comments
- Reminders (read)

Pagination:

- `GetPageAsync(...)` is available for list-style endpoints and returns items with `NextCursor`.


## Installation

```sh
dotnet add package Todoist
```


## Usage

An example of initializing the API client and fetching a user's tasks:

```cs
using Todoist;

var client = new TodoistClient("YOURTOKEN");

var tasks = await client.Tasks.GetAllAsync();

foreach (var task in tasks)
{
    Console.WriteLine(task.Content);
}
```
