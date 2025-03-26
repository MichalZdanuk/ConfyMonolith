using Confy.Domain.ConferenceManagement;

namespace Confy.Domain.Repositories.ConferenceManagement;
public interface IPrelegentRepository
{
	public Task AddAsync(Prelegent prelegent);
}
