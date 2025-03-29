using Confy.Application.DTO.ConferenceManagement.UpdateConference;
using Confy.Shared.Enums;

namespace Confy.Application.Commands.ConferenceManagement.UpdateConference;
public record UpdateConferenceCommand(Guid ConferenceId,
	string Name,
	ConferenceLanguage ConferenceLanguage,
	UpdateConferenceLinksDto ConferenceLinks,
	UpdateConferenceDetailsDto ConferenceDetails,
	UpdateAddressDto Address) : ICommand;
