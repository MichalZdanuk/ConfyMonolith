namespace Confy.Application.Commands.Registrations.CancelRegistration;
public class CancelRegistrationCommandHandler(IRegistrationService registrationService)
	: IRequestHandler<CancelRegistrationCommand>
{
	public async Task Handle(CancelRegistrationCommand command, CancellationToken cancellationToken)
	{
		await registrationService.CancelRegistrationAsync(command.RegistrationId);
	}
}
