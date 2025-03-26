using Confy.Domain.Enums;

namespace Confy.Application.Commands.Authentication;
public record RegisterCommand(string Email, string Password, UserRole UserRole = UserRole.Attendee) : ICommand
{
	public Guid Id { get; } = Guid.NewGuid();
}
