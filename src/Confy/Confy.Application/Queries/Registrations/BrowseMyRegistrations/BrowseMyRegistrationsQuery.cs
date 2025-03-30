namespace Confy.Application.Queries.Registrations.BrowseMyRegistrations;
public record BrowseMyRegistrationsQuery(PaginationRequest Pagination, bool OnlyPending) : IQuery<PaginationResult<UserRegistrationDto>>;
