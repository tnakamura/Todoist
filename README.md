# Todoist API C# Client

This is the unofficial C# API client for the Todoist REST API.


## Installation

```sh
Install-Package Todoist
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

