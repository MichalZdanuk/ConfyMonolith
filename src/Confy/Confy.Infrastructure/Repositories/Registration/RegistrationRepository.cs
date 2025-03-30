using Confy.Domain.Registration.Repositories;
using Confy.Shared.Enums;
using System.Linq;

namespace Confy.Infrastructure.Repositories.Registration;
public class RegistrationRepository(ConfyDbContext context)
	: IRegistrationRepository
{
	public async Task AddAsync(Domain.Registration.Registration registration)
	{
		await context.Registrations.AddAsync(registration);
	}

	public async Task UpdateAsync(Domain.Registration.Registration registration)
	{
		context.Registrations.Update(registration);
	}

	public async Task<Domain.Registration.Registration?> GetByUserIdAndConferenceId(Guid userId, Guid conferenceId)
	{
		return await context.Registrations
			.Include(r => r.Conference)
			.SingleOrDefaultAsync(r => r.UserId == userId && r.ConferenceId == conferenceId);
	}

	public async Task<Domain.Registration.Registration?> GetByIdAsync(Guid id)
	{
		return await context.Registrations
			.Include(r => r.Conference)
			.SingleOrDefaultAsync(r => r.Id == id);
	}

	public async Task<IList<Domain.Registration.Registration>> BrowseByUserIdAsync(Guid userId,
		bool onlyPending, int pageNumber, int pageSize)
	{
		var registrationsQuery = context.Registrations
			.Include(r => r.Conference)
			.Where(r => r.UserId == userId);

		if (onlyPending)
		{
			registrationsQuery = registrationsQuery.Where(r => r.Conference.ConferenceDetails.StartDate > DateTime.UtcNow);
		}

		return await registrationsQuery
			.OrderBy(r => r.Conference.ConferenceDetails.StartDate)
			.Skip((pageNumber - 1) * pageSize)
			.Take(pageSize)
			.ToListAsync();
	}

	public async Task<IList<Domain.Registration.Registration>> BrowseByConferenceIdAsync(Guid conferenceId, List<RegistrationStatus> statuses)
	{
		var query = context.Registrations.Where(r => r.ConferenceId == conferenceId);

		if (statuses.Count > 0)
		{
			query = query.Where(r => statuses.Contains(r.RegistrationStatus));
		}

		return await query.ToListAsync();
	}

	public async Task<int> CountByUserIdAsync(Guid userId)
	{
		return await context.Registrations.CountAsync(r => r.UserId == userId);
	}
}
