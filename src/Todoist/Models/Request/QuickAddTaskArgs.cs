namespace Todoist.Models
{
    public sealed class QuickAddTaskArgs
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="QuickAddTaskArgs" /> class.
        /// </summary>
        public QuickAddTaskArgs(
            string text,
            string note = null,
            string reminder = null,
            bool? autoReminder = null)
        {
            Text = text;
            Note = note;
            Reminder = reminder;
            AutoReminder = autoReminder;
        }

        /// <summary>
        /// Gets Text
        /// </summary>
        public string Text { get; private set; }

        /// <summary>
        /// Gets or Sets Note
        /// </summary>
        public string Note { get; set; }

        /// <summary>
        /// Gets or Sets Reminder
        /// </summary>
        public string Reminder { get; set; }

        /// <summary>
        /// Gets or Sets AutoReminder
        /// </summary>
        public bool? AutoReminder { get; set; }
    }
}
