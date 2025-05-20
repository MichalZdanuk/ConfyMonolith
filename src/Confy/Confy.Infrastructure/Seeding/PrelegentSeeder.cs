using Confy.Domain.ConferenceManagement.Entities;

namespace Confy.Infrastructure.Seeding;
public static class PrelegentSeeder
{
	public static async Task SeedPrelegentsAsync(ConfyDbContext context)
	{
		if (context.Prelegents.Any()) return;

		var prelegents = new List<Prelegent>
		{
			Prelegent.Create(SeedConstants.PrelegentIds[0], "Alice Johnson", "Senior .NET Developer at TechCorp"),
			Prelegent.Create(SeedConstants.PrelegentIds[1], "Bob Smith", "Cloud Solutions Architect"),
			Prelegent.Create(SeedConstants.PrelegentIds[2], "Carla Mendes", "Software Engineer and Speaker")
		};

		await context.Prelegents.AddRangeAsync(prelegents);
		await context.SaveChangesAsync();
	}
}

