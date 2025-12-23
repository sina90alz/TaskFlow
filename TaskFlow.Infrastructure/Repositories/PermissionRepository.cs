using Microsoft.EntityFrameworkCore;
using TaskFlow.Infrastructure.Data;

public class PermissionRepository : IPermissionRepository
{
    private readonly AppDbContext _db;

    public PermissionRepository(AppDbContext db)
    {
        _db = db;
    }

    public async Task<bool> UserHasPermissionAsync(Guid userId, string permissionCode)
    {
        return await _db.UserPermissions
            .AnyAsync(up =>
                up.UserId == userId &&
                up.Permission.Code == permissionCode);
    }
}
