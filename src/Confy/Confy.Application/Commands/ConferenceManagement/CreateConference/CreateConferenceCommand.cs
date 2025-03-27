using Confy.Application.DTO.ConferenceManagement.CreateConference;

namespace Confy.Application.Commands.ConferenceManagement.CreateConference;
public record CreateConferenceCommand(string Name,
	string Language,
	CreateConferenceLinksDto ConferenceLinks,
	CreateConferenceDetailsDto ConferenceDetails,
	CreateAddressDto Address) : ICommand
{
	public Guid Id { get; } = Guid.NewGuid();
}
