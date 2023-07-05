namespace Costco.Utilities.ConfigReader
{
    public interface IReadStrategy<TModel>
    {
        public string? Target { get; set; }
        public TModel Execute();
    }
}
