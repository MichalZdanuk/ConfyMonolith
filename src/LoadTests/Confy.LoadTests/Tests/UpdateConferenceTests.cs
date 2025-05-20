namespace Confy.LoadTests.Tests;
public class UpdateConferenceTests
{
	private const int runCount = 3;
	private const int simulationTimeSeconds = 5;
	private const int virtualUsersCount = 50;
	private const string keepConstantMode = "KeepConstant";
	private const string rampingConstantMode = "RampingConstant";

	[Fact]
	public void Update_Conference_ConstantLoad()
	{
		var scenarioFactory = new ConfyScenarioFactory();
		string scenarioName = $"update_conference_vu_{virtualUsersCount}_mode_{keepConstantMode}";

		var metrics = LoadTestHelper.RunScenarioMultipleTimes(
			scenarioName,
			virtualUsersCount,
			keepConstantMode,
			httpClient => scenarioFactory.PrepareUpdateConferenceScenario(scenarioName, httpClient, Simulation.KeepConstant(virtualUsersCount, TimeSpan.FromSeconds(simulationTimeSeconds))),
			runCount);

		metrics.Print();
	}

	[Fact]
	public void Update_Conference_RampingConstantLoad()
	{
		var scenarioFactory = new ConfyScenarioFactory();
		string scenarioName = $"update_conference_vu_{virtualUsersCount}_mode_{rampingConstantMode}";

		var metrics = LoadTestHelper.RunScenarioMultipleTimes(
			scenarioName,
			virtualUsersCount,
			keepConstantMode,
			httpClient => scenarioFactory.PrepareUpdateConferenceScenario(scenarioName, httpClient, Simulation.KeepConstant(virtualUsersCount, TimeSpan.FromSeconds(simulationTimeSeconds))),
			runCount);

		metrics.Print();
	}
}
