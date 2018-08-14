using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace ConferenceSchedule.Models
{
    /// <summary>
    /// Represents an afternoon session
    /// </summary>
    public class AfternoonSession : Session
    {
        private static DateTime tomorrow = DateTime.Now.AddDays(1);
        /// <summary>
        /// Constructor
        /// </summary>
        public AfternoonSession() :
            base(new DateTime(tomorrow.Year, tomorrow.Month, tomorrow.Day, 13, 0, 0, 0), new DateTime(tomorrow.Year, tomorrow.Month, tomorrow.Day, 17, 0, 0, 0))
        { }

        public override string ToString()
        {
            var text = base.ToString();
            var networkingTime = StartTime.AddMinutes(TotalDuration);
            if (networkingTime.Hour < 16)
            {
                networkingTime = new DateTime(tomorrow.Year, tomorrow.Month, tomorrow.Day, 16, 0, 0, 0);
            }
            return string.Format("{0}{1} Networking Event\n", text, networkingTime.ToString("hh:mmtt", CultureInfo.InvariantCulture));
        }
    }
}
