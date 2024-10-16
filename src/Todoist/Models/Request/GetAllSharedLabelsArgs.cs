using System.Text.Json.Serialization;

namespace Todoist.Models;

public class GetAllSharedLabelsArgs
{
    /// <summary>
    /// Whether to exclude the names of the user's personal labels from the results.
    /// The default value is false.
    /// </summary>
    [JsonPropertyName("omit_personal")]
    public bool? OmitPersonal { get; set; }
}
