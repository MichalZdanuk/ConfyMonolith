using Confy.Domain.ConferenceManagement;

namespace Confy.Domain.Repositories.ConferenceManagement;
public interface ILectureRepository
{
	public Task<List<Lecture>> GetLecturesWithAssignmentsByConferenceIdAsync(Guid conferenceId);
}
