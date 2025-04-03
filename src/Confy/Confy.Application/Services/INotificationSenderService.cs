using Confy.Domain.Notification.ValueObjects;

namespace Confy.Application.Services;
public interface INotificationSenderService
{
	public Task SendNotification(NotificationPayload notificationPayload);
	public Task SendNotifications(IEnumerable<NotificationPayload> notificationPayloads);
}
