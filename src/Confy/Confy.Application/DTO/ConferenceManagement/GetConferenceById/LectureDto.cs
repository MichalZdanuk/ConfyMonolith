namespace Confy.Application.DTO.ConferenceManagement.GetConferenceById;
public record LectureDto(Guid Id, LectureDetailsDto LectureDetails, IList<PrelegentDto> Prelegents);
