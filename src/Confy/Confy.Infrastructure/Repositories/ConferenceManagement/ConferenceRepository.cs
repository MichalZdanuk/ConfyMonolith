using Confy.Domain.ConferenceManagement;
using Confy.Domain.Repositories.ConferenceManagement;

namespace Confy.Infrastructure.Repositories.ConferenceManagement;
public class ConferenceRepository(ConfyDbContext context)
	: IConferenceRepository
{
	public async Task<Conference?> GetByIdAsync(Guid id)
	{
		var conference = await context.Conferences
			.FirstOrDefaultAsync(c => c.Id == id);

		if (conference is null)
		{
			return null;
		}

		var lectureIds = await context.Lectures
			.Where(l => l.ConferenceId == id)
			.Select(l => l.Id)
			.ToListAsync();

		foreach (var lectureId in lectureIds)
		{
			conference.AddLecture(lectureId);
		}

		return conference;
	}

	public async Task AddAsync(Conference conference)
	{
		await context.AddAsync(conference);
	}
}
