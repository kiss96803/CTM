using ConferenceSchedule.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConferenceSchedule.Interface
{
    /// <summary>
    /// Schedule the Conference For TrackDay
    /// </summary>
    public interface IScheduleService
    {
        /// <summary>
        /// Distribute the conference within the track
        /// </summary>
        /// <param name="conferences"></param>
        /// <returns></returns>
        IList<TrackDay> Schedule(IList<Conference> conferences);
    }
}
