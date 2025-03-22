using Confy.Application.DTO.Authentication;

namespace Confy.Application.Commands.Authentication;
public record LoginCommand(string Email, string Password) : ICommand<LoginResponseDto>;
