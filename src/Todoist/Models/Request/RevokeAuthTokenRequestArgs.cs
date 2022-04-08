namespace Todoist.Models
{
    public class RevokeAuthTokenRequestArgs
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RevokeAuthTokenRequestArgs" /> class.
        /// </summary>
        public RevokeAuthTokenRequestArgs(
            string clientId,
            string clientSecret,
            string accessToken)
        {
            ClientId = clientId;
            ClientSecret = clientSecret;
            AccessToken = accessToken;
        }

        /// <summary>
        /// Gets Client ID
        /// </summary>
        public string ClientId { get; }

        /// <summary>
        /// Gets Client Secret
        /// </summary>
        public string ClientSecret { get; }

        /// <summary>
        /// Gets Access Token
        /// </summary>
        public string AccessToken { get; }
    }
}
