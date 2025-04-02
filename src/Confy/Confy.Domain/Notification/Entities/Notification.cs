﻿using Confy.Domain.Notification.Enums;

namespace Confy.Domain.Notification.Entities;
public class Notification : Entity
{
	public Guid UserId { get; private set; }
	public Guid ConferenceId { get; private set; }
	public NotificationType NotificationType { get; private set; }
	public NotificationStatus NotificationStatus { get; private set; }
	public string Content { get; private set; } = default!;
	public DateTime? SentAt { get; private set; }

	private Notification()
	{
	}

	private Notification(Guid userId,
		Guid conferenceId,
		NotificationType notificationType,
		string content)
	{
		Id = Guid.NewGuid();
		UserId = userId;
		ConferenceId = conferenceId;
		NotificationType = notificationType;
		NotificationStatus = NotificationStatus.Created;
		Content = content;
		SentAt = null;
	}

	public static Notification Create(Guid userId,
		Guid conferenceId,
		NotificationType notificationType,
		string content)
	{
		return new Notification(userId, conferenceId, notificationType, content);
	}

	public void MarkAsSent()
	{
		SentAt = DateTime.UtcNow;
		NotificationStatus = NotificationStatus.Sent;
	}
}
