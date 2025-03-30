namespace Confy.Application.Commands.Registrations.AddRegistration;
public record AddRegistrationCommand(Guid ConferenceId) : ICommand<Guid>;
