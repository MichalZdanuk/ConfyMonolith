namespace Confy.Domain.Notification.ValueObjects;
public record NotificationPayload(string NotificationType, string Email, string Content, DateTime SentAt);
