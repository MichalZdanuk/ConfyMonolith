using Confy.Application.Services;
using MediatR;

namespace Confy.Application.Commands.Authentication;
public class RegisterCommandHandler(ICustomAuthService customAuthService)
	: IRequestHandler<RegisterCommand>
{
	public async Task Handle(RegisterCommand command, CancellationToken cancellationToken)
	{
		await customAuthService.Register(command.Email, command.Password);
	}
}
