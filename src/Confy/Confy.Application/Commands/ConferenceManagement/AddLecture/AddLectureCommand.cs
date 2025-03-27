namespace Confy.Application.Commands.ConferenceManagement.AddLecture;
public record AddLectureCommand(Guid ConferenceId, string Title, DateTime StartDate, DateTime EndDate, IList<Guid> PrelegentIds) : ICommand
{
	public Guid Id { get; } = Guid.NewGuid();
}
