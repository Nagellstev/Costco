namespace Costco.Utilities.FileReader
{
    public class FileReader
    {
        public string TargetXmlNode { get; set; } = "TestRunParameters";

        /// <summary>
        /// Checks location provided in path and deserializes the specified file.
        /// Supports xml and json. When working with xml pass the name of the desired node to TargetXmlNode property.  
        /// </summary>
        /// <returns>Contents of the specified file as returnType object.</returns>
        public object Read(string path)
        {
            IReadStrategy strategy;

            if (!File.Exists(path))
            {
                throw new FileNotFoundException("File not found.");
            }

            switch (new FileInfo(path).Extension.ToLower())
            {
                case ".json":
                    {
                        strategy = new JsonReadStrategy();
                        break;
                    }
                default:
                    {
                        throw new NotSupportedException("Unsupported file format.");
                    }
            }

            strategy.Target = path;
            return strategy.Execute();
        }
    }
}
