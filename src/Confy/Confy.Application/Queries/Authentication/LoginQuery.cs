using Confy.Application.DTO.Authentication;

namespace Confy.Application.Queries.Authentication;
public record LoginQuery(string Email, string Password) : IQuery<LoginResponseDto>;
