namespace Confy.LoadTests.Tests;
public class BrowseConferencesTests
{
	[Fact]
	public void Browse_Conferences_ConstantLoad()
	{
		var scenarioFactory = new ConfyScenarioFactory();
		string scenarioName = $"browse_conferences_vu_{LoadTestSettings.VirtualUsersCount}_mode_{LoadTestSettings.KeepConstantMode}";

		var metrics = LoadTestHelper.RunScenarioMultipleTimes(
			scenarioName,
			LoadTestSettings.VirtualUsersCount,
			LoadTestSettings.KeepConstantMode,
			httpClient => scenarioFactory.PrepareBrowseConferencesScenario(scenarioName,
				httpClient,
				Simulation.KeepConstant(LoadTestSettings.VirtualUsersCount, TimeSpan.FromSeconds(LoadTestSettings.SimulationTimeSeconds))),
			LoadTestSettings.RunCount);

		metrics.Print();
	}

	[Fact]
	public void Browse_Conferences_RampingConstantLoad()
	{
		var scenarioFactory = new ConfyScenarioFactory();
		string scenarioName = $"browse_conferences_vu_{LoadTestSettings.VirtualUsersCount}_mode_{LoadTestSettings.RampingConstantMode}";

		var metrics = LoadTestHelper.RunScenarioMultipleTimes(
			scenarioName,
			LoadTestSettings.VirtualUsersCount,
			LoadTestSettings.KeepConstantMode,
			httpClient => scenarioFactory.PrepareBrowseConferencesScenario(scenarioName,
				httpClient,
				Simulation.KeepConstant(LoadTestSettings.VirtualUsersCount, TimeSpan.FromSeconds(LoadTestSettings.SimulationTimeSeconds))),
			LoadTestSettings.RunCount);

		metrics.Print();
	}
}
