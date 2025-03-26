namespace Confy.Application.Commands.Authentication;
public class CreateUserCommandHandler(ICustomAuthService customAuthService)
	: IRequestHandler<CreateUserCommand>
{
	public async Task Handle(CreateUserCommand command, CancellationToken cancellationToken)
	{
		await customAuthService.Register(command.Id,
			command.FirstName,
			command.LastName,
			command.Email,
			command.Password,
			command.UserRole,
			command.Bio);
	}
}
