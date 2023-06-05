using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using NUnit.Framework;


namespace Abstracta.Auto.Template.Test.Data
{
    class LoadScenarioTestCasesConfiguration
    {
        public List<ScenarioTestCase> _configScenarioTestCases;

        public LoadScenarioTestCasesConfiguration()
        {
            XmlRootAttribute xRoot = new XmlRootAttribute();
            xRoot.ElementName = "ScenarioTestCases";
            XmlSerializer serializerScenarioTestCases = new XmlSerializer(typeof(List<ScenarioTestCase>), xRoot);
            using (FileStream file = File.OpenRead(TestContext.CurrentContext.TestDirectory + @"\Test.Data\Resources\XML\ScenarioTestCases.xml"))
            {
                _configScenarioTestCases = (List<ScenarioTestCase>)serializerScenarioTestCases.Deserialize(file);
            }
        }

        public ScenarioTestCase GetCase(int TestCase)
        {
            ScenarioTestCase tcase;
            tcase = _configScenarioTestCases.Find(x => int.Equals(x.Id, TestCase));
            return tcase;
        }
    }
}