﻿namespace Confy.Application.DTO.ConferenceManagement.GetConferenceById;
public record GetConferenceDto(string name,
	string language,
	ConferenceLinksDto ConferenceLinks,
	ConferenceDetailsDto ConferenceDetails,
	AddressDto Address,
	IReadOnlyList<LectureDto> Lectures);
