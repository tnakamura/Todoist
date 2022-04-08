using System.Collections.Generic;

namespace Todoist.Models
{
    public sealed class GetTasksArgs
    {
        /// <summary>
        /// Gets or Sets ProjectId
        /// </summary>
        public long? ProjectId { get; set; }

        /// <summary>
        /// Gets or Sets SectionId
        /// </summary>
        public long? SectionId { get; set; }

        /// <summary>
        /// Gets or Sets LabelId
        /// </summary>
        public long? LabelId { get; set; }

        /// <summary>
        /// Gets or Sets Filter
        /// </summary>
        public string Filter { get; set; }

        /// <summary>
        /// Gets or Sets Lang
        /// </summary>
        public string Lang { get; set; }

        /// <summary>
        /// Gets or Sets Ids
        /// </summary>
        public IList<long> Ids { get; set; }
    }
}
