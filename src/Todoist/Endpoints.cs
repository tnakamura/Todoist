namespace Todoist;

internal static class Endpoints
{
    const string BASE_URI = "https://api.todoist.com";
    const string API_REST_BASE_URI = "/rest/v2/";
    const string API_SYNC_BASE_URI = "/sync/v8/";
    const string TODOIST_URI = "https://todoist.com";
    const string API_AUTHORIZATION_BASE_URI = "/oauth/";

    public static string GetRestBaseUri(string domainBase = BASE_URI)
    {
        return domainBase + API_REST_BASE_URI;
    }

    public static string GetSyncBaseUri(string domainBase = BASE_URI)
    {
        return domainBase + API_SYNC_BASE_URI;
    }

    public static string GetAuthBaseUri(string domainBase = TODOIST_URI)
    {
        return domainBase + API_AUTHORIZATION_BASE_URI;
    }

    public const string ENDPOINT_REST_TASKS = "tasks";
    public const string ENDPOINT_REST_PROJECTS = "projects";
    public const string ENDPOINT_REST_SECTIONS = "sections";
    public const string ENDPOINT_REST_LABELS = "labels";
    public const string ENDPOINT_REST_LABELS_SHARED = ENDPOINT_REST_LABELS + "/shared";
    public const string ENDPOINT_REST_LABELS_SHARED_RENAME = ENDPOINT_REST_LABELS_SHARED + "/rename";
    public const string ENDPOINT_REST_LABELS_SHARED_REMOVE = ENDPOINT_REST_LABELS_SHARED + "/remove";
    public const string ENDPOINT_REST_COMMENTS = "comments";
    public const string ENDPOINT_REST_TASK_CLOSE = "close";
    public const string ENDPOINT_REST_TASK_REOPEN = "reopen";
    public const string ENDPOINT_REST_PROJECT_COLLABORATORS = "collaborators";


    public const string ENDPOINT_SYNC_QUICK_ADD = "quick/add";

    public const string ENDPOINT_AUTHORIZATION = "authorize";
    public const string ENDPOINT_GET_TOKEN = "access_token";
    public const string ENDPOINT_REVOKE_TOKEN = "access_tokens/revoke";
}
