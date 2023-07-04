namespace Costco.Utilities.ConfigReader
{
    internal interface IReadStrategy<TModel>
    {
        public string? Target { get; set; }
        public TModel Execute();
    }
}
