namespace Confy.LoadTests.Tests;
public class ConfyMonolithTests
{
	private const int runCount = 3;
	private const int simulationTimeSeconds = 5;
	private const int virtualUsersCount = 50;
	private const string keepConstantMode = "KeepConstant";
	private const string rampingConstantMode = "RampingConstant";

	[Fact]
	public void get_product_constant_load()
	{
		var scenarioFactory = new ConfyScenarioFactory();
		string scenarioName = $"get_product_by_id_vu_{virtualUsersCount}_mode_{keepConstantMode}";

		var metrics = LoadTestHelper.RunScenarioMultipleTimes(
			scenarioName,
			virtualUsersCount,
			keepConstantMode,
			httpClient => scenarioFactory.PrepareGetConferenceScenario(scenarioName, httpClient, Simulation.KeepConstant(virtualUsersCount, TimeSpan.FromSeconds(simulationTimeSeconds))),
			runCount);

		metrics.Print();
	}
}
