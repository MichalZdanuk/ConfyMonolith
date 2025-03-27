namespace Confy.Application.Commands.ConferenceManagement.UpdateLecture;
public record UpdateLectureCommand(Guid LectureId, string Title, DateTime StartDate, DateTime EndDate) : ICommand;
