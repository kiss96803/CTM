using System.Text.RegularExpressions;

namespace ConferenceSchedule.Utils.Extension
{
    /// <summary>
    /// String Helper
    /// </summary>
    public static class StringExtension
    {
        /// <summary>
        /// Replace insensitive
        /// </summary>
        /// <param name="input"></param>
        /// <param name="oldValue"></param>
        /// <param name="newValue"></param>
        /// <returns></returns>
        public static string ReplaceInsensitive(this string input, string oldValue, string newValue)
        {
            return Regex.Replace(input, Regex.Escape(oldValue), newValue.Replace("$", "$$"), RegexOptions.IgnoreCase);
        }
    }
}
