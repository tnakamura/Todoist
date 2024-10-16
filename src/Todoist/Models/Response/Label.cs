using System;
using System.Text.Json.Serialization;

namespace Todoist.Models;

/// <summary>
/// Label
/// </summary>
public partial class Label : IEquatable<Label>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Label" /> class.
    /// </summary>
    /// <param name="id">
    /// Label ID.
    /// </param>
    /// <param name="name">
    /// Label name.
    /// </param>
    /// <param name="color">
    /// The color of the label icon.
    /// Refer to the name column in the Colors guide for more info.
    /// </param>
    /// <param name="order">
    /// Number used by clients to sort list of labels.
    /// </param>
    /// <param name="isFavorite">
    /// Whether the label is a favorite (a true or false value).
    /// </param>
    [JsonConstructor]
    public Label(
        string id,
        string name,
        string color,
        int order,
        bool isFavorite)
    {
        Id = id;
        Name = name;
        Color = color;
        Order = order;
        IsFavorite = isFavorite;
    }

    /// <summary>
    /// Label ID.
    /// </summary>
    [JsonPropertyName("id")]
    public string Id { get; private set; }

    /// <summary>
    /// Label name.
    /// </summary>
    [JsonPropertyName("name")]
    public string Name { get; private set; }

    /// <summary>
    /// The color of the label icon.
    /// Refer to the name column in the Colors guide for more info.
    /// </summary>
    [JsonPropertyName("color")]
    public string Color { get; private set; }

    /// <summary>
    /// Number used by clients to sort list of labels.
    /// </summary>
    [JsonPropertyName("order")]
    public int Order { get; private set; }

    /// <summary>
    /// Whether the label is a favorite (a true or false value).
    /// </summary>
    [JsonPropertyName("is_favorite")]
    public bool IsFavorite { get; private set; }

    /// <inheritdoc/>
    public override bool Equals(object input)
    {
        return Equals(input as Label);
    }

    /// <inheritdoc/>
    public bool Equals(Label? input)
    {
        if (input == null)
        {
            return false;
        }
        return
            (
                this.Id == input.Id ||
                this.Id.Equals(input.Id)
            ) &&
            (
                this.Name == input.Name ||
                (this.Name != null &&
                this.Name.Equals(input.Name))
            ) &&
            (
                this.Color == input.Color ||
                this.Color.Equals(input.Color)
            ) &&
            (
                this.Order == input.Order ||
                this.Order.Equals(input.Order)
            ) &&
            (
                this.IsFavorite == input.IsFavorite ||
                this.IsFavorite.Equals(input.IsFavorite)
            );
    }

    /// <inheritdoc/>
    public override int GetHashCode()
    {
        unchecked // Overflow is fine, just wrap
        {
            int hashCode = 41;
            hashCode = (hashCode * 59) + this.Id.GetHashCode();
            if (this.Name != null)
            {
                hashCode = (hashCode * 59) + this.Name.GetHashCode();
            }
            hashCode = (hashCode * 59) + this.Color.GetHashCode();
            hashCode = (hashCode * 59) + this.Order.GetHashCode();
            hashCode = (hashCode * 59) + this.IsFavorite.GetHashCode();
            return hashCode;
        }
    }
}
