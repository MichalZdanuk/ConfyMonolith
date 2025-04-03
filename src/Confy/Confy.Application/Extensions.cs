using Confy.Domain.Notification.ValueObjects;

namespace Confy.Application;
public static class Extensions
{
	public static NotificationPayload MapToPayload(this Domain.Notification.Entities.Notification notification, string email)
		=> new NotificationPayload(notification.NotificationType.ToString(), email, notification.Content, notification.SentAt ?? DateTime.UtcNow);
}
