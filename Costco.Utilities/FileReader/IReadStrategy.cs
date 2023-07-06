namespace Costco.Utilities.FileReader
{
    public interface IReadStrategy<TModel>
    {
        public string? Target { get; set; }
        public TModel Execute();
    }
}
