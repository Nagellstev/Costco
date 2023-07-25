namespace Costco.Utilities.FileReader
{
    public class FileReader
    {
        /// <summary>
        /// Checks location provided in path and deserializes the specified file.
        /// Supports xml and json. When working with xml pass the name of the desired node to TargetXmlNode property.  
        /// </summary>
        /// <returns>Contents of the specified file as returnType object.</returns>
        public object Read(string path, string assembyName)
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
            strategy.ModelAssembly = assembyName;
            return strategy.Execute();
        }
    }
}
