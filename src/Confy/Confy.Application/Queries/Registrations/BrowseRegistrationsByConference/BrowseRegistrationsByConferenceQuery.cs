using Confy.Shared.Enums;

namespace Confy.Application.Queries.Registrations.BrowseRegistrationsByConference;
public record BrowseRegistrationsByConferenceQuery(Guid ConferenceId, List<RegistrationStatus> Statuses) : IQuery<IReadOnlyList<ConferenceRegistrationDto>>;
