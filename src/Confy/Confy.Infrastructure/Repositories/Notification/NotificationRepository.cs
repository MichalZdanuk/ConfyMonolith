using Confy.Domain.Notification.Repositories;

namespace Confy.Infrastructure.Repositories.Notification;
public class NotificationRepository(ConfyDbContext context)
	: INotificationRepository
{
	public Task<List<Domain.Notification.Entities.Notification>> BrowseByUserIdAsync(Guid userId, int pageNumber, int pageSize)
	{
		var notificationsQuery = context.Notifications
			.Where(n => n.UserId == userId);

		return notificationsQuery
			.OrderByDescending(n => n.CreationDate)
			.Skip((pageNumber - 1) * pageSize)
			.Take(pageSize)
			.ToListAsync();
	}

	public async Task<int> CountByUserIdAsync(Guid userId)
	{
		return await context.Notifications.CountAsync(n => n.UserId == userId);
	}
}
