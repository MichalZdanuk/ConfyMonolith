namespace Confy.Domain.Registration.Events;
public record UserReRegisteredForConferenceEvent(Guid UserId, Guid ConferenceId) : IDomainEvent;
