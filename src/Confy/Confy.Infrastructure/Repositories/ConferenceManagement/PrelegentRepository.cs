using Confy.Domain.ConferenceManagement;
using Confy.Domain.Repositories.ConferenceManagement;

namespace Confy.Infrastructure.Repositories.ConferenceManagement;
public class PrelegentRepository(ConfyDbContext context)
	: IPrelegentRepository
{
	public async Task AddAsync(Prelegent prelegent)
	{
		await context.Prelegents.AddAsync(prelegent);
	}
}
