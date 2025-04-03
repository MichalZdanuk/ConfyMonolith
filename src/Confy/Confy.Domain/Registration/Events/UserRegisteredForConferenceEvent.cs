namespace Confy.Domain.Registration.Events;
public record UserRegisteredForConferenceEvent(Guid UserId, Guid ConferenceId, string ConferenceName) : IDomainEvent;
