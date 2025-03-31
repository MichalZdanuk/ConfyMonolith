using Confy.Application.Commands.ConferenceManagement.AddLecture;
using Confy.Application.Commands.ConferenceManagement.CreateConference;
using Confy.Application.Commands.ConferenceManagement.UpdateConference;
using Confy.Application.Common;
using Confy.Application.DTO.ConferenceManagement.AddLecture;
using Confy.Application.DTO.ConferenceManagement.BrowseConferences;
using Confy.Application.DTO.ConferenceManagement.CreateConference;
using Confy.Application.DTO.ConferenceManagement.GetConferenceById;
using Confy.Application.DTO.ConferenceManagement.UpdateConference;
using Confy.Application.Queries.ConferenceManagement.BrowseConferences;
using Confy.Application.Queries.ConferenceManagement.GetConferenceById;
using Confy.Shared.Enums;
using Microsoft.AspNetCore.Authorization;

namespace Confy.API.Controllers;

[Authorize]
[Route("conferences")]
[ApiController]
public class ConferencesController(IMediator mediator)
	: ControllerBase
{
	[HttpPost]
	public async Task<ActionResult> CreateConference([FromBody] CreateConferenceDto dto)
	{
		var command = new CreateConferenceCommand(dto.Name,
			dto.ConferenceLanguage,
			dto.ConferenceLinksDto,
			dto.ConferenceDetailsDto,
			dto.AddressDto);

		await mediator.Send(command);
		var uri = $"/conferences/{command.Id}";

		return Created(uri, new { Id = command.Id });
	}

	[HttpPut("{id}")]
	public async Task<ActionResult> UpdateConference([FromRoute] Guid id, [FromBody] UpdateConferenceDto dto)
	{
		var command = new UpdateConferenceCommand(id,
			dto.ConferenceLanguage,
			dto.conferenceLinksDto,
			dto.conferenceDetailsDto,
			dto.AddressDto);

		await mediator.Send(command);

		return Accepted();
	}

	[HttpGet("{id}")]
	public async Task<ActionResult<GetConferenceDto>> GetById(Guid id)
	{
		var query = new GetConferenceByIdQuery(id);

		var result = await mediator.Send(query);

		return result;
	}

	[HttpGet]
	public async Task<ActionResult<PaginationResult<ConferenceDto>>> Browse([FromQuery] PaginationRequest request,
		[FromQuery] List<ConferenceLanguage> languages, [FromQuery] bool? isOnline = null, [FromQuery] string? country = null,
		[FromQuery] DateTime? startDate = null, [FromQuery] DateTime? endDate = null)
	{
		var query = new BrowseConferencesQuery(request, languages ?? new List<ConferenceLanguage>(),
			isOnline, country, startDate, endDate);

		var result = await mediator.Send(query);

		return Ok(result);
	}

	[HttpPost("{id}/lectures")]
	public async Task<ActionResult> AddLecture(Guid id, [FromBody] AddLectureDto dto)
	{
		var command = new AddLectureCommand(id, dto.Title, dto.StartDate, dto.EndDate, dto.PrelegentIds);

		await mediator.Send(command);

		var uri = $"/lectures/{command.Id}";

		return Created(uri, new { Id = command.Id });
	}
}
