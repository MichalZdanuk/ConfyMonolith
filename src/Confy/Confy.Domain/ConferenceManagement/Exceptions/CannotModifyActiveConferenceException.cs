﻿namespace Confy.Domain.ConferenceManagement.Exceptions;
public class CannotModifyActiveConferenceException
	: BadRequestException
{
	public CannotModifyActiveConferenceException(Guid conferenceId) : base($"Conference with id: {conferenceId} is past or ongoing, cannot update")
	{
	}
}
