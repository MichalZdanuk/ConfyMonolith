using Confy.Application.Commands.Registrations.AddRegistration;
using Confy.Application.Commands.Registrations.CancelRegistration;
using Confy.Application.Common;
using Confy.Application.Queries.Registrations.BrowseMyRegistrations;
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

	[HttpPut("{id}/cancel")]
	public async Task<ActionResult> CancelRegistration([FromRoute] Guid id)
	{
		var command = new CancelRegistrationCommand(id);

		await mediator.Send(command);

		return Accepted();
	}

	[HttpGet]
	public async Task<ActionResult<PaginationResult<UserRegistrationDto>>> BrowseMyRegistrations([FromQuery] PaginationRequest request,
		bool onlyPending = false)
	{
		var query = new BrowseMyRegistrationsQuery(request, onlyPending);

		var result = await mediator.Send(query);

		return Ok(result);
	}
}
