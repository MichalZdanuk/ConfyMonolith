namespace Confy.Application.Exceptions.ConferenceManagement;
public class ConferenceNotFoundException : NotFoundException
{
	public ConferenceNotFoundException(Guid conferenceId) : base($"Conference with id: {conferenceId} was not found")
	{
	}
}
