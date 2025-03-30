using Confy.Application.Behaviors;
using Confy.Application.Context;
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
			config.AddOpenBehavior(typeof(LoggingBehavior<,>));
			config.AddOpenBehavior(typeof(TransactionalPipelineBehavior<,>));
		});

		services.AddConfyHttpContext();

		services.AddApplicationServices();

		return services;
	}

	private static IServiceCollection AddApplicationServices(this IServiceCollection services)
	{
		services.AddScoped<ICustomAuthService, CustomAuthService>();
		services.AddScoped<IRegistrationService, RegistrationService>();

		return services;
	}
}
