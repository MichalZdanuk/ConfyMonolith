using Confy.Application.DTO.ConferenceManagement.CreateConference;
using Confy.Shared.Enums;

namespace Confy.LoadTests.Utils;
public static class ConferenceDtoFactory
{
	public static CreateConferenceDto CreateTestDto(string name = "TestConf2025")
	{
		return new CreateConferenceDto(
			Name: name,
			ConferenceLanguage: ConferenceLanguage.English,
			ConferenceLinksDto: new CreateConferenceLinksDto(
				WebsiteUrl: "https://testconf.com",
				FacebookUrl: "https://facebook.com/testconf",
				InstagramUrl: "https://instagram.com/testconf"
			),
			ConferenceDetailsDto: new CreateConferenceDetailsDto(
				StartDate: DateTime.UtcNow.AddDays(30),
				EndDate: DateTime.UtcNow.AddDays(33),
				Description: "A test .NET conference for load testing.",
				IsOnline: false
			),
			AddressDto: new CreateAddressDto(
				City: "Testville",
				Country: "Testland",
				AddressLine: "123 Test Ave",
				ZipCode: "12345"
			)
		);
	}
}
