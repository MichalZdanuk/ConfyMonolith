using Confy.Domain.ConferenceManagement;
using Confy.Domain.Repositories.ConferenceManagement;

namespace Confy.Infrastructure.Repositories.ConferenceManagement;
public class ConferenceRepository(ConfyDbContext context)
	: IConferenceRepository
{
	public async Task AddAsync(Conference conference)
	{
		await context.AddAsync(conference);
	}
}
