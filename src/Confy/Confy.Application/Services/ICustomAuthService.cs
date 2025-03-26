using Confy.Domain.Enums;

namespace Confy.Application.Services;
public interface ICustomAuthService
{
	public Task Register(Guid id, string email, string password, UserRole userRole, string? bio = null);
	public Task<string> Login(string email, string password);
}
