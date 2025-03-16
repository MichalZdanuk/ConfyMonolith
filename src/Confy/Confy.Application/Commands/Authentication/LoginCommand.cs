using Confy.Application.DTO.Authentication;
using MediatR;

namespace Confy.Application.Commands.Authentication;
public record LoginCommand(string Email, string Password) : IRequest<LoginResponseDto>;
