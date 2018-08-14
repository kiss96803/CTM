using System;
using System.Globalization;

namespace ConferenceSchedule.Models
{
    /// <summary>
    /// Represents a morning session
    /// </summary>
    public class MorningSession : Session
    {
        private static DateTime tomorrow = DateTime.Now.AddDays(1);

        /// <summary>
        /// Constructor
        /// </summary>
        public MorningSession() : base(new DateTime(tomorrow.Year, tomorrow.Month, tomorrow.Day, 9, 0, 0, 0), new DateTime(tomorrow.Year, tomorrow.Month, tomorrow.Day, 12, 0, 0, 0)) { }

        public override string ToString()
        {
            var text = base.ToString();
            var lunchTime = new DateTime(tomorrow.Year, tomorrow.Month, tomorrow.Day, 12, 0, 0, 0);
            return string.Format("{0}{1} Lunch\n", text, lunchTime.ToString("hh:mmtt", CultureInfo.InvariantCulture));
        }
    }
}
