using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Costco.Tests
{
    public static class GlobalSetup
    {
        [ModuleInitializer]
        public static void Setup() =>
            XunitContext.EnableExceptionCapture();
    }
}
