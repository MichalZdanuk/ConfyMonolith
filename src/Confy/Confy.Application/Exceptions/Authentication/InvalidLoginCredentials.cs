namespace Confy.Application.Exceptions.Authentication;
public class InvalidLoginCredentials()
	: BadRequestException("Invalid login credentials")
{
}
