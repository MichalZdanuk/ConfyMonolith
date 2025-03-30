using Confy.Shared.Exceptions;

namespace Confy.Domain.ConferenceManagement.Exceptions;
public class ConferenceNotFoundException : NotFoundException
{
	public ConferenceNotFoundException(Guid conferenceId) : base($"Conference with id: {conferenceId} was not found")
	{
	}
}
