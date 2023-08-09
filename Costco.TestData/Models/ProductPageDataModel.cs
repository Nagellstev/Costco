namespace Costco.TestData.Models
{
    public class ProductPageDataModel : IConvertiblesClassDataModel
    {
        public IEnumerable<ZeroItemsDataModel> AddToCartZeroItemsTest { get; init; }
        public IEnumerable<LimitedItemsDataModel> AddToCartMoreLimitedItemsThanAllowedTest { get; init; }
        public IEnumerable<MaximumLimitDataModel> ExceedMaximumAmountOfItemsInCartInputFieldTest { get; init; }

        public IEnumerable<object[]> RetrieveData(string propertyName)
        {
            foreach (var item in (IEnumerable<IConvertible>)GetType().GetProperty(propertyName).GetValue(this))
            {
                yield return item.Items;
            }
        }

        public class ZeroItemsDataModel : IConvertible
        {
            public object[] Items
            {
                get
                {
                    return new object[] { InputItemAmount, ErrorMessage };
                }
            }

            public string InputItemAmount { get; init; }
            public string ErrorMessage { get; init; }
        }

        public class LimitedItemsDataModel : IConvertible
        {
            public object[] Items
            {
                get
                {
                    return new object[] { LowCutoffString, HighCutoffString, ErrorMessage };
                }
            }

            public string LowCutoffString { get; init; }
            public string HighCutoffString { get; init; }
            public string ErrorMessage { get; init; }
        }

        public class MaximumLimitDataModel : IConvertible
        {
            public object[] Items
            {
                get
                {
                    return new object[] { InputItemAmount, StepperPressAmount, ErrorMessage };
                }
            }

            public string InputItemAmount { get; init; }
            public string StepperPressAmount { get; init; }
            public string ErrorMessage { get; init; }
        }
    }
}
