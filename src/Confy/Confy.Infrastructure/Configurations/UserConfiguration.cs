using Confy.Domain.Authentication;
using Confy.Infrastructure.Converters;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Confy.Infrastructure.Configurations;
public class UserConfiguration : BaseEntityConfiguration<User>,
	IEntityTypeConfiguration<User>
{
	public override void Configure(EntityTypeBuilder<User> builder)
	{
		base.Configure(builder);

		builder.ToTable("Users");

		builder.Property(u => u.Email)
			.IsRequired();

		builder.Property(u => u.PasswordHash)
			.IsRequired();

		builder.Property(u => u.UserRole)
			.IsRequired()
			.HasConversion(new UserRoleEnumConverter());
	}
}
