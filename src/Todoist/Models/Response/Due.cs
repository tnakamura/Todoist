using System;
using System.Text.Json.Serialization;

namespace Todoist.Models;

/// <summary>
/// Due
/// </summary>
public partial class Due : IEquatable<Due>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Due" /> class.
    /// </summary>
    [JsonConstructor]
    public Due(
        string @string,
        DateTimeOffset date,
        bool isRecurring,
        DateTimeOffset? datetime,
        string? timezone)
    {
        String = @string;
        Date = date;
        IsRecurring = isRecurring;
        DateTime = datetime;
        TimeZone = timezone;
    }

    /// <summary>
    /// Human defined date in arbitrary format.
    /// </summary>
    [JsonPropertyName("string")]
    public string String { get; private set; }

    /// <summary>
    /// Date in format YYYY-MM-DD corrected to user's timezone.
    /// </summary>
    [JsonPropertyName("date")]
    public DateTimeOffset Date { get; private set; }

    /// <summary>
    /// Whether the task has a recurring due date.
    /// </summary>
    [JsonPropertyName("is_recurring")]
    public bool IsRecurring { get; private set; }

    /// <summary>
    /// Only returned if exact due time set (i.e. it's not a whole-day task),
    /// date and time in RFC3339 format in UTC.
    /// </summary>
    [JsonPropertyName("datetime")]
    public DateTimeOffset? DateTime { get; private set; }

    /// <summary>
    /// Only returned if exact due time set,
    /// user's timezone definition either in tzdata-compatible format ("Europe/Berlin")
    /// or as a string specifying east of UTC offset as "UTCÅ}HH:MM" (i.e. "UTC-01:00").
    /// </summary>
    [JsonPropertyName("timezone")]
    public string? TimeZone { get; private set; }

    /// <inheritdoc/>
    public override bool Equals(object input)
    {
        return Equals(input as Due);
    }

    /// <inheritdoc/>
    public bool Equals(Due? input)
    {
        if (input is null)
        {
            return false;
        }
        return
            (
                this.String == input.String ||
                (this.String != null &&
                this.String.Equals(input.String))
            ) &&
            (
                this.Date == input.Date ||
                (this.Date != null &&
                this.Date.Equals(input.Date))
            ) &&
            (
                this.IsRecurring == input.IsRecurring ||
                this.IsRecurring.Equals(input.IsRecurring)
            ) &&
            (
                this.DateTime == input.DateTime ||
                (this.DateTime != null &&
                this.DateTime.Equals(input.DateTime))
            ) &&
            (
                this.TimeZone == input.TimeZone ||
                (this.TimeZone != null &&
                this.TimeZone.Equals(input.TimeZone))
            );
    }

    /// <inheritdoc/>
    public override int GetHashCode()
    {
        unchecked // Overflow is fine, just wrap
        {
            int hashCode = 41;
            if (this.String != null)
            {
                hashCode = (hashCode * 59) + this.String.GetHashCode();
            }
            if (this.Date != null)
            {
                hashCode = (hashCode * 59) + this.Date.GetHashCode();
            }
            hashCode = (hashCode * 59) + this.IsRecurring.GetHashCode();
            if (this.DateTime != null)
            {
                hashCode = (hashCode * 59) + this.DateTime.GetHashCode();
            }
            if (this.TimeZone != null)
            {
                hashCode = (hashCode * 59) + this.TimeZone.GetHashCode();
            }
            return hashCode;
        }
    }
}
