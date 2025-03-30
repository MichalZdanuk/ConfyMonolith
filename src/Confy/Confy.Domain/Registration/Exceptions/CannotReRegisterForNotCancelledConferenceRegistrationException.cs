using Confy.Shared.Exceptions;

namespace Confy.Domain.Registration.Exceptions;
public class CannotReRegisterForNotCancelledConferenceRegistrationException
	: BadRequestException
{
	public CannotReRegisterForNotCancelledConferenceRegistrationException(Guid conferenceId) : base($"Cannot re-register to conference: {conferenceId} because it is not cancelled")
	{
	}
}
