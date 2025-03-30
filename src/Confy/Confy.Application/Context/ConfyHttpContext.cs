using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace Confy.Application.Context;
public class ConfyHttpContext(IHttpContextAccessor httpContextAccessor)
	: IContext
{
	public Guid UserId =>
		Guid.TryParse(httpContextAccessor.HttpContext?.User.FindFirst(ClaimTypes.NameIdentifier)?.Value, out var id) ? id : UserConsts.UnAuthenticatedUserId;

	public string Role =>
		httpContextAccessor.HttpContext?.User.FindFirst(ClaimTypes.Role)?.Value ?? UserConsts.UnauthenticatedRole;
}
