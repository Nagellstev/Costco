using Xunit.Sdk;
using Xunit;
using Costco.Utilities.Logger;

namespace Costco.Tests
{
    public class AssertWithCustomUserMessage : Assert
    {
        /// <summary>
        /// Verifies that a string contains a given sub-string, using the given comparison type.
        /// </summary>
        /// <param name="expectedSubstring">The sub-string expected to be in the string</param>
        /// <param name="actualString">The string to be inspected</param>
        /// <param name="message">The type of string comparison to perform</param>
        /// <exception cref="ContainsException">Thrown when the sub-string is not present inside the string</exception>
        public static void Contains(string expectedSubstring, string actualString, string message)
        {
            try
            {
                Assert.Contains(expectedSubstring, actualString);
            }
            catch (ContainsException containsException)
            {
                Logger.Error(message + "\n" + containsException.Message);
                throw;
            }
        }
    }
}
