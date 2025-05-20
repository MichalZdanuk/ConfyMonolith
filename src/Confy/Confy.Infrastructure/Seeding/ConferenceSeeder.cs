﻿using Confy.Domain.ConferenceManagement.Entities;
using Confy.Domain.ConferenceManagement.ValueObjects;
using Confy.Shared.Enums;

namespace Confy.Infrastructure.Seeding;
public static class ConferenceSeeder
{
	public static async Task SeedConferenceAsync(ConfyDbContext context)
	{
		for (int i = 0; i < SeedConstants.ConferenceIds.Length; i++)
		{
			var id = SeedConstants.ConferenceIds[i];
			var exists = await context.Conferences.AnyAsync(c => c.Id == id);
			if (exists) continue;

			var startDate = new DateTime(2025, 6, 1 + i, 9, 0, 0);
			var endDate = startDate.AddDays(2);

			var conference = Conference.Create(
				id,
				$".NET Conf {2025 + i}",
				ConferenceLanguage.English,
				ConferenceLinks.Of(
					$"https://dotnetconf{i + 1}.com",
					$"https://facebook.com/dotnetconf{i + 1}",
					$"https://instagram.com/dotnetconf{i + 1}"
				),
				ConferenceDetails.Of(
					startDate,
					endDate,
					$"Annual .NET conference edition {i + 1}",
					false
				),
				Address.Of("Berlin", "Germany", $"Messe Berlin Hall {i + 1}", $"10{i}78")
			);

			await context.Conferences.AddAsync(conference);
		}

		await context.SaveChangesAsync();
	}
}
