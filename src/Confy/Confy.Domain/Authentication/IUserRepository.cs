namespace Confy.Domain.Authentication;
public interface IUserRepository
{
	public Task<bool> UserExists(string email);
	public Task<User?> GetByEmail(string email);
	public Task AddUser(User user);
}
