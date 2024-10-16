using System.Text.Json.Serialization;

namespace Todoist.Models;

/// <summary>
/// Shared Labels Remove
/// </summary>
public class RemoveSharedLabelsArgs
{
    /// <summary>
    /// Initializes a new instance of the <see cref="RemoveSharedLabelsArgs" /> class.
    /// </summary>
    public RemoveSharedLabelsArgs(string name)
    {
        Name = name;
    }

    /// <summary>
    /// The name of the existing label to rename.
    /// </summary>
    [JsonPropertyName("name")]
    public string Name { get; set; }
}
