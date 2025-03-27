using Confy.Application.Commands.ConferenceManagement.UpdateLecture;
using Confy.Application.DTO.ConferenceManagement.UpdateLecture;
using Microsoft.AspNetCore.Authorization;

namespace Confy.API.Controllers;

[Authorize]
[Route("lectures")]
[ApiController]
public class LecturesController(IMediator mediator)
	: ControllerBase
{
	[HttpPut("{id}")]
	public async Task<ActionResult> UpdateLecture(Guid id, [FromBody] UpdateLectureDto dto)
	{
		var command = new UpdateLectureCommand(id,
			dto.Title,
			dto.StartDate,
			dto.EndDate);

		await mediator.Send(command);

		return Accepted();
	}
}
