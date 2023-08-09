namespace Costco.TestData.Models
{
    public interface IConvertiblesClassDataModel
    {
        public IEnumerable<object[]> RetrieveData(string propertyName);
    }
}
