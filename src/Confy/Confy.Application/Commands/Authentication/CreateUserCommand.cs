using Confy.Domain.Enums;

namespace Confy.Application.Commands.Authentication;
public record CreateUserCommand(string FirstName, string LastName, string Bio, string Email, string Password, UserRole UserRole) : ICommand
{
	public Guid Id { get; } = Guid.NewGuid();
}
