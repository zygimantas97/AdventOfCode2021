using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using SonarSweep;
using FluentAssertions;

namespace SonarSweep.Tests
{
    [TestFixture]
    public class Sonar1Tests
    {
        [Test]
        public void GetIncreasesCount_WithNullReferenceMeasurementsList_Returns0()
        {
            var sonar = new Sonar1(null);
            var expectedResult = 0;

            var actualResult = sonar.GetIncreasesCount();

            actualResult.Should().Be(expectedResult);
        }

        [Test]
        public void GetIncreasesCount_WithEmptyMeasurementsList_Returns0()
        {
            var sonar = new Sonar1(new List<int>());
            var expectedResult = 0;

            var actualResult = sonar.GetIncreasesCount();

            actualResult.Should().Be(expectedResult);
        }

        [Test]
        public void GetIncreasesCount_WithOneMeasurements_Returns0()
        {
            var sonar = new Sonar1(new List<int> { 1 });
            var expectedResult = 0;

            var actualResult = sonar.GetIncreasesCount();

            actualResult.Should().Be(expectedResult);
        }

        [Test]
        public void GetIncreasesCount_WithNotSequentialMeasurements_ReturnsCoutnOfIncreases()
        {
            var sonar = new Sonar1(new List<int>
            {
                199, 200, 208, 210, 200, 207, 240, 269, 260, 263
            });
            var expectedResult = 7;

            var actualResult = sonar.GetIncreasesCount();

            actualResult.Should().Be(expectedResult);
        }

        [Test]
        public void GetIncreasesCount_WithSequentialMeasurements_ReturnsCoutnOfIncreases()
        {
            var measurements = new List<int> { 1, 2, 3, 4 };
            var sonar = new Sonar1(measurements);
            var expectedResult = measurements.Count - 1;

            var actualResult = sonar.GetIncreasesCount();

            actualResult.Should().Be(expectedResult);
        }
    }
}
