using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dive.Tests
{
    [TestFixture]
    public class Submarine2Tests
    {
        [Test]
        public void Move_WithNullReference_ThrowsNullReferenceException()
        {
            List<Command> commands = null;
            var submarine = new Submarine2();

            Action action = () => submarine.Move(commands);

            action.Should().Throw<NullReferenceException>();
        }

        [Test]
        public void Move_WithEmptyListOfCommands_PositionAndAimNotChange()
        {
            var commands = new List<Command>();
            var submarine = new Submarine2();
            var expectedHorizontalPosition = submarine.HorizontalPosition;
            var expectedVerticalPosition = submarine.VerticalPosition;
            var expectedAim = submarine.Aim;

            submarine.Move(commands);
            var actualHorizontalPosition = submarine.HorizontalPosition;
            var actualVerticalPosition = submarine.VerticalPosition;
            var actualAim = submarine.Aim;

            actualHorizontalPosition.Should().Be(expectedHorizontalPosition);
            actualVerticalPosition.Should().Be(expectedVerticalPosition);
            actualAim.Should().Be(expectedAim);
        }

        [Test]
        public void Move_WithForwardCommand_IncreasesHorizontalPositionAndDepthAccoardingToDistance()
        {
            // Arrange
            var submarine = new Submarine2();

            var command1 = new Command
            {
                Direction = Direction.Down,
                Distance = 3
            };
            var commands1 = new List<Command>() { command1 };
            submarine.Move(commands1);

            var command2 = new Command
            {
                Direction = Direction.Forward,
                Distance = 5
            };
            var commands2 = new List<Command>() { command2 };

            var expectedHorizontalPosition = submarine.HorizontalPosition + command2.Distance;
            var expectedVerticalPosition = submarine.VerticalPosition + submarine.Aim * command2.Distance;
            var expectedAim = submarine.Aim;

            // Act
            submarine.Move(commands2);
            var actualHorizontalPosition = submarine.HorizontalPosition;
            var actualVerticalPosition = submarine.VerticalPosition;
            var actualAim = submarine.Aim;

            // Assert
            actualHorizontalPosition.Should().Be(expectedHorizontalPosition);
            actualVerticalPosition.Should().Be(expectedVerticalPosition);
            actualAim.Should().Be(expectedAim);
        }
        
        [Test]
        public void Move_WithDownCommand_IncreasesAimByDistance()
        {
            var command = new Command
            {
                Direction = Direction.Down,
                Distance = 5
            };
            var commands = new List<Command>() { command };
            var submarine = new Submarine2();
            var expectedHorizontalPosition = submarine.HorizontalPosition;
            var expectedVerticalPosition = submarine.VerticalPosition;
            var expectedAim = submarine.Aim + command.Distance;

            submarine.Move(commands);
            var actualHorizontalPosition = submarine.HorizontalPosition;
            var actualVerticalPosition = submarine.VerticalPosition;
            var actualAim = submarine.Aim;

            actualHorizontalPosition.Should().Be(expectedHorizontalPosition);
            actualVerticalPosition.Should().Be(expectedVerticalPosition);
            actualAim.Should().Be(expectedAim);
        }
        
        [Test]
        public void Move_WithUpCommand_DecreasesAimByDistance()
        {
            var command = new Command
            {
                Direction = Direction.Up,
                Distance = 5
            };
            var commands = new List<Command>() { command };
            var submarine = new Submarine2();
            var expectedHorizontalPosition = submarine.HorizontalPosition;
            var expectedVerticalPosition = submarine.VerticalPosition;
            var expectedAim = submarine.Aim - command.Distance;

            submarine.Move(commands);
            var actualHorizontalPosition = submarine.HorizontalPosition;
            var actualVerticalPosition = submarine.VerticalPosition;
            var actualAim = submarine.Aim;

            actualHorizontalPosition.Should().Be(expectedHorizontalPosition);
            actualVerticalPosition.Should().Be(expectedVerticalPosition);
            actualAim.Should().Be(expectedAim);
        }
    }
}
