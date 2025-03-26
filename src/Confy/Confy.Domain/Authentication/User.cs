namespace Confy.Domain.Authentication;
public class User : Entity
{
	public string Email { get; private set; } = string.Empty;
	public string PasswordHash { get; private set; } = string.Empty;
	public string? Bio { get; private set; }
	public UserRole UserRole { get; private set; }

	public static User Create(Guid id,
		string email,
		string passwordHash,
		UserRole userRole,
		string? bio = null)
	{
		return new User()
		{
			Id = id,
			Email = email,
			PasswordHash = passwordHash,
			UserRole = userRole,
			Bio = bio,
		};
	}
}
