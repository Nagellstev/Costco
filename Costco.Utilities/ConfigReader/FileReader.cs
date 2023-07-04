namespace Costco.Utilities.ConfigReader
{
    public static class FileReader<TModel>
    {
        /// <summary>
        /// Checks location provided in path and deserializes the specified file.
        /// Supports xml and json.
        /// </summary>
        /// <returns>Contents of the specified file as TModel object.</returns>
        public static TModel Read(string path)
        {
            IReadStrategy<TModel> strategy;

            if (!File.Exists(path))
            {
                throw new FileNotFoundException("File not found.");
            }

            switch (new FileInfo(path).Extension.ToLower())
            {
                case ".runsettings":
                case ".xml":
                    {
                        strategy = new XmlReadStrategy<TModel>();
                        break;
                    }
                case ".json":
                    {
                        strategy = new JsonReadStrategy<TModel>();
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
