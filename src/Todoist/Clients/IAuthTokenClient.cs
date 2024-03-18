using System.Threading;
using System.Threading.Tasks;
using Todoist.Models;

namespace Todoist.Clients
{
    /// <summary>
    /// AuthToken
    /// </summary>
    public interface IAuthTokenClient
    {
        /// <summary>
        /// Token exchange.
        /// </summary>
        ValueTask<AuthTokenResponse> GetAsync(
            AuthTokenRequestArgs args,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Revoke token.
        /// </summary>
        ValueTask<bool> RevokeAsync(
            RevokeAuthTokenRequestArgs args,
            CancellationToken cancellationToken = default);
    }
}
