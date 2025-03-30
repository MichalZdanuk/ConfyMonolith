using Confy.Domain.Registration.Repositories;

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
}
