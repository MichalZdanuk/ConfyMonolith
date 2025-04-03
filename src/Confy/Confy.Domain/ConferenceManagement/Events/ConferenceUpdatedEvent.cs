namespace Confy.Domain.ConferenceManagement.Events;
public record ConferenceUpdatedEvent(Guid ConferenceId, string ConferenceName) : IDomainEvent;
