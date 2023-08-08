using Microsoft.VisualBasic;

namespace Costco.TestData.Models.ProductPage
{
    public class LimitedMemberItemsDataModel
    {
        public IEnumerable<DataObject> Data { get; init; }
        public IEnumerable<object[]> GenericData { 
            get
            {
                foreach (DataObject item in Data) 
                {
                    yield return new object[] { item.LowCutoffString, item.HighCutoffString, item.ErrorMessage };
                }
            }
        }

        public class DataObject
        {
            public string LowCutoffString { get; init; }
            public string HighCutoffString { get; init;}
            public string ErrorMessage { get; init; }
        }
    }
}
