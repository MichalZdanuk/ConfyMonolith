using Confy.Application.Services;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Confy.Application;
public static class DependencyInjection
{
	public static IServiceCollection AddApplication(this IServiceCollection services)
	{
		services.AddMediatR(config =>
		{
			config.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
		});

		services.AddScoped<ICustomAuthService, CustomAuthService>();

		return services;
	}
}
