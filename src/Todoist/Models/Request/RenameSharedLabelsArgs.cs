using System.Text.Json.Serialization;

namespace Todoist.Models;

/// <summary>
/// Shared Labels Rename
/// </summary>
public class RenameSharedLabelsArgs
{
    /// <summary>
    /// Initializes a new instance of the <see cref="RenameSharedLabelsArgs" /> class.
    /// </summary>
    public RenameSharedLabelsArgs(string name, string newName)
    {
        Name = name;
        NewName = newName;
    }

    /// <summary>
    /// The name of the existing label to rename.
    /// </summary>
    [JsonPropertyName("name")]
    public string Name { get; set; }

    /// <summary>
    /// The new name for the label.
    /// </summary>
    [JsonPropertyName("new_name")]
    public string NewName { get; set; }
}
