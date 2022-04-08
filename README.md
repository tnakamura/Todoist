# Todoist API C# Client

This is the unofficial C# API client for the Todoist REST API.


## Installation

```sh
Install-Package Todoist
```


## Usage

An example of initializing the API client and fetching a user's tasks:

```cs
using Systen.Net.Http;
using Todoist;

const string token = "YOURTOKEN";

var client = new HttpClient();
client.SetBeareToken(token);

var tasks = await client.GetTasksAsync();

foreach (var task in tasks)
{
    Console.WriteLine(task.Content);
}
```

