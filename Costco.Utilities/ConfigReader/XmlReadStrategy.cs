using System.Xml;
using System.Xml.Serialization;

namespace Costco.Utilities.ConfigReader
{
    internal class XmlReadStrategy<TModel>: IReadStrategy<TModel>
    {
        public string? Target { get; set; }
        public string? TargetNode { get; set; } = "TestRunParameters";

        public TModel Execute()
        {
            using(Stream fileStream = new FileStream(Target, FileMode.Open))
            {
                using (XmlReader reader = XmlReader.Create(fileStream))
                {
                    while (reader.Read())
                    {
                        if (reader.Name == TargetNode)
                        {
                            XmlSerializer serializer = new(typeof(ConfigModel));
                            return (TModel)serializer.Deserialize(reader);
                        }
                    }

                    return default(TModel);
                }
            }
        }
    }
}
