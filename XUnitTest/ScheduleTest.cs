using ConferenceSchedule.Interface;
using ConferenceSchedule.Interface.Implement;
using ConferenceSchedule.Models;
using System.Collections.Generic;
using Xunit;

namespace XUnitTest
{
    public class ScheduleTest
    {

        private const string _category = "TrackDayBuilder";

        private readonly IScheduleService _target = new ScheduleService();

        [Fact]
        [Trait("Category", _category)]
        public void TestBuild()
        {
            // Arrange
            var talks = BuildTalks(12, 30);

            // Act
            var output = _target.Schedule(talks);

            // Assert
            Assert.Equal<int>(1, output.Count);
        }

        [Fact]
        [Trait("Category", _category)]
        public void TestBuildExtended()
        {
            // Arrange
            var talks = BuildTalks(14, 30);

            // Act
            var output = _target.Schedule(talks);

            // Assert
            Assert.Equal<int>(1, output.Count);
        }

        [Fact]
        [Trait("Category", _category)]
        public void TestBuildExtended2()
        {
            // Arrange
            var talks = BuildTalks(28, 30);

            // Act
            var output = _target.Schedule(talks);

            // Assert
            Assert.Equal<int>(2, output.Count);
        }

        private IList<Conference> BuildTalks(int count, int duration)
        {
            List<Conference> conferences = new List<Conference>(count);
            for (int i = 0; i < count; i++)
            {
                conferences.Add(new Conference(string.Format("Title {0}", i), duration));
            }
            return conferences;
        }
    }
}
