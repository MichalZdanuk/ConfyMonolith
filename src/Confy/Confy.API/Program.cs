var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services
	.AddApiServices(builder.Configuration)
	.AddApplication()
	.AddInfrastructure(builder.Configuration);

builder.Services.AddControllers();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
	await app.InitialiseDatabaseAsync();
}

// Configure the HTTP request pipeline.

app.UseAuthentication();
app.UseAuthorization();
app.UseApiServices();

app.MapControllers();

app.Run();
