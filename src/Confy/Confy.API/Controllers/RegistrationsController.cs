using Confy.Application.Commands.Registrations.AddRegistration;
using Microsoft.AspNetCore.Authorization;

namespace Confy.API.Controllers;

[Authorize]
[Route("registrations")]
[ApiController]
public class RegistrationsController(IMediator mediator)
	: ControllerBase
{
	[HttpPost]
	public async Task<ActionResult> AddRegistration([FromBody] AddRegistrationDto dto)
	{
		var command = new AddRegistrationCommand(dto.ConferenceId);

		var registrationId = await mediator.Send(command);

		var uri = $"/registrations/{registrationId}";

		return Created(uri, new { Id = registrationId });
	}
}
