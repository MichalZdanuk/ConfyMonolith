namespace Confy.Application.Exceptions.Authentication;
public class EmailAlreadyTakenException(string email)
	: BadRequestException($"Email: {email} is already taken.")
{
}
