using Confy.Shared.Exceptions;

namespace Confy.Domain.Registration.Exceptions;
public class CannotRegisterAfterStartOfConferenceException
	: BadRequestException
{
	public CannotRegisterAfterStartOfConferenceException(Guid conferenceId) : base($"Cannot register conference: {conferenceId} is past or ongoing")
	{
	}
}
