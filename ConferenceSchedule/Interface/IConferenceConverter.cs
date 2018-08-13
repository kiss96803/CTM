using ConferenceSchedule.Models;

namespace ConferenceSchedule.Interface
{
    /// <summary>
    /// Interface to change the textline into Conference
    /// </summary>
    public interface IConferenceConverter
    {
        Conference Convert(string textLine);
    }
}
