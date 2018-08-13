using ConferenceSchedule.Interface;
using ConferenceSchedule.Interface.Implement;
using Xunit;

namespace XUnitTest
{
    public class ConferencsConvertTest
    {
        private const string _category = "ConferenceConverter";
        private readonly IConferenceConverter _convert = new ConferenceConverter();

        [Fact]
        [Trait("Category", _category)]
        public void ParseEmpty()
        {
            // Arrange
            string input = " ";
            // Act
            var output = _convert.Convert(input);
            // Assert
            Assert.Equal(-1, output.Duration);
            Assert.Equal("", output.Subject);
        }

        [Fact]
        [Trait("Category", _category)]
        public void ParseLightning()
        {
            // Arrange
            string input = "Rails for Python Developers lightning";
            // Act
            var output = _convert.Convert(input);
            // Assert
            Assert.Equal(15, output.Duration);
            Assert.Equal("Rails for Python Developers", output.Subject);
        }

        [Fact]
        [Trait("Category", _category)]
        public void ParseLightningUpper()
        {
            // Arrange
            string input = "RAILS FOR PYTHON DEVELOPERS LIGHTNING";
            // Act
            var output = _convert.Convert(input);
            // Assert
            Assert.Equal(15, output.Duration);
            Assert.Equal("RAILS FOR PYTHON DEVELOPERS", output.Subject);
        }

        [Fact]
        [Trait("Category", _category)]
        public void ParseMinutes()
        {
            // Arrange
            string input = "Rails for Python Developers 20min";
            // Act
            var output = _convert.Convert(input);
            // Assert
            Assert.Equal(20, output.Duration);
            Assert.Equal("Rails for Python Developers", output.Subject);
        }

        [Fact]
        [Trait("Category", _category)]
        public void ParseMinutesUpper()
        {
            // Arrange
            string input = "RAILS FOR PYTHON DEVELOPERS 20MIN";
            // Act
            var output = _convert.Convert(input);
            // Assert
            Assert.Equal(20, output.Duration);
            Assert.Equal("RAILS FOR PYTHON DEVELOPERS", output.Subject);
        }
    }
}
