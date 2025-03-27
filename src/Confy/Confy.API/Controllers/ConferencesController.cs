using Confy.Application.Commands.ConferenceManagement.CreateConference;
using Confy.Application.DTO.ConferenceManagement.CreateConference;
using Confy.Application.DTO.ConferenceManagement.GetConferenceById;
using Confy.Application.Queries.ConferenceManagement.GetConferenceById;
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

	[HttpGet("{id}")]
	public async Task<ActionResult<GetConferenceDto>> GetById(Guid id)
	{
		var query = new GetConferenceByIdQuery(id);

		var result = await mediator.Send(query);

		return result;
	}
}
