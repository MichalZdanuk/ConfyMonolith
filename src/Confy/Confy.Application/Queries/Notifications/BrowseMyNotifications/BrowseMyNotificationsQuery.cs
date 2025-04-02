using Confy.Application.DTO.Notifications.BrowseMyNotifications;

namespace Confy.Application.Queries.Notifications.BrowseMyNotifications;
public record BrowseMyNotificationsQuery(PaginationRequest Pagination) : IQuery<PaginationResult<NotificationDto>>;
