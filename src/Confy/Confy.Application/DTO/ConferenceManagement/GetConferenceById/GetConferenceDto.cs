namespace Confy.Application.DTO.ConferenceManagement.GetConferenceById;
public record GetConferenceDto(string name,
	string ConferenceLanguage,
	ConferenceLinksDto ConferenceLinks,
	ConferenceDetailsDto ConferenceDetails,
	AddressDto Address,
	IReadOnlyList<LectureDto> Lectures);
