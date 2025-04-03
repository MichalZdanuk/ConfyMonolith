using Confy.Domain.Notification.Enums;

namespace Confy.Application.Providers;
public interface INotificationTemplateProvider
{
	public string GetNotificationTemplate(NotificationType type);
}
