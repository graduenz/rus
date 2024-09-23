using System.Security.Claims;
using Rus.Base.Application.Interfaces;

namespace Rus.Api;

public class CurrentUserServiceImpl : ICurrentUserService
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public CurrentUserServiceImpl(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public ClaimsPrincipal CurrentUser => _httpContextAccessor.HttpContext?.User ?? throw new InvalidOperationException("Current user is not set.");
    
    public string GetCurrentUserIdentifier()
    {
        // TODO: Remove this when introducing authn
        #if DEBUG
        return "debugging@rdnz.dev";
        #endif
        var claim = CurrentUser.FindFirst("unique_name");
        return claim?.Value ?? throw new InvalidOperationException("Missing unique_name claim in token.");
    }
}