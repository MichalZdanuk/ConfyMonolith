using Confy.Shared.Exceptions;

namespace Confy.Domain.Registration.Exceptions;
public class CannotCancelAfterStartOfConferenceException
	: BadRequestException
{
	public CannotCancelAfterStartOfConferenceException() : base("Cannot cancel because conference has already been started")
	{
	}
}
