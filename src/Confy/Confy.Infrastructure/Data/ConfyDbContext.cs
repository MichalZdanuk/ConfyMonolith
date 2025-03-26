using Confy.Domain.Authentication;

namespace Confy.Infrastructure.Data;
public class ConfyDbContext
	: DbContext
{
	private string schema = "confy";

	public ConfyDbContext(DbContextOptions<ConfyDbContext> options)
		: base(options)
	{
	}

	public DbSet<User> Users { get; set; }

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
		modelBuilder.HasDefaultSchema(schema);

		base.OnModelCreating(modelBuilder);
	}
}
