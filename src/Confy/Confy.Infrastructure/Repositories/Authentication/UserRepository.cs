using Confy.Domain.Authentication;
using Confy.Domain.Authentication.Repositories;

namespace Confy.Infrastructure.Repositories.Authentication;
public class UserRepository : IUserRepository
{
	private readonly ConfyDbContext _context;

	public UserRepository(ConfyDbContext context)
	{
		_context = context;
	}

	public async Task<bool> UserExists(string email)
	{
		return await _context.Users.AnyAsync(u => u.Email == email);
	}

	public async Task<User?> GetByEmail(string email)
	{
		return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
	}

	public async Task AddUser(User user)
	{
		await _context.Users.AddAsync(user);
	}
}
