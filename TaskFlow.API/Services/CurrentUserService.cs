using System.Security.Claims;

public class CurrentUserService : ICurrentUserService
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public CurrentUserService(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public bool IsAuthenticated =>
        _httpContextAccessor.HttpContext?.User?.Identity?.IsAuthenticated ?? false;

    public Guid UserId
    {
        get
        {
            var userIdClaim = _httpContextAccessor.HttpContext?
                .User?
                .FindFirstValue("id");

            if (string.IsNullOrWhiteSpace(userIdClaim))
                throw new UnauthorizedAccessException("UserId claim is missing");

            return Guid.Parse(userIdClaim);
        }
    }
}
