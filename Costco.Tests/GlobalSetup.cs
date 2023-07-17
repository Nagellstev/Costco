using System.Runtime.CompilerServices;

namespace Costco.Tests
{
    public static class GlobalSetup
    {
        [ModuleInitializer]
        public static void Setup() =>
            XunitContext.EnableExceptionCapture();
    }
}
