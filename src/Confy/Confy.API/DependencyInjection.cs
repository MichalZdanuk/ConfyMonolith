using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;

namespace Confy.API;

public static class DependencyInjection
{
	public static IServiceCollection AddApiServices(this IServiceCollection services, IConfiguration configuration)
	{
		services.AddHealthChecks()
			.AddSqlServer(configuration.GetConnectionString("Database")!);

		return services;
	}

	public static WebApplication UseApiServices(this WebApplication app)
	{
		app.UseHealthChecks("/health",
			new HealthCheckOptions
			{
				ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
			});

		return app;
	}
}
