﻿namespace Confy.Infrastructure.Configurations.Registration;
public class RegistrationConfiguration
	: BaseEntityConfiguration<Domain.Registration.Entities.Registration>, IEntityTypeConfiguration<Domain.Registration.Entities.Registration>
{
	public override void Configure(EntityTypeBuilder<Domain.Registration.Entities.Registration> builder)
	{
		base.Configure(builder);

		builder.ToTable("Registrations");

		builder.Property(r => r.RegistrationStatus)
			.IsRequired()
			.HasConversion(new RegistrationStatusEnumConverter());

		builder.Property(r => r.UserId)
			.IsRequired();

		builder.Property(r => r.ConferenceId)
			.IsRequired();

		builder.HasOne(r => r.Conference)
			.WithMany()
			.HasForeignKey(r => r.ConferenceId)
			.OnDelete(DeleteBehavior.Restrict);

		builder.HasIndex(r => new { r.UserId, r.ConferenceId })
			.IsUnique();
	}
}
