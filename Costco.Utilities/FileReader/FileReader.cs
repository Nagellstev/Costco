namespace Costco.Utilities.FileReader
{
    public class FileReader
    {
        /// <summary>
        /// Checks location provided in path and deserializes the specified file to the class
        /// the name of which should be located in DataModel field of the file. Supports json.
        /// </summary>
        /// <param name="path">Absolute bath to the file.</param>
        /// <param name="assembyName">Name of the assemly desired model is belonging to.</param>
        /// <returns>Contents of the specified file as the specified object model.</returns>

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
