using Confy.Application.Data;
using Confy.Domain.Authentication;

namespace Confy.Infrastructure.Data;
public class ConfyDbContext
	: DbContext, IApplicationDbContext
{
	private string schema = "confy";

	public ConfyDbContext(DbContextOptions<ConfyDbContext> options)
		: base(options)
	{
	}

	public DbSet<User> Users { get; set; }

	public async Task<int> SaveChangesAsync()
	{
		return await base.SaveChangesAsync();
	}

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
		modelBuilder.HasDefaultSchema(schema);

		base.OnModelCreating(modelBuilder);
	}
}
