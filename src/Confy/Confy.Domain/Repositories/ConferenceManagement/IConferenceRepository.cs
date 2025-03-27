using Confy.Domain.ConferenceManagement;

namespace Confy.Domain.Repositories.ConferenceManagement;
public interface IConferenceRepository
{
	Task<Conference?> GetByIdAsync(Guid id);
	Task AddAsync(Conference conference);
}
