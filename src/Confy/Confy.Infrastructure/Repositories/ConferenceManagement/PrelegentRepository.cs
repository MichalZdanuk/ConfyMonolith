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

	public async Task<IReadOnlyList<Prelegent>> BrowseAsync(IList<Guid> prelegentIds)
	{
		var prelegents = await context.Prelegents
			.Where(x => prelegentIds.Contains(x.Id))
			.ToListAsync();

		return prelegents.AsReadOnly();
	}
}
