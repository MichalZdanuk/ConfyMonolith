namespace Confy.LoadTests.Tests;
public class GetConferenceByIdTests
{
	private const int runCount = 3;
	private const int simulationTimeSeconds = 5;
	private const int virtualUsersCount = 50;
	private const string keepConstantMode = "KeepConstant";
	private const string rampingConstantMode = "RampingConstant";

	//[Fact]
	//public void Get_Conference_ById_ConstantLoad()
	//{
	//	var scenarioFactory = new ConfyScenarioFactory();
	//	string scenarioName = $"get_conference_by_id_vu_{virtualUsersCount}_mode_{keepConstantMode}";

	//	var metrics = LoadTestHelper.RunScenarioMultipleTimes(
	//		scenarioName,
	//		virtualUsersCount,
	//		keepConstantMode,
	//		httpClient => scenarioFactory.PrepareGetConferenceScenario(scenarioName, httpClient, Simulation.KeepConstant(virtualUsersCount, TimeSpan.FromSeconds(simulationTimeSeconds))),
	//		runCount);

	//	metrics.Print();
	//}

	//[Fact]
	//public void Get_Conference_ById_RampingConstantLoad()
	//{
	//	var scenarioFactory = new ConfyScenarioFactory();
	//	string scenarioName = $"get_conference_by_id_vu_{virtualUsersCount}_mode_{rampingConstantMode}";

	//	var metrics = LoadTestHelper.RunScenarioMultipleTimes(
	//		scenarioName,
	//		virtualUsersCount,
	//		keepConstantMode,
	//		httpClient => scenarioFactory.PrepareGetConferenceScenario(scenarioName, httpClient, Simulation.KeepConstant(virtualUsersCount, TimeSpan.FromSeconds(simulationTimeSeconds))),
	//		runCount);

	//	metrics.Print();
	//}
}
