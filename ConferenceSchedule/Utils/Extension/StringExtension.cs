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

        /// <summary>
        /// GetNumberFromString
        /// </summary>
        /// <param name="str">sourceStr</param>
        /// <returns></returns>
        public static int GetNumberInt(string str)
        {
            int result = 0;
            if (str != null && str != string.Empty)
            {
                // 正则表达式剔除非数字字符（包含小数点.） 
                str = Regex.Replace(str, @"[^\d\d]", "");
                // 如果是数字，则转换为decimal类型 
                if (Regex.IsMatch(str, @"^[+-]?\d*[.]?\d*$"))
                {
                    result = int.Parse(str);
                }
            }
            return result;
        }
    }
}
