namespace Todoist.Models
{
    public sealed class AuthTokenRequestArgs
    {
        public AuthTokenRequestArgs(
            string clientId,
            string clientSecret,
            string code)
        {
            ClientId = clientId;
            ClientSecret = clientSecret;
            Code = code;
        }

        public string ClientId { get; }

        public string ClientSecret { get; }

        public string Code { get; }
    }
}
