﻿using Confy.Shared.Seeding;
using System.Text;
using System.Text.Json;

namespace Confy.LoadTests.Utils;
public class ConfyScenarioFactory
{
	private const string BaseUrl = "https://localhost:6068";
	private const string AttendeeJwtToken = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1laWRlbnRpZmllciI6ImE1YWE0MjQ5LWRmNmMtNDlhNC1iZTc3LTExOTA5ZTFlODNhNSIsImh0dHA6Ly9zY2hlbWFzLnhtbHNvYXAub3JnL3dzLzIwMDUvMDUvaWRlbnRpdHkvY2xhaW1zL2VtYWlsYWRkcmVzcyI6InRlc3Q1QHRlc3Q1LmNvbSIsImh0dHA6Ly9zY2hlbWFzLm1pY3Jvc29mdC5jb20vd3MvMjAwOC8wNi9pZGVudGl0eS9jbGFpbXMvcm9sZSI6IkF0dGVuZGVlIiwiZXhwIjoxNzQ4NDY1OTI2LCJpc3MiOiJDb25meU1vbm9saXRoIiwiYXVkIjoiQ29uZnlNb25vbGl0aCJ9.koSWRiWhpnLjdX3KwLA8mfwRYw-JHGKbPimjMJqX8FI";
	private const string HostJwtToken = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1laWRlbnRpZmllciI6IjBlMWMxZDJmLTRiMGQtNGU2OC04OGI0LTQzZDQ2M2FlZTg1YyIsImh0dHA6Ly9zY2hlbWFzLnhtbHNvYXAub3JnL3dzLzIwMDUvMDUvaWRlbnRpdHkvY2xhaW1zL2VtYWlsYWRkcmVzcyI6Im1hcnRpbkBmb3dsZXIuY29tIiwiaHR0cDovL3NjaGVtYXMubWljcm9zb2Z0LmNvbS93cy8yMDA4LzA2L2lkZW50aXR5L2NsYWltcy9yb2xlIjoiSG9zdCIsImV4cCI6MTc0ODQ2NTg1NiwiaXNzIjoiQ29uZnlNb25vbGl0aCIsImF1ZCI6IkNvbmZ5TW9ub2xpdGgifQ.2tRaxeSWVL6Q9JySfV_r6sXkgbO4qI5-JT0RohrBtfg";
	private Guid ConferenceId = SeedConstants.ConferenceIds[1];
	private const int WarmUpDurationSeconds = 3;

	public ScenarioProps PrepareGetConferenceScenario(string scenarioName, HttpClient httpClient, LoadSimulation simulation)
	{
		var url = $"{BaseUrl}/conferences/{ConferenceId}";

		return Scenario.Create(scenarioName, async context =>
		{
			var getConference = await Step.Run("getConference", context, async () =>
			{
				var request = Http.CreateRequest("GET", url)
					.WithHeader("Accept", "application/json")
					.WithHeader("Authorization", $"Bearer {AttendeeJwtToken}");

				var response = await Http.Send(httpClient, request);
				return Response.Ok(response);
			});

			return getConference;
		})
		.WithWarmUpDuration(TimeSpan.FromSeconds(WarmUpDurationSeconds))
		.WithLoadSimulations(simulation);
	}

	public ScenarioProps PrepareBrowseConferencesScenario(string scenarioName, HttpClient httpClient, LoadSimulation simulation)
	{
		var url = $"{BaseUrl}/conferences";

		return Scenario.Create(scenarioName, async context =>
		{
			var browseConferences = await Step.Run("browseConferences", context, async () =>
			{
				var request = Http.CreateRequest("GET", url)
					.WithHeader("Accept", "application/json")
					.WithHeader("Authorization", $"Bearer {AttendeeJwtToken}");

				var response = await Http.Send(httpClient, request);
				return Response.Ok(response);
			});

			return browseConferences;
		})
		.WithWarmUpDuration(TimeSpan.FromSeconds(WarmUpDurationSeconds))
		.WithLoadSimulations(simulation);
	}

	public ScenarioProps PrepareCreateConferenceScenario(string scenarioName, HttpClient httpClient, LoadSimulation simulation)
	{
		var url = $"{BaseUrl}/conferences";

		return Scenario.Create(scenarioName, async context =>
		{
			var createConference = await Step.Run("createConference", context, async () =>
			{
				var dto = ConferenceDtoFactory.PrepareCreateConferenceDto($"Conf_{Guid.NewGuid()}");
				var jsonContent = new StringContent(JsonSerializer.Serialize(dto), Encoding.UTF8, "application/json");

				var request = Http.CreateRequest("POST", url)
					.WithHeader("Accept", "application/json")
					.WithHeader("Authorization", $"Bearer {HostJwtToken}")
					.WithBody(jsonContent);

				var response = await Http.Send(httpClient, request);
				return Response.Ok(response);
			});

			return createConference;
		})
		.WithWarmUpDuration(TimeSpan.FromSeconds(WarmUpDurationSeconds))
		.WithLoadSimulations(simulation);
	}

	public ScenarioProps PrepareUpdateConferenceScenario(string scenarioName, HttpClient httpClient, LoadSimulation simulation)
	{
		var url = $"{BaseUrl}/conferences/{ConferenceId.ToString()}";

		return Scenario.Create(scenarioName, async context =>
		{
			var updateConference = await Step.Run("updateConference", context, async () =>
			{
				var dto = ConferenceDtoFactory.PrepareUpdateConferenceDto();
				var jsonContent = new StringContent(JsonSerializer.Serialize(dto), Encoding.UTF8, "application/json");

				var request = Http.CreateRequest("PUT", url)
					.WithHeader("Accept", "application/json")
					.WithHeader("Authorization", $"Bearer {HostJwtToken}")
					.WithBody(jsonContent);

				var response = await Http.Send(httpClient, request);
				return Response.Ok(response);
			});

			return updateConference;
		})
		.WithWarmUpDuration(TimeSpan.FromSeconds(WarmUpDurationSeconds))
		.WithLoadSimulations(simulation);
	}
}
