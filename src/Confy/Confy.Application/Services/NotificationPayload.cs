namespace Confy.Application.Services;
public record NotificationPayload(string NotificationType, string Email, string Content, DateTime SentAt);
