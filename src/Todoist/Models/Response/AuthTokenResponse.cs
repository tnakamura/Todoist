﻿using System.Text.Json.Serialization;

namespace Todoist.Models;

/// <summary>
/// Access Token
/// </summary>
public class AuthTokenResponse
{
    /// <summary>
    /// Initializes a new instance of the <see cref="AuthTokenResponse" /> class.
    /// </summary>
    [JsonConstructor]
    public AuthTokenResponse(
        string accessToken,
        string tokenType)
    {
        AccessToken = accessToken;
        TokenType = tokenType;
    }

    /// <summary>
    /// Gets Access Token
    /// </summary>
    [JsonPropertyName("access_token")]
    public string AccessToken { get; private set; }

    /// <summary>
    /// Gets Token Type
    /// </summary>
    [JsonPropertyName("token_type")]
    public string TokenType { get; private set; }
}
