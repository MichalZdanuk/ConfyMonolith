using Confy.Application.DTO.ConferenceManagement.BrowseConferences;
using Confy.Shared.Enums;

namespace Confy.Application.Queries.ConferenceManagement.BrowseConferences;
public record BrowseConferencesQuery(PaginationRequest Pagination, List<ConferenceLanguage> Languages,
	bool? IsOnline = null, string? Country = null,
	DateTime? StartDate = null, DateTime? EndDate = null) : IQuery<PaginationResult<ConferenceDto>>;
