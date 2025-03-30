namespace Confy.Domain.Registration.Repositories;
public interface IRegistrationRepository
{
	public Task AddAsync(Registration registration);
	public Task UpdateAsync(Registration registration);
	public Task<Registration?> GetByUserIdAndConferenceId(Guid userId, Guid conferenceId);
}
