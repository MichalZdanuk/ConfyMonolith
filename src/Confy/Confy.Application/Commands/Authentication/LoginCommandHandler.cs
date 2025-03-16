using Confy.Application.DTO.Authentication;

namespace Confy.Application.Commands.Authentication;
public class LoginCommandHandler(ICustomAuthService customAuthService)
	: IRequestHandler<LoginCommand, LoginResponseDto>
{
	public async Task<LoginResponseDto> Handle(LoginCommand command, CancellationToken cancellationToken)
	{
		var token = await customAuthService.Login(command.Email, command.Password);

		return new LoginResponseDto(token);
	}
}
