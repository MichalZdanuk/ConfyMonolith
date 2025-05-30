﻿namespace Confy.Domain.Abstractions;
public interface IAggregate : IEntity
{
	IReadOnlyList<IDomainEvent> DomainEvents { get; }
	IDomainEvent[] ClearDomainEvents();
}
