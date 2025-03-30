using Confy.Shared.Enums;

namespace Confy.Application.Queries.Registrations.BrowseRegistrationsByConference;
public record ConferenceRegistrationDto(Guid RegistrationId, Guid UserId, RegistrationStatus RegistrationStatus);
