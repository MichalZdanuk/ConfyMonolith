﻿using Confy.Domain.ConferenceManagement;
using Confy.Domain.Repositories.ConferenceManagement;

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

	public async Task UpdateAsync(Lecture lecture)
	{
		context.Lectures.Update(lecture);
	}
}
