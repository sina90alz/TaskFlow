public class UserPermission
{
    public Guid UserId { get; set; }
    public Guid PermissionId { get; set; }

    public Permission Permission { get; set; } = null!;
}
