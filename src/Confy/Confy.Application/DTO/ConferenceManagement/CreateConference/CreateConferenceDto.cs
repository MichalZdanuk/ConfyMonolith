using Confy.Shared.Enums;

namespace Confy.Application.DTO.ConferenceManagement.CreateConference;
public record CreateConferenceDto(string Name,
	ConferenceLanguage ConferenceLanguage,
	CreateConferenceLinksDto ConferenceLinksDto,
	CreateConferenceDetailsDto ConferenceDetailsDto,
	CreateAddressDto AddressDto);
