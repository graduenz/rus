using System.Security.Claims;

namespace Rus.Base.Application.Interfaces;

public interface ICurrentUserService
{
    ClaimsPrincipal CurrentUser { get; }

    string GetCurrentUserIdentifier();
}