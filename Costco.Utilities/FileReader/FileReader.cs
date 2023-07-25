namespace Costco.Utilities.FileReader
{
    public class FileReader
    {
        /// <summary>
        /// Checks location provided in path and deserializes the specified file. Supports json.
        /// </summary>
        /// <param name="path"></param>
        /// <param name="assembyName"></param>
        /// <returns>Contents of the specified file as an object model </returns>
        /// <exception cref="FileNotFoundException"></exception>
        /// <exception cref="NotSupportedException"></exception>
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
