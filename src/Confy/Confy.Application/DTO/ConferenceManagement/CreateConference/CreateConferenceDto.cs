namespace Confy.Application.DTO.ConferenceManagement.CreateConference;
public record CreateConferenceDto(string Name,
	string Language,
	CreateConferenceLinksDto ConferenceLinksDto,
	CreateConferenceDetailsDto ConferenceDetailsDto,
	CreateAddressDto AddressDto);
