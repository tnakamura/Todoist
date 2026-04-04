using System.Text.Json.Serialization;

namespace Todoist.Models;

public class GetAllSharedLabelsArgs
{
    /// <summary>
    /// Pagination cursor returned by previous page.
    /// </summary>
    [JsonPropertyName("cursor")]
    public string? Cursor { get; set; }

    /// <summary>
    /// Whether to exclude the names of the user's personal labels from the results.
    /// The default value is false.
    /// </summary>
    [JsonPropertyName("omit_personal")]
    public bool? OmitPersonal { get; set; }
}
