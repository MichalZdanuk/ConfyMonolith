using Confy.Application.DTO.ConferenceManagement.UpdateConference;

namespace Confy.Application.Commands.ConferenceManagement.UpdateConference;
public record UpdateConferenceCommand(Guid ConferenceId,
	string Name,
	string Language,
	UpdateConferenceLinksDto ConferenceLinks,
	UpdateConferenceDetailsDto ConferenceDetails,
	UpdateAddressDto Address) : ICommand;
