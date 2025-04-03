using Confy.Domain.Notification.Enums;

namespace Confy.Application.Factories;
public interface INotificationFactory
{
	Domain.Notification.Entities.Notification CreateNotification(Guid userId, Guid conferenceId, NotificationType type, string conferenceName);
	List<Domain.Notification.Entities.Notification> CreateNotifications(IEnumerable<Guid> userIds, Guid conferenceId, NotificationType type, string conferenceName);
}
