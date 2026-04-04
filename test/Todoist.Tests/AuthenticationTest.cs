using System.Collections.Generic;
using Todoist.Models;
using Xunit;

namespace Todoist.Test;

public class AuthenticationTest
{
    [Fact]
    public void GetAuthorizationUrl_IncludesExtendedScopes()
    {
        var url = Authentication.GetAuthorizationUrl(
            clientId: "cid",
            permissions: new List<Permission>
            {
                Permission.TaskAdd,
                Permission.TaskDelete,
                Permission.NoteAdd,
                Permission.NoteDelete,
                Permission.ReminderRead,
                Permission.ReminderWrite,
            },
            state: "state1");

        Assert.Contains("scope=task:add,task:delete,note:add,note:delete,reminder:read,reminder:write", url);
        Assert.Contains("client_id=cid", url);
        Assert.Contains("state=state1", url);
    }
}
