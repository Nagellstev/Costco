using System.Text.Json;

namespace Costco.Utilities.FileReader
{
    public class JsonReadStrategy: IReadStrategy
    {
        public string? Target { get; set; }

        public object Execute(Type returnType)
        {            
            return JsonSerializer.Deserialize(File.ReadAllText(Target), returnType);

        }
    }
}

