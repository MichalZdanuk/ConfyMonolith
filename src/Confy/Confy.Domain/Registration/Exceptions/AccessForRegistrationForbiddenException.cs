﻿namespace Confy.Domain.Registration.Exceptions;
public class AccessForRegistrationForbiddenException
	: ForbiddenException
{
	public AccessForRegistrationForbiddenException(Guid registrationId) : base($"You do not have access for registration: {registrationId}")
	{
	}
}
