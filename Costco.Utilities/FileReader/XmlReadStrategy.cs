using System.Xml;
using System.Xml.Serialization;

namespace Costco.Utilities.FileReader
{
    public class XmlReadStrategy<TModel>: IReadStrategy<TModel>
    {
        public string? Target { get; set; }
        public string? TargetNode { get; set; }

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
                            XmlRootAttribute root = new();
                            root.ElementName = TargetNode;
                            XmlSerializer serializer = new(typeof(TModel), root);
                            return (TModel)serializer.Deserialize(reader);
                        }
                    }

                    return default(TModel);
                }
            }
        }
    }
}
