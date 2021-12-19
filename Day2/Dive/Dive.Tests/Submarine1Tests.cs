using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dive.Tests
{
    [TestFixture]
    public class Submarine1Tests
    {
        [Test]
        public void Move_WithNullReference_ThrowsNullReferenceException()
        {
            List<Command> commands = null;
            var submarine = new Submarine1();

            Action action = () => submarine.Move(commands);

            action.Should().Throw<NullReferenceException>();
        }

        [Test]
        public void Move_WithEmptyListOfCommands_PositionNotChange()
        {
            var commands = new List<Command>();
            var submarine = new Submarine1();
            var expectedHorizontalPosition = submarine.HorizontalPosition;
            var expectedVerticalPosition = submarine.VerticalPosition;

            submarine.Move(commands);
            var actualHorizontalPosition = submarine.HorizontalPosition;
            var actualVerticalPosition = submarine.VerticalPosition;

            actualHorizontalPosition.Should().Be(expectedHorizontalPosition);
            actualVerticalPosition.Should().Be(expectedVerticalPosition);
        }

        [Test]
        public void Move_WithForwardCommand_IncreasesHorizontalPositionByDistance()
        {
            var command = new Command
            {
                Direction = Direction.Forward,
                Distance = 5
            };
            var commands = new List<Command>() { command };
            var submarine = new Submarine1();
            var expectedHorizontalPosition = submarine.HorizontalPosition + command.Distance;
            var expectedVerticalPosition = submarine.VerticalPosition;

            submarine.Move(commands);
            var actualHorizontalPosition = submarine.HorizontalPosition;
            var actualVerticalPosition = submarine.VerticalPosition;

            actualHorizontalPosition.Should().Be(expectedHorizontalPosition);
            actualVerticalPosition.Should().Be(expectedVerticalPosition);
        }

        [Test]
        public void Move_WithDownCommand_IncreasesVerticalPositionByDistance()
        {
            var command = new Command
            {
                Direction = Direction.Down,
                Distance = 5
            };
            var commands = new List<Command>() { command };
            var submarine = new Submarine1();
            var expectedHorizontalPosition = submarine.HorizontalPosition;
            var expectedVerticalPosition = submarine.VerticalPosition + command.Distance;

            submarine.Move(commands);
            var actualHorizontalPosition = submarine.HorizontalPosition;
            var actualVerticalPosition = submarine.VerticalPosition;

            actualHorizontalPosition.Should().Be(expectedHorizontalPosition);
            actualVerticalPosition.Should().Be(expectedVerticalPosition);
        }

        [Test]
        public void Move_WithUpCommand_DecreasesVerticalPositionByDistance()
        {
            var command = new Command
            {
                Direction = Direction.Up,
                Distance = 5
            };
            var commands = new List<Command>() { command };
            var submarine = new Submarine1();
            var expectedHorizontalPosition = submarine.HorizontalPosition;
            var expectedVerticalPosition = submarine.VerticalPosition - command.Distance;

            submarine.Move(commands);
            var actualHorizontalPosition = submarine.HorizontalPosition;
            var actualVerticalPosition = submarine.VerticalPosition;

            actualHorizontalPosition.Should().Be(expectedHorizontalPosition);
            actualVerticalPosition.Should().Be(expectedVerticalPosition);
        }
    }
}
