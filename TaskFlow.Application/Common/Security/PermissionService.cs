public class PermissionService : IPermissionService
{
    private readonly IPermissionRepository _repository;

    public PermissionService(IPermissionRepository repository)
    {
        _repository = repository;
    }

    public async Task<bool> HasPermissionAsync(Guid userId, string permission)
    {
        // Future-proof place:
        // - caching
        // - role expansion
        // - super-admin bypass
        // - feature flags

        return await _repository.UserHasPermissionAsync(userId, permission);
    }
}
