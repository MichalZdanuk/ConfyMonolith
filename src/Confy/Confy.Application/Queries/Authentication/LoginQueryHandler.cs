using Confy.Application.DTO.Authentication;

namespace Confy.Application.Queries.Authentication;
public class LoginQueryHandler(ICustomAuthService customAuthService)
	: IRequestHandler<LoginQuery, LoginResponseDto>
{
	public async Task<LoginResponseDto> Handle(LoginQuery query, CancellationToken cancellationToken)
	{
		var token = await customAuthService.Login(query.Email, query.Password);

		return new LoginResponseDto(token);
	}
}

