namespace Costco.TestData.Models.ProductPage
{
    public class ZeroItemsDataModel
    {
        public IEnumerable<DataObject> Data { get; init; }
        public IEnumerable<object[]> GenericData
        {
            get
            {
                foreach (DataObject item in Data)
                {
                    yield return new object[] { item.InputItemAmount, item.ErrorMessage };
                }
            }
        }

        public class DataObject
        {
            public string InputItemAmount { get; init; }
            public string ErrorMessage { get; init; }
        }
    }
}
