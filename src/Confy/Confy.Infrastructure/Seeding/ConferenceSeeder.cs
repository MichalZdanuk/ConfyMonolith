using Confy.Domain.ConferenceManagement.Entities;
using Confy.Domain.ConferenceManagement.ValueObjects;
using Confy.Shared.Enums;

namespace Confy.Infrastructure.Seeding;
public static class ConferenceSeeder
{
	private const string _conferenceId = "BFA9B907-4EA3-437B-9380-B60639F8BEAC";

	public static async Task SeedConferenceAsync(ConfyDbContext context)
	{
		var conference = await context.Conferences
			.FirstOrDefaultAsync(u => u.Id == Guid.Parse(_conferenceId));

		if (conference is null)
		{
			var newConference = Conference.Create(
				Guid.Parse(_conferenceId),
				".NET Summit 2025",
				ConferenceLanguage.English,
				ConferenceLinks.Of(
					"https://www.net-summit2025.com",
					"https://facebook.com/netsummit2025",
					"https://instagram.com/netsummit2025"
				),
				ConferenceDetails.Of(
					new DateTime(2025, 6, 6),
					new DateTime(2025, 6, 8),
					"The premier .NET community event featuring top speakers, workshops, and networking opportunities.",
					false // not online
				),
				Address.Of(
					"Berlin",
					"Germany",
					"Berlin Congress Center, Alexanderstraße 11",
					"10178"
				)
			);

			await context.Conferences.AddAsync(newConference);
			await context.SaveChangesAsync();
		}
	}
}

