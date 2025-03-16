using Confy.Application.Commands.Authentication;
using Confy.Application.DTO.Authentication;

namespace Confy.API.Controllers
{
	[Route("auth")]
    [ApiController]
    public class AuthController(IMediator mediator)
        : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok("Ok auth test");
        }

		[HttpPost("register")]
		public async Task<ActionResult> Register([FromBody] RegisterDto dto)
		{
			var command = new RegisterCommand(dto.Email, dto.Password);

			await mediator.Send(command);

			return Ok();
		}

		[HttpPost("login")]
		public async Task<ActionResult<LoginResponseDto>> Login([FromBody] LoginDto dto)
		{
			var command = new LoginCommand(dto.Email, dto.Password);

			var response = await mediator.Send(command);

			return Ok(response);
		}
	}
}
