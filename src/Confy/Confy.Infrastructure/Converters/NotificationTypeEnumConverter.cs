using Confy.Domain.Notification.Enum;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Confy.Infrastructure.Converters;
public class NotificationTypeEnumConverter
	: ValueConverter<NotificationType, string>
{
	public NotificationTypeEnumConverter() : base(
			v => v.ToString(),
			v => (NotificationType)Enum.Parse(typeof(NotificationType), v))
	{ }
}
