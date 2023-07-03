using System.Xml.Serialization;

namespace Costco.Utilities.ConfigReader
{
    public class ConfigModel
    {
        [XmlElement]
        public string Browser { get; set; }

        [XmlArray("BrowserParameters")]
        [XmlArrayItem("value")]
        public string[] BrowserParameters { get; set; }

        [XmlElement]
        public string TestDataLocation { get; set; }
    }
}
