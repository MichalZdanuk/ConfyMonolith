using Confy.Domain.Abstractions.Exceptions;

namespace Confy.Domain.Registration.Exceptions;
public class CannotRegisterAfterStartOfConferenceException
	: BadRequestException
{
	public CannotRegisterAfterStartOfConferenceException(Guid conferenceId) : base($"Cannot register conference: {conferenceId} is past or ongoing")
	{
	}
}
