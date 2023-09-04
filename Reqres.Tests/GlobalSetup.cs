using System.Runtime.CompilerServices;

namespace Reqres.Tests
{
    public static class GlobalSetup
    {
        [ModuleInitializer]
        public static void Setup() =>
            XunitContext.EnableExceptionCapture();
    }
}
