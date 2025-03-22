namespace Confy.Domain.Authentication;
public class User : Entity
{
	public string Email { get; private set; } = string.Empty;
	public string PasswordHash { get; private set; } = string.Empty;
	public string? Bio { get; private set; }
	public UserRole UserRole { get; private set; }

	public static User Create(string email,
		string passwordHash,
		UserRole userRole,
		string? bio = null)
	{
		return new User()
		{
			Id = Guid.NewGuid(),
			Email = email,
			PasswordHash = passwordHash,
			UserRole = userRole,
			Bio = bio,
		};
	}
}
