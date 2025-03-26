﻿using Confy.Domain.Authentication;

namespace Confy.Infrastructure.Configurations.Authentication;
public class UserConfiguration : BaseEntityConfiguration<User>,
	IEntityTypeConfiguration<User>
{
	public override void Configure(EntityTypeBuilder<User> builder)
	{
		base.Configure(builder);

		builder.ToTable("Users");

		builder.Property(u => u.Email)
			.IsRequired();

		builder.Property(u => u.Bio)
			.IsRequired(false);

		builder.Property(u => u.PasswordHash)
			.IsRequired();

		builder.Property(u => u.UserRole)
			.IsRequired()
			.HasConversion(new UserRoleEnumConverter());
	}
}
