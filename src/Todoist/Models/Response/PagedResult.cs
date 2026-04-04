using System.Collections.Generic;

namespace Todoist.Models;

/// <summary>
/// Represents a single paged response and cursor for the next page.
/// </summary>
/// <typeparam name="TItem">Item type.</typeparam>
public sealed class PagedResult<TItem>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="PagedResult{TItem}" /> class.
    /// </summary>
    public PagedResult(IReadOnlyList<TItem> items, string? nextCursor)
    {
        Items = items;
        NextCursor = nextCursor;
    }

    /// <summary>
    /// Page items.
    /// </summary>
    public IReadOnlyList<TItem> Items { get; private set; }

    /// <summary>
    /// Cursor for next page.
    /// </summary>
    public string? NextCursor { get; private set; }
}
