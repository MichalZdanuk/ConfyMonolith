using Confy.Shared.Enums;

namespace Confy.Application.DTO.ConferenceManagement.UpdateConference;
public record UpdateConferenceDto(string Name,
	ConferenceLanguage ConferenceLanguage,
	UpdateConferenceLinksDto conferenceLinksDto,
	UpdateConferenceDetailsDto conferenceDetailsDto,
	UpdateAddressDto AddressDto);
