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
    /// <param name="id">id.</param>
    /// <param name="name">name.</param>
    /// <param name="color">color.</param>
    /// <param name="order">order.</param>
    /// <param name="favorite">favorite.</param>
    [JsonConstructor]
    public Label(
        long id = default,
        string? name = default,
        int color = default,
        int order = default,
        bool favorite = default)
    {
        Id = id;
        Name = name;
        Color = color;
        Order = order;
        Favorite = favorite;
    }

    /// <summary>
    /// Gets Id
    /// </summary>
    [JsonPropertyName("id")]
    public long Id { get; private set; }

    /// <summary>
    /// Gets Name
    /// </summary>
    [JsonPropertyName("name")]
    public string? Name { get; private set; }

    /// <summary>
    /// Gets Color
    /// </summary>
    [JsonPropertyName("color")]
    public int Color { get; private set; }

    /// <summary>
    /// Gets Order
    /// </summary>
    [JsonPropertyName("order")]
    public int Order { get; private set; }

    /// <summary>
    /// Gets Favorite
    /// </summary>
    [JsonPropertyName("favorite")]
    public bool Favorite { get; private set; }

    /// <summary>
    /// Returns true if objects are equal
    /// </summary>
    /// <param name="input">Object to be compared</param>
    /// <returns>Boolean</returns>
    public override bool Equals(object input)
    {
        return Equals(input as Label);
    }

    /// <summary>
    /// Returns true if Label instances are equal
    /// </summary>
    /// <param name="input">Instance of Label to be compared</param>
    /// <returns>Boolean</returns>
    public bool Equals(Label input)
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
                this.Favorite == input.Favorite ||
                this.Favorite.Equals(input.Favorite)
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
            hashCode = (hashCode * 59) + this.Id.GetHashCode();
            if (this.Name != null)
            {
                hashCode = (hashCode * 59) + this.Name.GetHashCode();
            }
            hashCode = (hashCode * 59) + this.Color.GetHashCode();
            hashCode = (hashCode * 59) + this.Order.GetHashCode();
            hashCode = (hashCode * 59) + this.Favorite.GetHashCode();
            return hashCode;
        }
    }
}
