using System;

namespace Todoist
{
    /// <summary></summary>
    public class TodoistException : Exception
    {
        public TodoistException(string message)
            : base(message)
        {
        }

        public TodoistException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
