using System.Text.Json.Serialization;

namespace Todoist.Models;

/// <summary>
/// User
/// </summary>
public partial class User
{
    /// <summary>
    /// Initializes a new instance of the <see cref="User" /> class.
    /// </summary>
    /// <param name="id">id (required).</param>
    /// <param name="name">name.</param>
    /// <param name="email">email.</param>
    [JsonConstructor]
    public User(
        string id,
        string name,
        string email)
    {
        Id = id;
        Name = name;
        Email = email;
    }

    /// <summary>
    /// Gets Id
    /// </summary>
    [JsonPropertyName("id")]
    public string Id { get; private set; }

    /// <summary>
    /// Gets Name
    /// </summary>
    [JsonPropertyName("name")]
    public string Name { get; private set; }

    /// <summary>
    /// Gets Email
    /// </summary>
    [JsonPropertyName("email")]
    public string Email { get; private set; }
}
