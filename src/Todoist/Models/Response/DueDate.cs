using System;
using System.Text.Json.Serialization;

namespace Todoist.Models;

/// <summary>
/// Due
/// </summary>
public partial class DueDate : IEquatable<DueDate>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="DueDate" /> class.
    /// </summary>
    [JsonConstructor]
    protected DueDate() { }

    /// <summary>
    /// Initializes a new instance of the <see cref="DueDate" /> class.
    /// </summary>
    /// <param name="string">_string (required).</param>
    /// <param name="date">date (required).</param>
    /// <param name="recurring">recurring (required).</param>
    /// <param name="datetime">datetime.</param>
    /// <param name="timezone">timezone.</param>
    public DueDate(
        string? @string = default,
        DateTimeOffset date = default,
        bool recurring = default,
        DateTimeOffset datetime = default,
        string? timezone = default)
    {
        if (@string == null)
        {
            throw new ArgumentNullException(nameof(@string));
        }
        String = @string;
        Date = date;
        Recurring = recurring;
        Datetime = datetime;
        Timezone = timezone;
    }

    /// <summary>
    /// Gets String
    /// </summary>
    [JsonPropertyName("string")]
    public string? String { get; private set; }

    /// <summary>
    /// Gets Date
    /// </summary>
    [JsonPropertyName("date")]
    public DateTimeOffset Date { get; private set; }

    /// <summary>
    /// Gets Recurring
    /// </summary>
    [JsonPropertyName("recurring")]
    public bool Recurring { get; private set; }

    /// <summary>
    /// Gets Datetime
    /// </summary>
    [JsonPropertyName("datetime")]
    public DateTimeOffset Datetime { get; private set; }

    /// <summary>
    /// Gets Timezone
    /// </summary>
    [JsonPropertyName("timezone")]
    public string? Timezone { get; private set; }

    /// <summary>
    /// Returns true if objects are equal
    /// </summary>
    /// <param name="input">Object to be compared</param>
    /// <returns>Boolean</returns>
    public override bool Equals(object input)
    {
        return Equals(input as DueDate);
    }

    /// <summary>
    /// Returns true if Due instances are equal
    /// </summary>
    /// <param name="input">Instance of Due to be compared</param>
    /// <returns>Boolean</returns>
    public bool Equals(DueDate? input)
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
                this.Recurring == input.Recurring ||
                this.Recurring.Equals(input.Recurring)
            ) &&
            (
                this.Datetime == input.Datetime ||
                (this.Datetime != null &&
                this.Datetime.Equals(input.Datetime))
            ) &&
            (
                this.Timezone == input.Timezone ||
                (this.Timezone != null &&
                this.Timezone.Equals(input.Timezone))
            );
    }

    /// <summary>
    /// Gets the hash code
    /// </summary>
    /// <returns>Hash code</returns>
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
            hashCode = (hashCode * 59) + this.Recurring.GetHashCode();
            if (this.Datetime != null)
            {
                hashCode = (hashCode * 59) + this.Datetime.GetHashCode();
            }
            if (this.Timezone != null)
            {
                hashCode = (hashCode * 59) + this.Timezone.GetHashCode();
            }
            return hashCode;
        }
    }
}
