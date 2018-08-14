using ConferenceSchedule.Models;
using ConferenceSchedule.Utils.Extension;
using System;
using System.Linq;

namespace ConferenceSchedule.Interface.Implement
{
    /// <summary>
    /// TextLint To ConferenceModel
    /// </summary>
    public class ConferenceConverter : IConferenceConverter
    {
        private const string _lightningStr = "lightning";
        private const string _timeUnit = "min";
        private static readonly char[] _separator = { ' ' };

        /// <summary>
        ///  Convert a textLint to a Conference
        /// </summary>
        /// <param name="textLine">eachLine in testfile</param>
        /// <returns></returns>
        public Conference Convert(string textLine)
        {
            if (string.IsNullOrWhiteSpace(textLine))
            {
                return new Conference("", -1);
            }

            string[] words = textLine.Split(_separator, StringSplitOptions.RemoveEmptyEntries);

            string subject = string.Join(" ", words.Take(words.Length - 1));

            string textDuration = words.Last();
            int duration = textDuration.Equals(_lightningStr, StringComparison.OrdinalIgnoreCase) ? 5 : StringExtension.GetNumberInt(textLine);

            return new Conference(subject, duration);
        }
    }
}
