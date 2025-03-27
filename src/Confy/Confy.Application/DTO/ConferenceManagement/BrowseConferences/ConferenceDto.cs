using Confy.Application.DTO.ConferenceManagement.GetConferenceById;

namespace Confy.Application.DTO.ConferenceManagement.BrowseConferences;
public record ConferenceDto(Guid Id, string Name, string Language, ConferenceDetailsDto ConferenceDetails, AddressDto Address);
