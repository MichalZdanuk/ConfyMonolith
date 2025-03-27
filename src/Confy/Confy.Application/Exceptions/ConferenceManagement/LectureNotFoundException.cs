namespace Confy.Application.Exceptions.ConferenceManagement;
public class LectureNotFoundException
	: NotFoundException
{
	public LectureNotFoundException(Guid lectureId) : base($"Lecture: {lectureId} was not found")
	{
	}
}
