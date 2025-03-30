using Confy.Domain.ConferenceManagement;
using Confy.Domain.ConferenceManagement.Repositories;

namespace Confy.Infrastructure.Repositories.ConferenceManagement;
public class LectureRepository(ConfyDbContext context)
	: ILectureRepository
{
	public async Task AddAsync(Lecture lecture)
	{
		await context.AddAsync(lecture);
	}

	public async Task<Lecture?> GetByIdAsync(Guid id)
	{
		return await context.Lectures.SingleOrDefaultAsync(l => l.Id == id);
	}

	public async Task<List<Lecture>> GetLecturesWithAssignmentsByConferenceIdAsync(Guid conferenceId)
	{
		return await context.Lectures
			.Include(l => l.LectureAssignments)
			.Where(l => l.ConferenceId == conferenceId).ToListAsync();
	}

	public async Task<Lecture?> GetWithAssignmentsByIdAsync(Guid id)
	{
		return await context.Lectures
			.Include(l => l.LectureAssignments)
			.SingleOrDefaultAsync(l => l.Id == id);
	}

	public async Task UpdateAsync(Lecture lecture)
	{
		context.Lectures.Update(lecture);
	}
}
