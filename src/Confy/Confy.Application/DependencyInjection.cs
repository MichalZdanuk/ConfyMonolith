using Confy.Application.Behaviors;
using Confy.Application.Context;
using Confy.Application.Factories;
using Confy.Application.Providers;
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
		services.AddFactories();
		services.AddProviders();

		return services;
	}

	private static IServiceCollection AddApplicationServices(this IServiceCollection services)
	{
		services.AddScoped<ICustomAuthService, CustomAuthService>();
		services.AddScoped<IRegistrationService, RegistrationService>();
		services.AddScoped<INotificationSenderService, NotificationSenderService>();

		return services;
	}

	private static IServiceCollection AddFactories(this IServiceCollection services)
	{
		services.AddScoped<INotificationFactory, NotificationFactory>();

		return services;
	}

	private static IServiceCollection AddProviders(this IServiceCollection services)
	{
		services.AddScoped<INotificationTemplateProvider, NotificationTemplateProvider>();

		return services;
	}
}
