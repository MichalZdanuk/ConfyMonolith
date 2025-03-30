﻿using Confy.Domain.Registration.Repositories;

namespace Confy.Application.Queries.Registrations.BrowseMyRegistrations;
public class BrowseMyRegistrationsQueryHandler(IContext context,
	IRegistrationRepository registrationRepository)
	: IRequestHandler<BrowseMyRegistrationsQuery, PaginationResult<UserRegistrationDto>>
{
	public async Task<PaginationResult<UserRegistrationDto>> Handle(BrowseMyRegistrationsQuery query, CancellationToken cancellationToken)
	{
		var registrations = await registrationRepository.BrowseByUserIdAsync(context.UserId,
			query.OnlyPending, query.Pagination.PageNumber, query.Pagination.PageSize);

		var registrationsDtos = registrations.Select(r => new UserRegistrationDto(
			r.Id,
			r.ConferenceId,
			r.Conference.Name));

		var registrationsCount = await registrationRepository.CountByUserIdAsync(context.UserId);

		return new PaginationResult<UserRegistrationDto>(query.Pagination.PageNumber,
			query.Pagination.PageSize,
			registrationsCount,
			registrationsDtos);
	}
}
