using System.Xml.Serialization;

namespace Costco.Utilities.ConfigReader
{
    [XmlRoot]
    public class ConfigModel
    {
        [XmlElement]
        public string Browser { get; init; }

        [XmlArray("BrowserParameters")]
        [XmlArrayItem("value")]
        public string[] BrowserParameters { get; init; }

        [XmlElement]
        public string BrowserTimeoutSeconds { get; init; }

        [XmlElement]
        public string TestDataLocation { get; init; }
    }
}
