using Confy.Domain.Notification.Enum;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Confy.Infrastructure.Converters;
public class NotificationStatusEnumConverter
	: ValueConverter<NotificationStatus, string>
{
	public NotificationStatusEnumConverter() : base(
			v => v.ToString(),
			v => (NotificationStatus)Enum.Parse(typeof(NotificationStatus), v))
	{ }
}
