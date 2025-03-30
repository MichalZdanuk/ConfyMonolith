namespace Confy.Domain.Registration.Events;
public record RegistrationForConferenceCanceledEvent(Guid UserId, Guid ConferenceId) : IDomainEvent;
