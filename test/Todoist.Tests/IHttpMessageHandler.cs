using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Todoist.Test
{
    public interface IHttpMessageHandler
    {
        Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken);
    }
}
