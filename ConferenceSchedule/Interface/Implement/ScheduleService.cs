using ConferenceSchedule.Models;
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
            var trackDays = new List<TrackDay>();
            var orderedConferences = conferences.OrderByDescending(t => t.Duration).ToList();
            int trackNumber = 0;
            while (orderedConferences.Count > 0)
            {
                trackNumber++;
                var day = new TrackDay(trackNumber.ToString());
                bool morning = true;
                do
                {
                    var session = morning ? day.Morning : (Session)day.Afternoon;
                    AddConference(orderedConferences, session, false);
                    morning = !morning;
                } while (!morning);
                trackDays.Add(day);
                if (orderedConferences.Sum(t => t.Duration) <= trackDays.Sum(t => t.Afternoon.CalculatedAvailableMinutes(true)))
                {
                    foreach (var trackDay in trackDays)
                    {
                        AddConference(orderedConferences, trackDay.Afternoon, true);
                    }
                }
            }
            return trackDays;
        }

        /// <summary>
        /// Fill slots in a given session
        /// </summary>
        /// <param name="conferences"></param>
        /// <param name="session"></param>
        /// <param name="extended">Should use extended time</param>
        private static void AddConference(IList<Conference> conferences, Session session, bool extended)
        {
            while (session.AddConference(conferences.FirstOrDefault(), extended))
            {
                conferences.RemoveAt(0);
            }

            // There is time available
            while (session.CalculatedAvailableMinutes(extended) > 0)
            {
                // Find a session to fill the remainer slot
                var equalLessTime = conferences.SingleOrDefault(t => t.Duration == session.CalculatedAvailableMinutes(extended)) ?? conferences.SingleOrDefault(t => t.Duration < session.CalculatedAvailableMinutes(extended));
                if (equalLessTime != null)
                {
                    session.AddConference(equalLessTime, extended);
                    conferences.Remove(equalLessTime);
                }
                else
                {
                    break;
                }
            }
        }
    }
}
