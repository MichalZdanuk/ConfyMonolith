using Confy.Application.DTO.ConferenceManagement.GetConferenceById;

namespace Confy.Application.Queries.ConferenceManagement.GetConferenceById;
public record GetConferenceByIdQuery(Guid ConferenceId) : IQuery<GetConferenceDto>;
