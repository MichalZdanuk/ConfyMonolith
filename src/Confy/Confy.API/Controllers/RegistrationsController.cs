﻿using Confy.Application.Commands.Registrations.AddRegistration;
using Confy.Application.Commands.Registrations.CancelRegistration;
using Confy.Application.Common;
using Confy.Application.Queries.Registrations.BrowseMyRegistrations;
using Confy.Application.Queries.Registrations.BrowseRegistrationsByConference;
using Confy.Shared.Enums;
using Microsoft.AspNetCore.Authorization;

namespace Confy.API.Controllers;

[Authorize]
[Route("registrations")]
[ApiController]
public class RegistrationsController(IMediator mediator)
	: ControllerBase
{
	[Authorize(Roles = "Attendee")]
	[HttpPost]
	public async Task<ActionResult> AddRegistration([FromBody] AddRegistrationDto dto)
	{
		var command = new AddRegistrationCommand(dto.ConferenceId);

		var registrationId = await mediator.Send(command);

		var uri = $"/registrations/{registrationId}";

		return Created(uri, new { Id = registrationId });
	}

	[Authorize(Roles = "Attendee")]
	[HttpPut("{id}/cancel")]
	public async Task<ActionResult> CancelRegistration([FromRoute] Guid id)
	{
		var command = new CancelRegistrationCommand(id);

		await mediator.Send(command);

		return Accepted();
	}

	[Authorize(Roles = "Attendee")]
	[HttpGet]
	public async Task<ActionResult<PaginationResult<UserRegistrationDto>>> BrowseMyRegistrations([FromQuery] PaginationRequest request,
		bool onlyPending = false)
	{
		var query = new BrowseMyRegistrationsQuery(request, onlyPending);

		var result = await mediator.Send(query);

		return Ok(result);
	}

	[Authorize(Roles = "Host")]
	[HttpGet("conference/{conferenceId}")]
	public async Task<ActionResult<IReadOnlyList<ConferenceRegistrationDto>>> BrowseRegistrationsByConference([FromRoute] Guid conferenceId,
		[FromQuery] List<RegistrationStatus> statuses)
	{
		var query = new BrowseRegistrationsByConferenceQuery(conferenceId, statuses ?? new List<RegistrationStatus>());

		var result = await mediator.Send(query);

		return Ok(result);
	}
}
