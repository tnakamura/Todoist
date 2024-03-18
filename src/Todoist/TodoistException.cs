using System;

namespace Todoist
{
    /// <summary></summary>
    public class TodoistException : Exception
    {
        /// <summary></summary>
        public TodoistException(string message)
            : base(message)
        {
        }

        /// <summary></summary>
        public TodoistException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
