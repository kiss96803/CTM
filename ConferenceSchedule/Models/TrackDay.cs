using System.Collections.Generic;

namespace ConferenceSchedule.Models
{
    /// <summary>
    /// TrackDayModel
    /// </summary>
    public class TrackDay
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="name"></param>
        public TrackDay(string name)
        {
            Name = name;
        }

        /// <summary>
        /// Afternoon session of a track day
        /// </summary>
        public AfternoonSession Afternoon { get; } = new AfternoonSession();

        /// <summary>
        /// Morning session of track day
        /// </summary>
        public MorningSession Morning { get; } = new MorningSession();

        /// <summary>
        /// Track1 Or Track2 and so on...
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// TrackDate
        /// </summary>
        public string Date { get; set; }

        /// <summary>
        /// ConferencesList
        /// </summary>
        public List<Conference> Conferences { get; set; }

        public override string ToString()
        {
            return string.Format("Track {0}\n{1}{2}", Name, Morning, Afternoon);
        }
    }
}
