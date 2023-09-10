namespace Reqres.TestData.Models
{
    public class DeleteUserDataModel
    {
        public int UserID { get; init; }
        public int ExpectedStatusCode { get; init; }

        public override string ToString()
        {
            return GetType().Name;
        }
    }
}
