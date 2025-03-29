﻿using Confy.Application.Exceptions.ConferenceManagement;
using Confy.Domain.ConferenceManagement.ValueObjects;
using Confy.Domain.Repositories.ConferenceManagement;

namespace Confy.Application.Commands.ConferenceManagement.UpdateConference;
public class UpdateConferenceCommandHandler(IConferenceRepository conferenceRepository)
	: IRequestHandler<UpdateConferenceCommand>
{
	public async Task Handle(UpdateConferenceCommand command, CancellationToken cancellationToken)
	{
		var conference = await conferenceRepository.GetByIdAsync(command.ConferenceId);

		if (conference is null)
		{
			throw new ConferenceNotFoundException(command.ConferenceId);
		}

		var updatedConferenceLinks = ConferenceLinks.Of(command.ConferenceLinks.WebsiteUrl,
			command.ConferenceLinks.FacebookUrl,
			command.ConferenceLinks.InstagramUrl);

		var updatedConferenceDetails = ConferenceDetails.Of(conference.ConferenceDetails.StartDate,
			conference.ConferenceDetails.EndDate,
			command.ConferenceDetails.Description,
			command.ConferenceDetails.IsOnline);

		var updatedAddress = Address.Of(command.Address.City,
			command.Address.Country,
			command.Address.AddressLine,
			command.Address.ZipCode);

		conference.Update(command.Name, command.ConferenceLanguage, updatedConferenceLinks, updatedConferenceDetails, updatedAddress);

		await conferenceRepository.UpdateAsync(conference);
	}
}
