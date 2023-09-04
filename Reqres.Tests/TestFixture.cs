using Costco.Utilities.Logger;
using Costco.Utilities.FileReader;
using Reqres.Core;

namespace Reqres.Tests
{
    public class TestFixture : IDisposable
    {
        public TestFixture()
        {
            Logger.Init("Reqres", "logs\\");
            Logger.Information("Setup complete.");
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
            Logger.Information("Disposing of fixture.");
        }
    }
}
