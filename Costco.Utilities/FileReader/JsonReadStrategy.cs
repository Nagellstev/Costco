using System.Text.Json;

namespace Costco.Utilities.FileReader
{
    public class JsonReadStrategy<TModel>: IReadStrategy<TModel>
    {
        public string? Target { get; set; }

        public TModel Execute()
        {            
            return JsonSerializer.Deserialize<TModel>(File.ReadAllText(Target));

        }
    }
}

