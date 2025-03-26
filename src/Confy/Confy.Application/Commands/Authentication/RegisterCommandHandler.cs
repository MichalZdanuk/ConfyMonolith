namespace Confy.Application.Commands.Authentication;
public class RegisterCommandHandler(ICustomAuthService customAuthService)
	: IRequestHandler<RegisterCommand>
{
	public async Task Handle(RegisterCommand command, CancellationToken cancellationToken)
	{
		await customAuthService.Register(command.Id,
			command.FirstName,
			command.LastName,
			command.Email,
			command.Password,
			command.UserRole);
	}
}
