namespace Confy.Application.DTO.ConferenceManagement.AddLecture;
public record AddLectureDto(string Title, DateTime StartDate, DateTime EndDate, IList<Guid> PrelegentIds);
