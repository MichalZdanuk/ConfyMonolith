using Confy.Domain.ConferenceManagement;

namespace Confy.Domain.Repositories.ConferenceManagement;
public interface IConferenceRepository
{
	Task AddAsync(Conference conference);
}
