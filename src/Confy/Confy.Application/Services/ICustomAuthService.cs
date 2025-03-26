using Confy.Domain.Authentication;
using Confy.Domain.Enums;

namespace Confy.Application.Services;
public interface ICustomAuthService
{
	public Task<User> Register(Guid Id, string FirstName, string LastName, string Email, string Password, UserRole UserRole, string? Bio = null);
	public Task<string> Login(string email, string password);
}
