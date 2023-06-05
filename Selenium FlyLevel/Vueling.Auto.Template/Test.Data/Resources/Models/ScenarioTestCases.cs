using System.Xml.Serialization;

namespace Flylevel.Auto.Template.Test.Data
{
    [XmlRoot("ScenarioTestCase")]
    public class ScenarioTestCase
    {
        [XmlElement(ElementName = "id")]
        public int Id { get; set; }

        [XmlElement(ElementName = "case1")]
        public string Case1 { get; set; }

        [XmlElement(ElementName = "case2")]
        public string Case2 { get; set; }

        [XmlElement(ElementName = "case3")]
        public int Case3 { get; set; }
    }
}