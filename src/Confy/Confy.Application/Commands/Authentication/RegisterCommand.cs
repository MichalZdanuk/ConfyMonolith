﻿using Confy.Domain.Authentication.Enums;

namespace Confy.Application.Commands.Authentication;
public record RegisterCommand(string FirstName, string LastName, string Email, string Password, UserRole UserRole = UserRole.Attendee) : ICommand
{
	public Guid Id { get; } = Guid.NewGuid();
}
