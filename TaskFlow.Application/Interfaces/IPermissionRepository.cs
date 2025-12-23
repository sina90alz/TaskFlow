public interface IPermissionRepository
{
    Task<bool> UserHasPermissionAsync(Guid userId, string permissionCode);
}
