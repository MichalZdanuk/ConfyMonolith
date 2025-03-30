namespace Confy.Application.Commands.Registrations.CancelRegistration;
public record CancelRegistrationCommand(Guid RegistrationId) : ICommand;
