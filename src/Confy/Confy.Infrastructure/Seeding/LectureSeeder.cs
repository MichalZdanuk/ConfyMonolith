using Confy.Domain.ConferenceManagement.Entities;
using Confy.Domain.ConferenceManagement.ValueObjects;

namespace Confy.Infrastructure.Seeding;
public static class LectureSeeder
{
	public static async Task SeedLecturesAsync(ConfyDbContext context)
	{
		for (int i = 0; i < SeedConstants.LectureIds.Length; i++)
		{
			var lectureId = SeedConstants.LectureIds[i];
			var exists = await context.Lectures.AnyAsync(l => l.Id == lectureId);
			if (exists) continue;

			var conferenceId = SeedConstants.ConferenceIds[i];

			var start = new DateTime(2025, 6, 1 + i, 10, 0, 0);
			var end = start.AddHours(1);

			var lecture = Lecture.Create(
				lectureId,
				conferenceId,
				LectureDetails.Of($"Modern .NET {i + 1}", start, end)
			);

			lecture.AddPrelegent(SeedConstants.PrelegentIds[i % SeedConstants.PrelegentIds.Length]);

			var conference = await context.Conferences.FirstOrDefaultAsync(c => c.Id == conferenceId);
			conference?.AddLecture(lectureId);

			await context.Lectures.AddAsync(lecture);
		}

		await context.SaveChangesAsync();
	}
}

