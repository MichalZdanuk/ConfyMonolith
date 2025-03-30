using Confy.Shared.Enums;

namespace Confy.Domain.Registration.Repositories;
public interface IRegistrationRepository
{
	public Task AddAsync(Registration registration);
	public Task UpdateAsync(Registration registration);
	public Task<Registration?> GetByIdAsync(Guid id);
	public Task<Registration?> GetByUserIdAndConferenceId(Guid userId, Guid conferenceId);
	public Task<IList<Registration>> BrowseByUserIdAsync(Guid userId, bool onlyPending, int pageNumber, int pageSize);
	public Task<IList<Registration>> BrowseByConferenceIdAsync(Guid conferenceId, List<RegistrationStatus> statuses);
	public Task<int> CountByUserIdAsync(Guid userId);
}
