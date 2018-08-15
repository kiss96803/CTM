using ConferenceSchedule.Models;
using ConferenceSchedule.Utils;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ConferenceSchedule.Interface.Implement
{
    /// <summary>
    /// ScheduleService
    /// </summary>
    public class ScheduleService : IScheduleService
    {
        /// <summary>
        /// Schedule
        /// </summary>
        /// <param name="conferences"></param>
        /// <returns></returns>
        public IList<TrackDay> Schedule(IList<Conference> conferences)
        {
            var orderedConferences = conferences.Where(t => t.Duration < 241).ToList();
            if (orderedConferences.Count == 0)
            {
                Console.WriteLine("No Conference!");
                return null;
            }
            else
            {
                return ScheduleConference(orderedConferences).OrderBy(t => t.Name).ToList();
            }
        }

        /// <summary>
        /// ScheduleConference
        /// </summary>
        /// <param name="conferences"></param>
        /// <returns></returns>
        private static List<TrackDay> ScheduleConference(IList<Conference> conferences)
        {
            var trackDays = new List<TrackDay>();
            var trackDayNum = 1;
            var firstTrackDay = new TrackDay(trackDayNum.ToString());
            trackDays.Add(firstTrackDay);
            foreach (var conference in conferences)
            {
                if (trackDays.Max(t => t.Afternoon.AvailableMinutes) > conference.Duration || trackDays.Max(t => t.Morning.AvailableMinutes) > conference.Duration)
                {
                    trackDays = AddConferenceToTrackDay(conference, trackDays);
                }
                else
                {
                    trackDayNum++;
                    trackDays.Add(new TrackDay(trackDayNum.ToString()));
                    trackDays[trackDayNum - 1].Morning.AddConference(conference);
                }
            }
            return trackDays;
        }

        /// <summary>
        /// AddConferenceToTrackDay
        /// </summary>
        /// <param name="conference"></param>
        /// <param name="trackDays"></param>
        /// <returns></returns>
        private static List<TrackDay> AddConferenceToTrackDay(Conference conference, List<TrackDay> trackDays)
        {
            trackDays = RandomHelper.GetRandomList(trackDays);
            foreach (var trackDay in trackDays)
            {
                if (conference.Duration <= trackDay.Morning.AvailableMinutes || conference.Duration <= trackDay.Afternoon.AvailableMinutes)
                {
                    if (trackDay.Morning.AvailableMinutes > conference.Duration)
                    {
                        trackDay.Morning.AddConference(conference);
                        break;
                    }
                    else
                    {
                        trackDay.Afternoon.AddConference(conference);
                        break;
                    }
                }
            }
            return trackDays;
        }
    }
}
