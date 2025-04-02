using Confy.Application.Common;
using Confy.Application.DTO.Notifications.BrowseMyNotifications;
using Confy.Application.Queries.Notifications.BrowseMyNotifications;
using Microsoft.AspNetCore.Authorization;

namespace Confy.API.Controllers;

[Authorize]
[Route("notifications")]
[ApiController]
public class NotificationController(IMediator mediator)
	: ControllerBase
{
	[HttpGet]
	public async Task<ActionResult<PaginationResult<NotificationDto>>> BrowseMyNotifications([FromQuery] PaginationRequest request)
	{
		var query = new BrowseMyNotificationsQuery(request);

		var result = await mediator.Send(query);

		return Ok(result);
	}
}
