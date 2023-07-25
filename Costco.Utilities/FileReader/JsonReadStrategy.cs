using System.Text.Json;

namespace Costco.Utilities.FileReader
{
    public class JsonReadStrategy: IReadStrategy
    {
        public string? Target { get; set; }
        public string? ModelAssembly { get; set; }

        public object Execute()
        {
            JsonDocument document = JsonDocument.Parse(File.ReadAllText(Target));
            string typeName = document.RootElement.GetProperty("DataModel").GetString();
            string nameSpace;

            switch (typeName)
            {
                case string str when str.Contains("Config"):
                    {
                        nameSpace = "Costco.Core.ConfigurationModels.";
                        break;
                    }
                default: 
                    {
                        nameSpace = "Costco.TestData.Models.";
                        break;
                    }
            }

            return JsonSerializer.Deserialize(document, Type.GetType(nameSpace + typeName + ", " + ModelAssembly));
        }
    }
}

