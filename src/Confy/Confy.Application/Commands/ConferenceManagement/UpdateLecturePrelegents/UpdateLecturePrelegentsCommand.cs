namespace Confy.Application.Commands.ConferenceManagement.UpdateLecturePrelegents;
public record UpdateLecturePrelegentsCommand(Guid LectureId, IList<Guid> PrelegentIds) : ICommand;
