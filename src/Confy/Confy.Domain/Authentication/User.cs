namespace Confy.Domain.Authentication;
public class User : Entity
{
	public string Email { get; private set; } = string.Empty;
	public string PasswordHash { get; private set; } = string.Empty;
	public UserRole UserRole { get; private set; } = UserRole.Attendee;

	public static User Create(string email,
		string passwordHash)
	{
		return new User()
		{
			Id = Guid.NewGuid(),
			Email = email,
			PasswordHash = passwordHash,
		};
	}
}
