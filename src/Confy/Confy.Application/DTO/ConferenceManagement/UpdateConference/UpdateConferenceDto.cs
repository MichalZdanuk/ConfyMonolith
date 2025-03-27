namespace Confy.Application.DTO.ConferenceManagement.UpdateConference;
public record UpdateConferenceDto(string Name,
	string Language,
	UpdateConferenceLinksDto conferenceLinksDto,
	UpdateConferenceDetailsDto conferenceDetailsDto,
	UpdateAddressDto AddressDto);
