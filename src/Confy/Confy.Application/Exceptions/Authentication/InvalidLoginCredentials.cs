using Confy.Application.Exceptions.Abstractions;

namespace Confy.Application.Exceptions.Authentication;
public class InvalidLoginCredentials()
	: BadRequestException("Invalid login credentials")
{
}
