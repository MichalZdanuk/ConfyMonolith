using Confy.Shared.Exceptions;

namespace Confy.Domain.Authentication.Exceptions;
public class EmailAlreadyTakenException(string email)
	: BadRequestException($"Email: {email} is already taken.")
{
}
