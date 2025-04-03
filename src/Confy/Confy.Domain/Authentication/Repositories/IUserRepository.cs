using Confy.Domain.Authentication.Entities;

namespace Confy.Domain.Authentication.Repositories;
public interface IUserRepository
{
	public Task<bool> ExistsAsync(string email);
	public Task<User?> GetByEmailAsync(string email);
	public Task AddAsync(User user);
	public Task<User?> GetByIdAsync(Guid id);
}
