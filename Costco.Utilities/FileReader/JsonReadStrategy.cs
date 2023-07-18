using System.Text.Json;

namespace Costco.Utilities.FileReader
{
    public class JsonReadStrategy: IReadStrategy
    {
        public string? Target { get; set; }

        public object Execute()
        {
            JsonDocument document = JsonDocument.Parse(File.ReadAllText(Target));
            Type returnType = Type.GetType("Costco.Utilities.FileReader.Models." + 
                document.RootElement.GetProperty("DataModel").GetString());            
            return JsonSerializer.Deserialize(document, returnType);
        }
    }
}

