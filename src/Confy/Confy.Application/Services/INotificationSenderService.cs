using Confy.Domain.Notification.ValueObjects;

namespace Confy.Application.Services;
public interface INotificationSenderService
{
	public Task SendNotificationAsync(NotificationPayload notificationPayload);
	public Task SendNotificationsAsync(IEnumerable<NotificationPayload> notificationPayloads);
}
