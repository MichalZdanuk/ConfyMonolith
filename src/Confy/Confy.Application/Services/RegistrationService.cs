using Confy.Domain.ConferenceManagement.Exceptions;
using Confy.Domain.ConferenceManagement.Repositories;
using Confy.Domain.Registration;
using Confy.Domain.Registration.Repositories;

namespace Confy.Application.Services;
public class RegistrationService(IContext context,
	IConferenceRepository conferenceRepository,
	IRegistrationRepository registrationRepository)
	: IRegistrationService
{

	public async Task<Guid> RegisterUserForConferenceAsync(Guid conferenceId)
	{
		var userId = context.UserId;

		var conference = await conferenceRepository.GetByIdAsync(conferenceId);

		if (conference is null)
		{
			throw new ConferenceNotFoundException(conferenceId);
		}

		var registration = await registrationRepository.GetByUserIdAndConferenceId(userId, conferenceId);

		if (registration is null)
		{
			var newRegistration = Registration.Create(userId, conferenceId, conference);
			await registrationRepository.AddAsync(newRegistration);

			return newRegistration.Id;
		}
		else
		{
			registration.ReRegister();
			await registrationRepository.UpdateAsync(registration);

			return registration.Id;
		}
	}
}
