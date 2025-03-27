namespace Confy.Application.DTO.ConferenceManagement.CreateConference;
public record CreateConferenceDetailsDto(DateTime StartDate, DateTime EndDate, string Description, bool IsOnline);
