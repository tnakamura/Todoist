using System;
using System.Collections.Generic;
using System.Linq;
using Todoist.Models;
using static Todoist.Constants.Endpoints;

namespace Todoist;

public static class Authentication
{
    public static string GetAuthStateParameter() =>
        Guid.NewGuid().ToString("N");

    public static string GetAuthorizationUrl(
        string clientId,
        IEnumerable<Permission> permissions,
        string state)
    {
        var scope = string.Join(",", permissions.Select(x => x.ToScope()));
        return $"{API_AUTHORIZATION_BASE_URI}{ENDPOINT_AUTHORIZATION}?client_id={clientId}&scope={scope}&state={state}";
    }

    private static string ToScope(this Permission permission)
    {
        switch (permission)
        {
            case Permission.TaskAdd:
                return "task:add";
            case Permission.ProjectDelete:
                return "project:delete";
            case Permission.DataDelete:
                return "data:delete";
            case Permission.DataRead:
                return "data:read";
            case Permission.DataReadWrite:
                return "data:read_write";
            default:
                throw new ArgumentOutOfRangeException(nameof(permission));
        }
    }
}
