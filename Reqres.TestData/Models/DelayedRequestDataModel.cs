namespace Reqres.TestData.Models
{
    public class DelayedRequestDataModel
    {
        public int Delay { get; init; }
        public int ExpectedStatusCode { get; init; }

        public override string ToString()
        {
            return GetType().Name;
        }
    }
}
