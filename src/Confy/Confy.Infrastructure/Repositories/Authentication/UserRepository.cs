using Confy.Domain.Authentication.Entities;
using Confy.Domain.Authentication.Repositories;

namespace Confy.Infrastructure.Repositories.Authentication;
public class UserRepository : IUserRepository
{
	private readonly ConfyDbContext _context;

	public UserRepository(ConfyDbContext context)
	{
		_context = context;
	}

	public async Task<bool> ExistsAsync(string email)
	{
		return await _context.Users.AnyAsync(u => u.Email == email);
	}

	public async Task<User?> GetByEmailAsync(string email)
	{
		return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
	}

	public async Task<User?> GetByIdAsync(Guid id)
	{
		return await _context.Users.SingleOrDefaultAsync(u => u.Id == id);
	}

	public async Task AddAsync(User user)
	{
		await _context.Users.AddAsync(user);
	}

	public async Task<Dictionary<Guid, string>> GetUserEmailsByIdsAsync(IEnumerable<Guid> userIds)
	{
		return await _context.Users
			.Where(u => userIds.Contains(u.Id))
			.ToDictionaryAsync(u => u.Id, u => u.Email);
	}
}
