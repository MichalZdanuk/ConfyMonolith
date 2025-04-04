using Confy.Application.Factories;
using Confy.Domain.Authentication.Repositories;
using Confy.Domain.ConferenceManagement.Events;
using Confy.Domain.Notification.Enums;
using Confy.Domain.Notification.Repositories;
using Confy.Domain.Registration.Repositories;
using Confy.Shared.UnitOfWork;
using Microsoft.Extensions.Logging;

namespace Confy.Application.EventHandlers;
public class ConferenceUpdatedEventHandler(INotificationFactory notificationFactory,
	INotificationSenderService notificationSenderService,
	INotificationRepository notificationRepository,
	IUserRepository userRepository,
	IRegistrationRepository registrationRepository,
	ILogger<ConferenceUpdatedEventHandler> logger,
	IUnitOfWork unitOfWork)
		: INotificationHandler<ConferenceUpdatedEvent>
{
	public async Task Handle(ConferenceUpdatedEvent domainEvent, CancellationToken cancellationToken)
	{
		logger.LogInformation("Domain event handled: {domainEvent}", domainEvent.GetType().Name);

		var usersToNotify = await registrationRepository.GetUserIdsByConferenceIdWithActiveRegistrationsAsync(domainEvent.ConferenceId);

		if (usersToNotify.Any())
		{
			var userEmails = await userRepository.GetUserEmailsByIdsAsync(usersToNotify);

			var notifications = notificationFactory.CreateNotifications(
				usersToNotify,
				domainEvent.ConferenceId,
				NotificationType.ConferenceUpdated,
				domainEvent.ConferenceName);

			await notificationRepository.AddRangeAsync(notifications);

			var notificationPayloads = notifications
				.Where(n => userEmails.ContainsKey(n.UserId))
				.Select(n => n.MapToPayload(userEmails[n.UserId]))
				.ToList();

			await notificationSenderService.SendNotificationsAsync(notificationPayloads);

			await unitOfWork.SaveChangesAsync();
		}
	}
}
