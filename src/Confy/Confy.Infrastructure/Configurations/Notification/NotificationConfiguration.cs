namespace Confy.Infrastructure.Configurations.Notification;
public class NotificationConfiguration
	: BaseEntityConfiguration<Domain.Notification.Entities.Notification>, IEntityTypeConfiguration<Domain.Notification.Entities.Notification>
{
	public override void Configure(EntityTypeBuilder<Domain.Notification.Entities.Notification> builder)
	{
		base.Configure(builder);

		builder.ToTable("Notifications");

		builder.Property(n => n.NotificationStatus)
			.HasConversion(new NotificationStatusEnumConverter())
			.IsRequired();

		builder.Property(n => n.NotificationType)
			.HasConversion(new NotificationTypeEnumConverter())
			.IsRequired();

		builder.Property(n => n.Content)
			.IsRequired();

		builder.Property(n => n.SentAt)
			.IsRequired(false);

		builder.Property(n => n.ConferenceId)
			.IsRequired();
	}
}
