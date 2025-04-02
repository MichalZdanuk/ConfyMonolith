using Confy.Domain.ConferenceManagement.Entities;
using Confy.Shared.Enums;

namespace Confy.Domain.ConferenceManagement.Repositories;
public interface IConferenceRepository
{
	Task<Conference?> GetByIdAsync(Guid id);
	Task<List<Conference>> BrowseAsync(int pageNumber, int pageSize, List<ConferenceLanguage> languages,
		bool? isOnline = null, string? country = null, DateTime? startDate = null, DateTime? endDate = null);
	Task<int> CountAsync();
	Task AddAsync(Conference conference);
	Task UpdateAsync(Conference conference);
}
