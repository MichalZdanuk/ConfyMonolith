using Confy.Application.DTO.ConferenceManagement.GetConferenceById;

namespace Confy.Application.DTO.ConferenceManagement.BrowseConferences;
public record ConferenceDto(Guid Id, string Name, string ConferenceLanguage, ConferenceDetailsDto ConferenceDetails, AddressDto Address);
