namespace Costco.Utilities.Extensions
{
    public static class StringExtension
    {
        public static string Substring(this string s, string lowCutoff, string highCutoff)
        {
            return s.Substring(s.IndexOf(lowCutoff) + lowCutoff.Length,
                    s.IndexOf(highCutoff) - s.IndexOf(lowCutoff) - lowCutoff.Length);
        }
    }
}
