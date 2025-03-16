using Confy.Domain.Authentication;

namespace Confy.Infrastructure.Repositories;
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
