using Costco.Utilities.Logger;
using ReportPortal.Shared;
using Reqres.Core;

namespace Reqres.Tests
{
    public class BaseTest : XunitContextBase
    {
        public ClientBuilder builder;
        string testDisplayName;
        public ITestOutputHelper output;

        public BaseTest(ITestOutputHelper output) : base(output)
        {
            testDisplayName = Context.Test.DisplayName;
            Logger.Information($"Initializing {testDisplayName}.");
            builder = new ClientBuilder();
            builder.Options.BaseUrl = new Uri("https://reqres.in/");
        }

        public override void Dispose()
        {
            var theExceptionThrownByTest = Context.TestException;

            if (theExceptionThrownByTest != null)
            {
                Logger.Error($"Test '{testDisplayName}' failed, {theExceptionThrownByTest.Message}\nException: {theExceptionThrownByTest}");
            }

            GC.SuppressFinalize(this);
            base.Dispose();
            Logger.Information($"Disposing of {testDisplayName}.");
        }
    }
}
