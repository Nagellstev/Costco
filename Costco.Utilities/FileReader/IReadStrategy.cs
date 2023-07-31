namespace Costco.Utilities.FileReader
{
    public interface IReadStrategy
    {
        public string? Target { get; set; }
        public string? ModelAssembly { get; set; }
        public object Execute();
    }
}
