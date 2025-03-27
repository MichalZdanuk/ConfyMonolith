using Confy.Application.Commands.ConferenceManagement.CreateConference;
using Confy.Application.DTO.ConferenceManagement.CreateConference;
using Microsoft.AspNetCore.Authorization;

namespace Confy.API.Controllers;

[Authorize]
[Route("conferences")]
[ApiController]
public class ConferencesController(IMediator mediator)
	: ControllerBase
{
	[HttpPost]
	public async Task<ActionResult> CreateConference([FromBody]CreateConferenceDto dto)
	{
		var command = new CreateConferenceCommand(dto.Name,
			dto.Language,
			dto.ConferenceLinksDto,
			dto.ConferenceDetailsDto,
			dto.AddressDto);

		await mediator.Send(command);
		var uri = $"/conferences/{command.Id}";

		return Created(uri, new { Id = command.Id });
	}
}
