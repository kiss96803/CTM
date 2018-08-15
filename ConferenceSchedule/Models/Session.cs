using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Globalization;
using System.Text;

namespace ConferenceSchedule.Models
{
    public abstract class Session
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <param name="endTimeExtended"></param>
        protected Session(DateTime startTime, DateTime endTime)
        {
            StartTime = startTime;
            EndTime = endTime;
            AvailableMinutes = (int)EndTime.Subtract(StartTime).TotalMinutes;
            var collection = (ObservableCollection<Conference>)Conferences;
            collection.CollectionChanged += OnCollectionChanged;
        }

        /// <summary>
        /// Sum of all talks duration
        /// </summary>
        public int TotalDuration { get; private set; }

        /// <summary>
        /// Available minutes in session
        /// </summary>
        public int AvailableMinutes { get; private set; }

        /// <summary>
        /// Session end time
        /// </summary>
        protected DateTime EndTime { get; set; }

        /// <summary>
        /// Session extended end time Time that the session can go if not finished until end time
        /// </summary>
        protected DateTime EndTimeExtended { get; set; }

        /// <summary>
        /// Session start time
        /// </summary>
        protected DateTime StartTime { get; set; }

        /// <summary>
        /// List of talks in a session
        /// </summary>
        protected IList<Conference> Conferences { get; } = new ObservableCollection<Conference>();

        /// <summary>
        /// Add talks to session if time is available
        /// </summary>
        /// <param name="talk"></param>
        /// <param name="extended">Should consider extended time</param>
        /// <returns>Add was succesful</returns>
        public bool AddConference(Conference talk, bool extended)
        {
            if (CheckConstraint(talk, extended))
            {
                Conferences.Add(talk);
                return true;
            }
            return false;
        }

        /// <summary>
        /// Add talks to session if time is available It does not consider extended time
        /// </summary>
        /// <param name="talk"></param>
        /// <returns></returns>
        public bool AddConference(Conference talk)
        {
            return AddConference(talk, false);
        }


        public override string ToString()
        {
            StringBuilder text = new StringBuilder();
            var start = StartTime;
            foreach (var talk in Conferences)
            {
                text.AppendFormat("{0} {1}\n", start.ToString("hh:mmtt", CultureInfo.InvariantCulture), talk);
                start = start.AddMinutes(talk.Duration);
            }
            return text.ToString();
        }

        /// <summary>
        /// Check whether talk is within availble time
        /// </summary>
        /// <param name="talk"></param>
        /// <param name="extended">Should consider extended time</param>
        /// <returns></returns>
        protected bool CheckConstraint(Conference talk, bool extended)
        {
            if (talk == null) { return false; }
            var end = StartTime.AddMinutes(TotalDuration + talk.Duration);
            return extended ? end <= EndTimeExtended : end <= EndTime;
        }

        /// <summary>
        /// Updates statistics whether collection is changed
        /// </summary>
        /// <remarks>It does not handle deletes.</remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
            {
                foreach (Conference newItem in e.NewItems)
                {
                    TotalDuration += newItem.Duration;
                    AvailableMinutes -= newItem.Duration;
                }
            }
        }
    }
}
