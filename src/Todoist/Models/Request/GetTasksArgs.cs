﻿using System.Collections.Generic;

namespace Todoist.Models;

public sealed class GetTasksArgs
{
    /// <summary>
    /// Filter tasks by project ID.
    /// </summary>
    public string? ProjectId { get; set; }

    /// <summary>
    /// Filter tasks by section ID.
    /// </summary>
    public string? SectionId { get; set; }

    /// <summary>
    /// Filter tasks by label name.
    /// </summary>
    public string? LabelId { get; set; }

    /// <summary>
    /// Filter by any supported filter.
    /// Multiple filters (using the comma , operator) are not supported.
    /// </summary>
    public string? Filter { get; set; }

    /// <summary>
    /// IETF language tag defining what language filter is written in,
    /// if differs from default English.
    /// </summary>
    public string? Lang { get; set; }

    /// <summary>
    /// A list of the task IDs to retrieve,
    /// this should be a comma separated list.
    /// </summary>
    public IList<string>? Ids { get; set; }
}
