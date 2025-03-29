using Confy.Application.DTO.ConferenceManagement.CreateConference;
using Confy.Shared.Enums;

namespace Confy.Application.Commands.ConferenceManagement.CreateConference;
public record CreateConferenceCommand(string Name,
	ConferenceLanguage ConferenceLanguage,
	CreateConferenceLinksDto ConferenceLinks,
	CreateConferenceDetailsDto ConferenceDetails,
	CreateAddressDto Address) : ICommand
{
	public Guid Id { get; } = Guid.NewGuid();
}
