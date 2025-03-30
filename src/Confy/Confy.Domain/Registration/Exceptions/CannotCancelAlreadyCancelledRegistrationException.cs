using Confy.Domain.Abstractions.Exceptions;

namespace Confy.Domain.Registration.Exceptions;
public class CannotCancelAlreadyCancelledRegistrationException
	: BadRequestException
{
	public CannotCancelAlreadyCancelledRegistrationException(Guid conferenceId) : base($"Registration for conference {conferenceId} was already cancelled")
	{
	}
}
