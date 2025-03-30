using Confy.Shared.Exceptions;

namespace Confy.Domain.Authentication.Exceptions;
public class InvalidLoginCredentials()
	: BadRequestException("Invalid login credentials")
{
}
