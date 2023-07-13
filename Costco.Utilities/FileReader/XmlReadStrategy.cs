using System.Xml;
using System.Xml.Serialization;

namespace Costco.Utilities.FileReader
{
    public class XmlReadStrategy: IReadStrategy
    {
        public string? Target { get; set; }
        public string? TargetNode { get; set; }

        public object Execute(Type returnType)
        {
            using(Stream fileStream = new FileStream(Target, FileMode.Open))
            {
                using (XmlReader reader = XmlReader.Create(fileStream))
                {
                    while (reader.Read())
                    {
                        if (reader.Name == TargetNode)
                        {
                            XmlRootAttribute root = new();
                            root.ElementName = TargetNode;
                            XmlSerializer serializer = new(returnType, root);
                            return serializer.Deserialize(reader);
                        }
                    }

                    return null;
                }
            }
        }
    }
}
