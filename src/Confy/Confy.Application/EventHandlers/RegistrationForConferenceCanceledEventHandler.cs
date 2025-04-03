using Confy.Application.Exceptions;
using Confy.Application.Factories;
using Confy.Domain.Authentication.Repositories;
using Confy.Domain.Notification.Repositories;
using Confy.Domain.Registration.Events;
using Microsoft.Extensions.Logging;

namespace Confy.Application.EventHandlers;
public class RegistrationForConferenceCanceledEventHandler(INotificationRepository notificationRepository,
	IUserRepository userRepository,
	INotificationFactory notificationFactory,
	INotificationSenderService notificationSenderService,
	ILogger<RegistrationForConferenceCanceledEventHandler> logger)
	: INotificationHandler<RegistrationForConferenceCanceledEvent>
{
	public async Task Handle(RegistrationForConferenceCanceledEvent domainEvent, CancellationToken cancellationToken)
	{
		logger.LogInformation("Domain event handled: {domainEvent}", domainEvent.GetType().Name);

		var user = await userRepository.GetByIdAsync(domainEvent.UserId);

		if (user is null)
		{
			throw new UserNotFoundException(domainEvent.UserId);
		}

		var notification = notificationFactory.CreateNotification(domainEvent.UserId,
			domainEvent.ConferenceId,
			Domain.Notification.Enums.NotificationType.RegistrationCanceled,
			domainEvent.ConferenceName);

		await notificationRepository.AddAsync(notification);

		var notificationPayload = notification.MapToPayload(user.Email);

		await notificationSenderService.SendNotification(notificationPayload);
	}
}
