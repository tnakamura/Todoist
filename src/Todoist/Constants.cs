namespace Todoist;

internal static class Constants
{
    internal static class Endpoints
    {
        public const string API_REST_BASE_URI = "https://api.todoist.com/rest/v2/";
        public const string API_SYNC_BASE_URI = "https://api.todoist.com/sync/v8/";
        public const string API_AUTHORIZATION_BASE_URI = "https://todoist.com/oauth/";

        public const string ENDPOINT_REST_TASKS = "tasks";
        public const string ENDPOINT_REST_PROJECTS = "projects";
        public const string ENDPOINT_REST_SECTIONS = "sections";
        public const string ENDPOINT_REST_LABELS = "labels";
        public const string ENDPOINT_REST_COMMENTS = "comments";
        public const string ENDPOINT_REST_TASK_CLOSE = "close";
        public const string ENDPOINT_REST_TASK_REOPEN = "reopen";
        public const string ENDPOINT_REST_PROJECT_COLLABORATORS = "collaborators";

        public const string ENDPOINT_REST_SHARED_LABELS = "shared";
        public const string ENDPOINT_REST_RENAME_SHARED_LABELS = "rename";
        public const string ENDPOINT_REST_REMOVE_SHARED_LABELS = "remove";

        public const string ENDPOINT_SYNC_QUICK_ADD = "quick/add";

        public const string ENDPOINT_AUTHORIZATION = "authorize";
        public const string ENDPOINT_GET_TOKEN = "access_token";
        public const string ENDPOINT_REVOKE_TOKEN = "access_tokens/revoke";
    }
}
