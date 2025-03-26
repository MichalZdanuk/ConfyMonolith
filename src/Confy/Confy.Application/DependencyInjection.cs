using Confy.Application.Behaviors;
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

		services.AddScoped<ICustomAuthService, CustomAuthService>();

		return services;
	}
}
