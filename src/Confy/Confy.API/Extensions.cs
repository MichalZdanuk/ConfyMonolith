using Confy.Infrastructure.Data;
using Confy.Infrastructure.Seeding;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Confy.API;

public static class Extensions
{
	public static async Task InitialiseDatabaseAsync(this WebApplication app)
	{
		using var scope = app.Services.CreateScope();

		var context = scope.ServiceProvider.GetRequiredService<ConfyDbContext>();

		context.Database.MigrateAsync().GetAwaiter().GetResult();

		await SeedAsync(context);
	}

	public static IServiceCollection AddAuthenticationAndAuthorization(this IServiceCollection services, IConfiguration configuration)
	{
		services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
			.AddJwtBearer(options =>
			{
				options.Authority = configuration["Jwt:Authority"];
				options.Audience = configuration["Jwt:Audience"];
				options.RequireHttpsMetadata = false;
				options.TokenValidationParameters = new TokenValidationParameters
				{
					ValidateIssuer = false,
					ValidateAudience = true,
					ValidateIssuerSigningKey = true,
					IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]!))
				};
			});

		services.AddAuthorization();

		return services;
	}

	private static async Task SeedAsync(ConfyDbContext confyDbContext)
	{
		await AdminUserSeeder.SeedAdminUserAsync(confyDbContext);
	}
}
