namespace Costco.Utilities.ConfigReader
{
    internal interface IReadStrategy
    {
        public string? Target { get; set; }
        public ConfigModel Execute();
    }
}
