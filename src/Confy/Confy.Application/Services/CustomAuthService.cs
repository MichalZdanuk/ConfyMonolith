using Confy.Domain.Authentication.Entities;
using Confy.Domain.Authentication.Enums;
using Confy.Domain.Authentication.Exceptions;
using Confy.Domain.Authentication.Repositories;
using Confy.Domain.Authentication.ValueObjects;
using Confy.Domain.ConferenceManagement.Entities;
using Confy.Domain.ConferenceManagement.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Confy.Application.Services;
public class CustomAuthService(IUserRepository userRepository,
	IPrelegentRepository prelegentRepository,
	IConfiguration configuration)
	: ICustomAuthService
{
	public async Task<User> Register(Guid Id,
		string FirstName,
		string LastName,
		string Email,
		string Password,
		UserRole UserRole,
		string? Bio = null)
	{
		if (await userRepository.UserExists(Email))
		{
			throw new EmailAlreadyTakenException(Email);
		}

		var user = User.Create(Id,
			Email,
			BCrypt.Net.BCrypt.HashPassword(Password),
			FullName.Of(FirstName, LastName),
			UserRole,
			Bio);

		await userRepository.AddUser(user);

		if (UserRole == UserRole.Prelegent)
		{
			await AddPrelegentEntity(user);
		}

		return user;
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

	private async Task AddPrelegentEntity(User user)
	{
		var prelegent = Prelegent.Create(user.Id, string.Concat(user.FullName.FirstName, " ", user.FullName.LastName), user.Bio ?? string.Empty);
	
		await prelegentRepository.AddAsync(prelegent);
	}
}
