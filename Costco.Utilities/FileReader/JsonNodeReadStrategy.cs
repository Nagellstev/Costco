using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Costco.Utilities.FileReader
{
    public class JsonNodeReadStrategy : IReadStrategy
    {
        public string? Target { get; set; }
        public string? ModelAssembly { get; set; }
        public string? Node  { get; set; }

        public object Execute()
        {
            JsonDocument document = JsonDocument.Parse(File.ReadAllText(Target));
            return document.RootElement.GetProperty(Node).Deserialize(Type.GetType(ModelAssembly));
        }
    }
}
