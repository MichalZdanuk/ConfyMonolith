namespace Confy.Application.DTO.ConferenceManagement.GetConferenceById;
public record ConferenceDetailsDto(DateTime StartDate, DateTime EndDate, string Description, bool IsOnline);
