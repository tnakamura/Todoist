using System;
using System.Net;

namespace Todoist;

/// <summary></summary>
public class TodoistException : Exception
{
    /// <summary>
    /// HTTP status code when available.
    /// </summary>
    public HttpStatusCode? StatusCode { get; }

    /// <summary></summary>
    public TodoistException(string message)
        : base(message)
    {
    }

    /// <summary></summary>
    public TodoistException(string message, HttpStatusCode statusCode)
        : base(message)
    {
        StatusCode = statusCode;
    }

    /// <summary></summary>
    public TodoistException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}
