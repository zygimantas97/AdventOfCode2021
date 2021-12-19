using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using Dive;
using FluentAssertions;

namespace Dive.Tests
{
    [TestFixture]
    public class CommandTests
    {
        [Test]
        public void Parse_WithWrongDirection_ThrowsArgumentException()
        {
            var commandString = "Backward 5";

            Action action = () => Command.Parse(commandString);

            action.Should().Throw<ArgumentException>();
        }

        [Test]
        public void Parse_WithWrongDistanceFormat_ThrowsFormatException()
        {
            var commandString = "Up five";

            Action action = () => Command.Parse(commandString);

            action.Should().Throw<FormatException>();
        }

        [Test]
        public void Parse_WithoutDistance_ThrowsIndexOutOfRangeException()
        {
            var commandString = "Up";

            Action action = () => Command.Parse(commandString);

            action.Should().Throw<IndexOutOfRangeException>();
        }

        [Test]
        public void Parse_WithNullReference_ThrowsNullReferenceException()
        {
            string commandString = null;

            Action action = () => Command.Parse(commandString);

            action.Should().Throw<NullReferenceException>();
        }

        [Test]
        public void Parse_WithEmptyString_ThrowsArgumentException()
        {
            var commandString = "";

            Action action = () => Command.Parse(commandString);

            action.Should().Throw<ArgumentException>();
        }

        [Test]
        public void Parse_WithCorrectCommandFormat_ReturnsCommand()
        {
            var commandString = "Up 5";
            var expectedCommand = new Command
            {
                Direction = Direction.Up,
                Distance = 5
            };

            var actualCommand = Command.Parse(commandString);

            actualCommand.Should().BeEquivalentTo(expectedCommand);
        }
    }
}
