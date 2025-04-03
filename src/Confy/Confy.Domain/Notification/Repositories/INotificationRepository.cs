namespace Confy.Domain.Notification.Repositories;
public interface INotificationRepository
{
	public Task<List<Entities.Notification>> BrowseByUserIdAsync(Guid userId, int pageNumber, int pageSize);
	public Task<int> CountByUserIdAsync(Guid userId);
	public Task AddAsync(Entities.Notification notification);
}
