using System;
using System.Collections.Generic;
using System.Text;

namespace ConferenceSchedule.Models
{
    /// <summary>
    /// Conference Model
    /// </summary>
    public class Conference
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="subjcet"></param>
        /// <param name="duration"></param>
        public Conference(string subjcet, int duration)
        {
            Subject = subjcet;
            Duration = duration;
            IsLighting = duration == 15 ? true : false;
        }

        /// <summary>
        /// ConferenceDuration
        /// </summary>
        public int Duration { get; set; }

        /// <summary>
        /// The Subject of Conference
        /// </summary>
        public string Subject { get; set; }

        /// <summary>
        /// All talk lengths are either in minutes (not hours) or lightning (5 minutes)
        /// </summary>
        public bool IsLighting { get; set; }

        /// <summary>
        /// Override the ToString Method for Input.txt
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return Duration != 15 ? string.Format("{0} {1}min", Subject, Duration) : string.Format("{0} lightning", Subject);
        }
    }
}
