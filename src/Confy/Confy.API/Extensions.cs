using Confy.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Confy.API;

public static class Extensions
{
	public static async Task InitialiseDatabaseAsync(this WebApplication app)
	{
		using var scope = app.Services.CreateScope();

		var context = scope.ServiceProvider.GetRequiredService<ConfyDbContext>();

		context.Database.MigrateAsync().GetAwaiter().GetResult();
	}
}
