using Confy.Application.DTO.ConferenceManagement.BrowseConferences;

namespace Confy.Application.Queries.ConferenceManagement.BrowseConferences;
public record BrowseConferencesQuery(PaginationRequest Pagination) : IQuery<PaginationResult<ConferenceDto>>;
