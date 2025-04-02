using Confy.Domain.ConferenceManagement.Entities;

namespace Confy.Infrastructure.Configurations.ConferenceManagement;
public class LectureAssignmentConfiguration
	: BaseEntityConfiguration<LectureAssignment>,
	IEntityTypeConfiguration<LectureAssignment>
{
	public override void Configure(EntityTypeBuilder<LectureAssignment> builder)
	{
		base.Configure(builder);

		builder.ToTable("LectureAssignments");

		builder.Property(la => la.LectureId)
			.IsRequired();

		builder.Property(la => la.PrelegentId)
			.IsRequired();
	}
}
