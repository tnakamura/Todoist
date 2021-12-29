# Todoist - the C# library for the Todoist

Todoist REST API

<a name="frameworks-supported"></a>
## Frameworks supported
- .NET Core >=1.0
- .NET Framework >=4.6
- Mono/Xamarin >=vNext

<a name="dependencies"></a>
## Dependencies

- [Json.NET](https://www.nuget.org/packages/Newtonsoft.Json/) - 12.0.3 or later
- [JsonSubTypes](https://www.nuget.org/packages/JsonSubTypes/) - 1.8.0 or later
- [System.ComponentModel.Annotations](https://www.nuget.org/packages/System.ComponentModel.Annotations) - 5.0.0 or later

The DLLs included in the package may not be the latest version. We recommend using [NuGet](https://docs.nuget.org/consume/installing-nuget) to obtain the latest version of the packages:
```
Install-Package Newtonsoft.Json
Install-Package JsonSubTypes
Install-Package System.ComponentModel.Annotations
```
<a name="installation"></a>
## Installation
Generate the DLL using your preferred tool (e.g. `dotnet build`)

Then include the DLL (under the `bin` folder) in the C# project, and use the namespaces:
```csharp
using Todoist;
using Todoist.Client;
using Todoist.Model;
```
<a name="usage"></a>
## Usage

To use the API client with a HTTP proxy, setup a `System.Net.WebProxy`
```csharp
Configuration c = new Configuration();
System.Net.WebProxy webProxy = new System.Net.WebProxy("http://myProxyUrl:80/");
webProxy.Credentials = System.Net.CredentialCache.DefaultCredentials;
c.Proxy = webProxy;
```

### Connections
Each ApiClass (properly the ApiClient inside it) will create an instance of HttpClient. It will use that for the entire lifecycle and dispose it when called the Dispose method.

To better manager the connections it's a common practice to reuse the HttpClient and HttpClientHandler (see [here](https://docs.microsoft.com/en-us/dotnet/architecture/microservices/implement-resilient-applications/use-httpclientfactory-to-implement-resilient-http-requests#issues-with-the-original-httpclient-class-available-in-net) for details). To use your own HttpClient instance just pass it to the ApiClass constructor.

```csharp
HttpClientHandler yourHandler = new HttpClientHandler();
HttpClient yourHttpClient = new HttpClient(yourHandler);
var apiClient = new TodoistClient(yourHttpClient, yourHandler);
```

If you want to use an HttpClient and don't have access to the handler, for example in a DI context in Asp.net Core when using IHttpClientFactory.

```csharp
HttpClient yourHttpClient = new HttpClient();
var apiClient = new TodoistClient(yourHttpClient);
```
You'll loose some configuration settings, the features affected are: Setting and Retrieving Cookies, Client Certificates, Proxy settings. You need to either manually handle those in your setup of the HttpClient or they won't be available.

Here an example of DI setup in a sample web project:

```csharp
services.AddHttpClient<TodoistClient>(httpClient =>
   new TodoistClient(httpClient));
```


<a name="getting-started"></a>
## Getting Started

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using Todoist;
using Todoist.Client;
using Todoist.Model;

namespace Example
{
    public class Example
    {
        public static void Main()
        {

            Configuration config = new Configuration();
            config.BasePath = "https://api.todoist.com/rest/v1";
            // Configure OAuth2 access token for authorization: OAuth
            config.AccessToken = "YOUR_ACCESS_TOKEN";

            // create instances of HttpClient, HttpClientHandler to be reused later with different Api classes
            HttpClient httpClient = new HttpClient();
            HttpClientHandler httpClientHandler = new HttpClientHandler();
            var apiClient = new TodoistClient(httpClient, config, httpClientHandler);
            var xRequestId = xRequestId_example;  // string |  (optional) 
            var newComment = new NewComment(); // NewComment |  (optional) 

            try
            {
                // Create a new comment
                Comment result = apiClient.Comments.CreateComment(xRequestId, newComment);
                Debug.WriteLine(result);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling TodoistClient.Comments.CreateComment: " + e.Message );
                Debug.Print("Status Code: "+ e.ErrorCode);
                Debug.Print(e.StackTrace);
            }

        }
    }
}
```

<a name="documentation-for-api-endpoints"></a>
## Documentation for API Endpoints

All URIs are relative to *https://api.todoist.com/rest/v1*

Class | Method | HTTP request | Description
------------ | ------------- | ------------- | -------------
*CommentsApi* | [**CreateComment**](docs/CommentsApi.md#createcomment) | **POST** /comments | Create a new comment
*CommentsApi* | [**DeleteComment**](docs/CommentsApi.md#deletecomment) | **DELETE** /comments/{commentId} | Delete a comment
*CommentsApi* | [**GetComment**](docs/CommentsApi.md#getcomment) | **GET** /comments/{commentId} | Get a comment
*CommentsApi* | [**GetComments**](docs/CommentsApi.md#getcomments) | **GET** /comments | Get all comments
*CommentsApi* | [**UpdateComment**](docs/CommentsApi.md#updatecomment) | **POST** /comments/{commentId} | Update a comment
*LabelsApi* | [**CreateLabel**](docs/LabelsApi.md#createlabel) | **POST** /labels | Create a new label
*LabelsApi* | [**DeleteLabel**](docs/LabelsApi.md#deletelabel) | **DELETE** /labels/{labelId} | Delete a label
*LabelsApi* | [**GetLabel**](docs/LabelsApi.md#getlabel) | **GET** /labels/{labelId} | Get a label
*LabelsApi* | [**GetLabels**](docs/LabelsApi.md#getlabels) | **GET** /labels | Get all labels
*LabelsApi* | [**UpdateLabel**](docs/LabelsApi.md#updatelabel) | **POST** /labels/{labelId} | Update a label
*ProjectsApi* | [**CreateProject**](docs/ProjectsApi.md#createproject) | **POST** /projects | Create a new project
*ProjectsApi* | [**DeleteProject**](docs/ProjectsApi.md#deleteproject) | **DELETE** /projects/{projectId} | Delete a project
*ProjectsApi* | [**GetCollaborators**](docs/ProjectsApi.md#getcollaborators) | **GET** /projects/{projectId}/collaborators | Get all collaborators
*ProjectsApi* | [**GetProject**](docs/ProjectsApi.md#getproject) | **GET** /projects/{projectId} | Get a project
*ProjectsApi* | [**GetProjects**](docs/ProjectsApi.md#getprojects) | **GET** /projects | Get all projects
*ProjectsApi* | [**UpdateProject**](docs/ProjectsApi.md#updateproject) | **POST** /projects/{projectId} | Update a project
*SectionsApi* | [**CreateSection**](docs/SectionsApi.md#createsection) | **POST** /sections | Create a new section
*SectionsApi* | [**DeleteSection**](docs/SectionsApi.md#deletesection) | **DELETE** /sections/{sectionId} | Delete a section
*SectionsApi* | [**GetSection**](docs/SectionsApi.md#getsection) | **GET** /sections/{sectionId} | Get a single section
*SectionsApi* | [**GetSections**](docs/SectionsApi.md#getsections) | **GET** /sections | Get all sections
*SectionsApi* | [**UpdateSection**](docs/SectionsApi.md#updatesection) | **POST** /sections/{sectionId} | Update a section
*TasksApi* | [**CloseTask**](docs/TasksApi.md#closetask) | **POST** /tasks/{taskId}/close | Close a task
*TasksApi* | [**CreateTask**](docs/TasksApi.md#createtask) | **POST** /tasks | Create a new task
*TasksApi* | [**DeleteTask**](docs/TasksApi.md#deletetask) | **DELETE** /tasks/{taskId} | Delete a task
*TasksApi* | [**GetTask**](docs/TasksApi.md#gettask) | **GET** /tasks/{taskId} | Get an active task
*TasksApi* | [**GetTasks**](docs/TasksApi.md#gettasks) | **GET** /tasks | Get active tasks
*TasksApi* | [**ReopenTask**](docs/TasksApi.md#reopentask) | **POST** /tasks/{taskId}/reopen | Reopen a task
*TasksApi* | [**UpdateTask**](docs/TasksApi.md#updatetask) | **POST** /tasks/{taskId} | Update a task


<a name="documentation-for-models"></a>
## Documentation for Models

 - [Model.Attachment](docs/Attachment.md)
 - [Model.Collaborator](docs/Collaborator.md)
 - [Model.Comment](docs/Comment.md)
 - [Model.CommentUpdate](docs/CommentUpdate.md)
 - [Model.Due](docs/Due.md)
 - [Model.Label](docs/Label.md)
 - [Model.LabelUpdate](docs/LabelUpdate.md)
 - [Model.NewComment](docs/NewComment.md)
 - [Model.NewLabel](docs/NewLabel.md)
 - [Model.NewProject](docs/NewProject.md)
 - [Model.NewSection](docs/NewSection.md)
 - [Model.NewTask](docs/NewTask.md)
 - [Model.Project](docs/Project.md)
 - [Model.ProjectUpdate](docs/ProjectUpdate.md)
 - [Model.Section](docs/Section.md)
 - [Model.SectionUpdate](docs/SectionUpdate.md)
 - [Model.Task](docs/Task.md)
 - [Model.TaskUpdate](docs/TaskUpdate.md)


<a name="documentation-for-authorization"></a>
## Documentation for Authorization

<a name="OAuth"></a>
### OAuth

- **Type**: OAuth
- **Flow**: accessCode
- **Authorization URL**: https://todoist.com/oauth/authorize
- **Scopes**: 
  - task:add: Grants permission to add new tasks (the application cannot read or modify any existing data).
  - data:read: Grants read-only access to application data, including tasks, projects, labels, and filters.
  - data:read_write: Grants read and write access to application data, including tasks, projects, labels, and filters. This scope includes task:add and data:read scopes.
  - data:delete: Grants permission to delete application data, including tasks, labels, and filters.
  - project:delete: Grants permission to delete projects.

