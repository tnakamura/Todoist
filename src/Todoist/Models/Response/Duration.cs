using System.Text.Json.Serialization;

namespace Todoist.Models;

public class Duration
{
    [JsonConstructor]
    public Duration(int amount, string unit)
    {
        Amount = amount;
        Unit = unit;
    }

    [JsonPropertyName("amount")]
    public int Amount { get; private set; }

    [JsonPropertyName("unit")]
    public string Unit { get; private set; }
}
