using MediatR;
using TaskFlow.Application.Common.Exceptions;

public class AuthorizationBehavior<TRequest, TResponse>
    : IPipelineBehavior<TRequest, TResponse>
{
    private readonly IPermissionService _permissionService;
    private readonly ICurrentUserService _currentUser;

    public AuthorizationBehavior(
        IPermissionService permissionService,
        ICurrentUserService currentUser)
    {
        _permissionService = permissionService;
        _currentUser = currentUser;
    }

    public async Task<TResponse> Handle(
        TRequest request,
        RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {
        if (request is not IRequirePermission securedRequest)
            return await next();

        var userId = _currentUser.UserId;

        var allowed = await _permissionService
            .HasPermissionAsync(userId, securedRequest.Permission);

        if (!allowed)
            throw new ForbiddenAccessException();

        return await next();
    }
}
