using System;
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

        Assert.Contains("scope=task%3Aadd%2Ctask%3Adelete%2Cnote%3Aadd%2Cnote%3Adelete%2Creminder%3Aread%2Creminder%3Awrite", Uri.EscapeDataString(url));
        Assert.Contains("client_id=cid", url);
        Assert.Contains("state=state1", url);
    }
}
