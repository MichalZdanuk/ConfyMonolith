using Confy.Application.DTO.Notifications.BrowseMyNotifications;
using Confy.Domain.Notification.Repositories;

namespace Confy.Application.Queries.Notifications.BrowseMyNotifications;
public class BrowseMyNotificationsQueryHandler(IContext context,
	INotificationRepository notificationRepository)
	: IRequestHandler<BrowseMyNotificationsQuery, PaginationResult<NotificationDto>>
{
	public async Task<PaginationResult<NotificationDto>> Handle(BrowseMyNotificationsQuery query, CancellationToken cancellationToken)
	{
		var notifications = await notificationRepository.BrowseByUserIdAsync(context.UserId,
			query.Pagination.PageNumber,
			query.Pagination.PageSize);

		var notificationDtos = notifications.Select(n => new NotificationDto(
				n.Id,
				n.Content,
				n.NotificationType.ToString(),
				n.CreationDate
			));

		var notificationsCount = await notificationRepository.CountByUserIdAsync(context.UserId);

		return new PaginationResult<NotificationDto>(query.Pagination.PageNumber,
			query.Pagination.PageSize,
			notificationsCount,
			notificationDtos);
	}
}
