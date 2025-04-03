﻿using Confy.Domain.Notification.ValueObjects;
using Microsoft.Extensions.Logging;

namespace Confy.Application.Services;
public class NotificationSenderService(ILogger<NotificationSenderService> logger)
	: INotificationSenderService
{
	public async Task SendNotificationAsync(NotificationPayload notificationPayload)
	{
		logger.LogInformation($"[MOCKED] successfully sent notification (type: {notificationPayload.NotificationType}) for: {notificationPayload.Email} with content: `{notificationPayload.Content}` at [{notificationPayload.SentAt}]");

		await Task.CompletedTask;
	}

	public async Task SendNotificationsAsync(IEnumerable<NotificationPayload> notificationPayloads)
	{
		foreach (var payload in notificationPayloads)
		{
			logger.LogInformation($"[MOCKED] successfully sent notification (type: {payload.NotificationType}) for: {payload.Email} with content: `{payload.Content}` at [{payload.SentAt}]");
		}

		await Task.CompletedTask;
	}
}
