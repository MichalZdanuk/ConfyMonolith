using Confy.Domain.Authentication.Entities;

namespace Confy.Domain.Authentication.Repositories;
public interface IUserRepository
{
	public Task<bool> UserExists(string email);
	public Task<User?> GetByEmail(string email);
	public Task AddUser(User user);
	public Task<User?> GetByIdAsync(Guid id);
}
