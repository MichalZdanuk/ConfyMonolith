using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Confy.LoadTests.Tests;
public class CreateConferenceTests
{
	private const int runCount = 3;
	private const int simulationTimeSeconds = 5;
	private const int virtualUsersCount = 50;
	private const string keepConstantMode = "KeepConstant";
	private const string rampingConstantMode = "RampingConstant";

	[Fact]
	public void Create_Conference_ConstantLoad()
	{
		var scenarioFactory = new ConfyScenarioFactory();
		string scenarioName = $"create_conference_vu_{virtualUsersCount}_mode_{keepConstantMode}";

		var metrics = LoadTestHelper.RunScenarioMultipleTimes(
			scenarioName,
			virtualUsersCount,
			keepConstantMode,
			httpClient => scenarioFactory.PrepareCreateConferenceScenario(scenarioName, httpClient, Simulation.KeepConstant(virtualUsersCount, TimeSpan.FromSeconds(simulationTimeSeconds))),
			runCount);

		metrics.Print();
	}

	[Fact]
	public void Create_Conference_RampingConstantLoad()
	{
		var scenarioFactory = new ConfyScenarioFactory();
		string scenarioName = $"create_conference_vu_{virtualUsersCount}_mode_{rampingConstantMode}";

		var metrics = LoadTestHelper.RunScenarioMultipleTimes(
			scenarioName,
			virtualUsersCount,
			keepConstantMode,
			httpClient => scenarioFactory.PrepareCreateConferenceScenario(scenarioName, httpClient, Simulation.KeepConstant(virtualUsersCount, TimeSpan.FromSeconds(simulationTimeSeconds))),
			runCount);

		metrics.Print();
	}
}
