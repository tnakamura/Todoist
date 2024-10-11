using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Todoist.Test;

public class MockHttpMessageHandler : HttpMessageHandler
{
    public MockHttpMessageHandler() : base()
    {
    }

    public Func<HttpRequestMessage, CancellationToken, Task<HttpResponseMessage>>? SendDelegate { get; set; }

    protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        if (SendDelegate is not null)
        {
            return SendDelegate(request, cancellationToken);
        }
        else
        {
            return Task.FromResult(MockSend(request, cancellationToken));
        }
    }

    protected override HttpResponseMessage Send(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        if (SendDelegate is not null)
        {
            return SendDelegate(request, cancellationToken).GetAwaiter().GetResult();
        }
        else
        {
            return MockSend(request, cancellationToken);
        }
    }

    public virtual HttpResponseMessage MockSend(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
