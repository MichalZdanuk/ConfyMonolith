using Confy.Shared.Exceptions;

namespace Confy.Application.Exceptions;
public class UserNotFoundException
	: BadRequestException
{
	public UserNotFoundException(Guid userId) : base($"User with id: {userId} was not found")
	{
	}
}
