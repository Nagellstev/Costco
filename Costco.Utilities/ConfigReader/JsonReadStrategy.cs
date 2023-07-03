using System.Text.Json;

namespace Costco.Utilities.ConfigReader
{
    internal class JsonReadStrategy: IReadStrategy
    {
        public string? Target { get; set; }

        public ConfigModel Execute()
        {
            return JsonSerializer.Deserialize<ConfigModel>(File.ReadAllText(Target));
        }
    }
}

