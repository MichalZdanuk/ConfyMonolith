using Confy.Application.Exceptions.Authentication;
using Confy.Domain.Authentication;
using Confy.Domain.Enums;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Confy.Application.Services;
public class CustomAuthService(IUserRepository userRepository,
	IConfiguration configuration)
	: ICustomAuthService
{
	public async Task Register(string email, string password, UserRole userRole, string? bio = null)
	{
		if (await userRepository.UserExists(email))
		{
			throw new EmailAlreadyTakenException(email);
		}

		var user = User.Create(email, BCrypt.Net.BCrypt.HashPassword(password), userRole, bio);

		await userRepository.AddUser(user);
	}

	public async Task<string> Login(string email, string password)
	{
		var user = await userRepository.GetByEmail(email);
		if (user is null || !BCrypt.Net.BCrypt.Verify(password, user.PasswordHash))
		{
			throw new InvalidLoginCredentials();
		}

		return GenerateJwtToken(user);
	}

	private string GenerateJwtToken(User user)
	{
		var key = Encoding.UTF8.GetBytes(configuration["Jwt:Key"]!);
		var claims = new List<Claim>
		{
			new(ClaimTypes.NameIdentifier, user.Id.ToString()),
			new(ClaimTypes.Email, user.Email),
			new(ClaimTypes.Role, user.UserRole.ToString()),
		};

		var token = new JwtSecurityToken(
			configuration["Jwt:Issuer"],
			configuration["Jwt:Audience"],
			claims,
			expires: DateTime.UtcNow.AddHours(10),
			signingCredentials: new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256)
		);

		return new JwtSecurityTokenHandler().WriteToken(token);
	}
}
