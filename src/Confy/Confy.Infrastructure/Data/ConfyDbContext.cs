using Confy.Domain.Authentication;
using Confy.Domain.ConferenceManagement;
using Confy.Domain.Registration;

namespace Confy.Infrastructure.Data;
public class ConfyDbContext
	: DbContext
{
	private string schema = "confy";

	public ConfyDbContext(DbContextOptions<ConfyDbContext> options)
		: base(options)
	{
	}

	// Authentication
	public DbSet<User> Users { get; set; }

	// ConferenceManagement
	public DbSet<Conference> Conferences { get; set; }
	public DbSet<Lecture> Lectures { get; set; }
	public DbSet<Prelegent> Prelegents { get; set; }
	public DbSet<LectureAssignment> LectureAssignments { get; set; }
	public DbSet<Registration> Registrations { get; set; }

	// Registration

	// Notification


	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
		modelBuilder.HasDefaultSchema(schema);

		base.OnModelCreating(modelBuilder);
	}
}
