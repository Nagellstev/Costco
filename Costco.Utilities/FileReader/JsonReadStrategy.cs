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
            return JsonSerializer.Deserialize(document, Type.GetType(ModelAssembly));
        }
    }
}

