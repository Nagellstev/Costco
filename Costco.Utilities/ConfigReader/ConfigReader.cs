namespace Costco.Utilities.ConfigReader
{
    public static class ConfigReader
    {
        /// <summary>
        /// Reads value provided in "config" environtment variable and deserializes the specified file.
        /// Supports xml and json.
        /// </summary>
        /// <returns>ConfigModel object.</returns>
        public static ConfigModel Read()
        {
            IReadStrategy strategy;
            string? path = Environment.GetEnvironmentVariable("config");

            if (!File.Exists(path))
            {
                throw new FileNotFoundException("Config file not found.");
            }

            switch (new FileInfo(path).Extension.ToLower())
            {
                case ".runsettings":
                case ".xml":
                    {
                        strategy = new XmlReadStrategy();
                        break;
                    }
                case ".json":
                    {
                        strategy = new JsonReadStrategy();
                        break;
                    }
                default:
                    {
                        throw new NotSupportedException("Unsupported config file format.");
                    }
            }

            strategy.Target = path;
            return strategy.Execute();            
        }
    }
}
