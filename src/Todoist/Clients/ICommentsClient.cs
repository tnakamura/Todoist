﻿using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Todoist.Models;

namespace Todoist.Clients;

/// <summary>
/// Comments
/// </summary>
public interface ICommentsClient
{
    /// <summary>
    /// Get all comments
    /// </summary>
    ValueTask<IReadOnlyList<Comment>> GetAllAsync(GetCommentsArgs args, CancellationToken cancellationToken = default);
    /// <summary>
    /// Get a comment
    /// </summary>
    ValueTask<Comment> GetAsync(string id, CancellationToken cancellationToken = default);
    /// <summary>
    /// Create a new comment
    /// </summary>
    ValueTask<Comment> CreateAsync(CreateCommentArgs args, string? requestId = null, CancellationToken cancellationToken = default);
    /// <summary>
    /// Update a comment
    /// </summary>
    ValueTask<Comment> UpdateAsync(string id, UpdateCommentArgs args, string? requestId = null, CancellationToken cancellationToken = default);
    /// <summary>
    /// Delete a comment
    /// </summary>
    ValueTask<bool> DeleteAsync(string id, string? requestId = null, CancellationToken cancellationToken = default);
}
