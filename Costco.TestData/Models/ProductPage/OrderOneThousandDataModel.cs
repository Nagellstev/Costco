namespace Costco.TestData.Models.ProductPage
{
    public class OrderOneThousandDataModel
    {
        public IEnumerable<DataObject> Data { get; init; }
        public IEnumerable<object[]> GenericData
        {
            get
            {
                foreach (DataObject item in Data)
                {
                    yield return new object[] { item.InputItemAmount, item.StepperPressAmount, item.ErrorMessage };
                }
            }
        }

        public class DataObject
        {
            public string InputItemAmount { get; init; }
            public string StepperPressAmount { get; init; }
            public string ErrorMessage { get; init; }
        }
    }
}
