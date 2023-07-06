using System.Xml.Serialization;

namespace Costco.Utilities.FileReader
{
    [XmlRoot]
    public class ConfigModel
    {
        [XmlElement]
        public string Browser { get; init; }

        [XmlElement]
        public string TestDataLocation { get; init; }
    }
}
