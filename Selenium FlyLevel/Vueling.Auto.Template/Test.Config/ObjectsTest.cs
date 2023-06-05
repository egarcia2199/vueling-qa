using Flylevel.Auto.Template.Test.Data;

namespace Flylevel.Auto.Template.SetUp
{
    public class ObjectsTest
    {
        LoadScenarioTestCasesConfiguration loadScenarioTestCasesConfiguration = new LoadScenarioTestCasesConfiguration();

        public string CallCase1FromScenarioTestXml(int testCase)
        {
            ScenarioTestCase _testCase = loadScenarioTestCasesConfiguration.GetCase(testCase);
            string case1 = _testCase.Case1;
            return case1;
        }
        public string CallCase2FromScenarioTestXml(int testCase)
        {
            ScenarioTestCase _testCase = loadScenarioTestCasesConfiguration.GetCase(testCase);
            string case2 = _testCase.Case2;
            return case2;
        }
        public int CallCase3FromScenarioTestXml(int testCase)
        {
            ScenarioTestCase _testCase = loadScenarioTestCasesConfiguration.GetCase(testCase);
            int case3 = _testCase.Case3;
            return case3;
        }
    }
}
