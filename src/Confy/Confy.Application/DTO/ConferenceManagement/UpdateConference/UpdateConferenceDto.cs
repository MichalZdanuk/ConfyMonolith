using Confy.Shared.Enums;

namespace Confy.Application.DTO.ConferenceManagement.UpdateConference;
public record UpdateConferenceDto(ConferenceLanguage ConferenceLanguage,
	UpdateConferenceLinksDto conferenceLinksDto,
	UpdateConferenceDetailsDto conferenceDetailsDto,
	UpdateAddressDto AddressDto);
