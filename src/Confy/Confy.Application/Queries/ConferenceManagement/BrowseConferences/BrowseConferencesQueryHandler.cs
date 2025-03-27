﻿using Confy.Application.DTO.ConferenceManagement.BrowseConferences;
using Confy.Application.DTO.ConferenceManagement.GetConferenceById;
using Confy.Domain.Repositories.ConferenceManagement;

namespace Confy.Application.Queries.ConferenceManagement.BrowseConferences;
public class BrowseConferencesQueryHandler(IConferenceRepository conferenceRepository)
	: IRequestHandler<BrowseConferencesQuery, PaginationResult<ConferenceDto>>
{
	public async Task<PaginationResult<ConferenceDto>> Handle(BrowseConferencesQuery query, CancellationToken cancellationToken)
	{
		var conferences = await conferenceRepository.BrowseAsync(query.Pagination.PageNumber, query.Pagination.PageSize);

		var conferenceDtos = conferences
			.Select(c => new ConferenceDto(
				c.Id,
				c.Name,
				c.Language,
				new ConferenceDetailsDto(
					c.ConferenceDetails.StartDate,
					c.ConferenceDetails.EndDate,
					c.ConferenceDetails.Description,
					c.ConferenceDetails.IsOnline
				),
				new AddressDto(
					c.Address.City,
					c.Address.Country,
					c.Address.AddressLine,
					c.Address.ZipCode
				)
			))
			.ToList();

		var conferencesCount = await conferenceRepository.CountAsync();

		return new PaginationResult<ConferenceDto>(query.Pagination.PageNumber,
			query.Pagination.PageSize,
			conferencesCount,
			conferenceDtos);
	}
}
