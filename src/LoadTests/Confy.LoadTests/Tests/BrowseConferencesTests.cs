namespace Confy.LoadTests.Tests;
public class BrowseConferencesTests
{
	private const int runCount = 3;
	private const int simulationTimeSeconds = 5;
	private const int virtualUsersCount = 50;
	private const string keepConstantMode = "KeepConstant";
	private const string rampingConstantMode = "RampingConstant";

	//[Fact]
	//public void Browse_Conferences_ConstantLoad()
	//{
	//	var scenarioFactory = new ConfyScenarioFactory();
	//	string scenarioName = $"browse_conferences_vu_{virtualUsersCount}_mode_{keepConstantMode}";

	//	var metrics = LoadTestHelper.RunScenarioMultipleTimes(
	//		scenarioName,
	//		virtualUsersCount,
	//		keepConstantMode,
	//		httpClient => scenarioFactory.PrepareBrowseConferencesScenario(scenarioName, httpClient, Simulation.KeepConstant(virtualUsersCount, TimeSpan.FromSeconds(simulationTimeSeconds))),
	//		runCount);

	//	metrics.Print();
	//}

	//[Fact]
	//public void Browse_Conferences_RampingConstantLoad()
	//{
	//	var scenarioFactory = new ConfyScenarioFactory();
	//	string scenarioName = $"browse_conferences_vu_{virtualUsersCount}_mode_{rampingConstantMode}";

	//	var metrics = LoadTestHelper.RunScenarioMultipleTimes(
	//		scenarioName,
	//		virtualUsersCount,
	//		keepConstantMode,
	//		httpClient => scenarioFactory.PrepareBrowseConferencesScenario(scenarioName, httpClient, Simulation.KeepConstant(virtualUsersCount, TimeSpan.FromSeconds(simulationTimeSeconds))),
	//		runCount);

	//	metrics.Print();
	//}
}
