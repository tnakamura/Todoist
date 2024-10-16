using System;
using System.Text.Json.Serialization;

namespace Todoist.Models;

/// <summary>
/// Section
/// </summary>
public partial class Section : IEquatable<Section>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Section" /> class.
    /// </summary>
    /// <param name="id">
    /// Section id
    /// </param>
    /// <param name="projectId">
    /// Section position among other sections from the same project
    /// </param>
    /// <param name="order">
    /// Section position among other sections
    /// </param>
    /// <param name="name">
    /// Section name
    /// </param>
    [JsonConstructor]
    public Section(
        string id,
        string projectId,
        int order,
        string name)
    {
        Id = id;
        ProjectId = projectId;
        Order = order;
        Name = name;
    }

    /// <summary>
    /// Section id
    /// </summary>
    [JsonPropertyName("id")]
    public string Id { get; private set; }

    /// <summary>
    /// Section position among other sections from the same project
    /// </summary>
    [JsonPropertyName("project_id")]
    public string ProjectId { get; private set; }

    /// <summary>
    /// Section position among other sections
    /// </summary>
    [JsonPropertyName("order")]
    public int Order { get; private set; }

    /// <summary>
    /// Section name
    /// </summary>
    [JsonPropertyName("name")]
    public string Name { get; private set; }

    /// <inheritdoc/>
    public override bool Equals(object input)
    {
        return Equals(input as Section);
    }

    /// <inheritdoc/>
    public bool Equals(Section? input)
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
                this.ProjectId == input.ProjectId ||
                this.ProjectId.Equals(input.ProjectId)
            ) &&
            (
                this.Order == input.Order ||
                this.Order.Equals(input.Order)
            ) &&
            (
                this.Name == input.Name ||
                (this.Name != null &&
                this.Name.Equals(input.Name))
            );
    }

    /// <inheritdoc/>
    public override int GetHashCode()
    {
        unchecked // Overflow is fine, just wrap
        {
            int hashCode = 41;
            hashCode = (hashCode * 59) + this.Id.GetHashCode();
            hashCode = (hashCode * 59) + this.ProjectId.GetHashCode();
            hashCode = (hashCode * 59) + this.Order.GetHashCode();
            if (this.Name != null)
            {
                hashCode = (hashCode * 59) + this.Name.GetHashCode();
            }
            return hashCode;
        }
    }
}
