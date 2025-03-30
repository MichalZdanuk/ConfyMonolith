using Confy.Domain.Authentication.Repositories;
using Confy.Domain.ConferenceManagement.Repositories;
using Confy.Infrastructure.Interceptors;
using Confy.Infrastructure.Repositories.Authentication;
using Confy.Infrastructure.Repositories.ConferenceManagement;
using Confy.Shared.UnitOfWork;
using Microsoft.Extensions.DependencyInjection;

namespace Confy.Infrastructure;
public static class DependencyInjection
{
	public static IServiceCollection AddInfrastructure(this IServiceCollection services,
		IConfiguration configuration)
	{
		var connectionString = configuration.GetConnectionString("Database");

		services.AddRepositories();
		services.AddCustomInterceptors();

		services.AddDbContext<ConfyDbContext>((sp, options) =>
		{
			options.AddInterceptors(sp.GetServices<ISaveChangesInterceptor>());
			options.UseSqlServer(connectionString);
		});

		services.AddScoped<IUnitOfWork, ConfyUnitOfWork>();

		return services;
	}

	private static IServiceCollection AddRepositories(this IServiceCollection services)
	{
		services.AddScoped<IUserRepository, UserRepository>();
		services.AddScoped<IPrelegentRepository, PrelegentRepository>();
		services.AddScoped<IConferenceRepository, ConferenceRepository>();
		services.AddScoped<ILectureRepository, LectureRepository>();

		return services;
	}

	private static IServiceCollection AddCustomInterceptors(this IServiceCollection services)
	{
		services.AddScoped<ISaveChangesInterceptor, AuditableEntityInterceptor>();
		services.AddScoped<ISaveChangesInterceptor, DispatchDomainEventsInterceptor>();

		return services;
	}
}
