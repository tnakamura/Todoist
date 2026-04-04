namespace Todoist.Models;

/// <summary>
/// Permission
/// </summary>
public enum Permission
{
    /// <summary>
    /// task:add
    /// </summary>
    TaskAdd,

    /// <summary>
    /// data:read
    /// </summary>
    DataRead,

    /// <summary>
    /// data:read_write
    /// </summary>
    DataReadWrite,

    /// <summary>
    /// data:delete
    /// </summary>
    DataDelete,

    /// <summary>
    /// project:delete
    /// </summary>
    ProjectDelete,

    /// <summary>
    /// task:delete
    /// </summary>
    TaskDelete,

    /// <summary>
    /// note:add
    /// </summary>
    NoteAdd,

    /// <summary>
    /// note:delete
    /// </summary>
    NoteDelete,

    /// <summary>
    /// reminder:read
    /// </summary>
    ReminderRead,

    /// <summary>
    /// reminder:write
    /// </summary>
    ReminderWrite,
}
