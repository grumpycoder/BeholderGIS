using System.Linq;
using System.Text;

namespace BeholderGIS.Helpers
{
    public static class StringHelpers
    {
        public static string StripUnicodeCharactersFromString(this string inputValue)
        {
            if (inputValue == null) return null;

            var stringBytes = Encoding.Unicode.GetBytes(inputValue);
            var stringChars = Encoding.Unicode.GetChars(stringBytes);
            var builder = new StringBuilder();
            foreach (var c in stringChars.Where(char.IsLetterOrDigit))
            {
                builder.Append(c);
            }
            return builder.ToString();
        }
    }
}