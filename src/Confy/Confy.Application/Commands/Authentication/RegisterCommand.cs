namespace Confy.Application.Commands.Authentication;
public record RegisterCommand(string Email, string Password) : IRequest;
