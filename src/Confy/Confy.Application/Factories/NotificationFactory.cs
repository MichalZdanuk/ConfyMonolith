using Confy.Application.Providers;
using Confy.Domain.Notification.Enums;

namespace Confy.Application.Factories;
public class NotificationFactory(INotificationTemplateProvider notificationTemplateProvider)
	: INotificationFactory
{
	public Domain.Notification.Entities.Notification CreateNotification(Guid userId, Guid conferenceId, NotificationType type, string conferenceName)
	{
		var message = notificationTemplateProvider.GetNotificationTemplate(type)
			.Replace("{ConferenceName}", conferenceName);

		var notification = Domain.Notification.Entities.Notification.Create(userId, conferenceId, type, message);
		notification.MarkAsSent();

		return notification;
	}

	public List<Domain.Notification.Entities.Notification> CreateNotifications(IEnumerable<Guid> userIds, Guid conferenceId, NotificationType type, string conferenceName)
	{
		var notifications = new List<Domain.Notification.Entities.Notification>();
		var message = notificationTemplateProvider.GetNotificationTemplate(type)
			.Replace("{ConferenceName}", conferenceName);

		foreach (var userId in userIds)
		{
			var notification = Domain.Notification.Entities.Notification.Create(userId, conferenceId, type, message);
			notification.MarkAsSent();
			notifications.Add(notification);
		}

		return notifications;
	}
}
