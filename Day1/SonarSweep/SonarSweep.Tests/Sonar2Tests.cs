using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace SonarSweep.Tests
{
    [TestFixture]
    public class Sonar2Tests
    {
        [Test]
        public void GetIncreasesCount_WithNullReferenceMeasurementsList_Returns0()
        {
            var sonar = new Sonar2(null);
            var expectedResult = 0;

            var actualResult = sonar.GetIncreasesCount();

            actualResult.Should().Be(expectedResult);
        }

        [Test]
        public void GetIncreasesCount_WithEmptyMeasurementsList_Returns0()
        {
            var sonar = new Sonar2(new List<int>());
            var expectedResult = 0;

            var actualResult = sonar.GetIncreasesCount();

            actualResult.Should().Be(expectedResult);
        }

        [Test]
        public void GetIncreasesCount_WithLessThan4Measurements_Returns0()
        {
            var sonar = new Sonar2(new List<int> { 1, 2, 3 });
            var expectedResult = 0;

            var actualResult = sonar.GetIncreasesCount();

            actualResult.Should().Be(expectedResult);
        }

        [Test]
        public void GetIncreasesCount_WithNotSequentialMeasurements_ReturnsCoutnOfIncreases()
        {
            var sonar = new Sonar2(new List<int>
            {
                199, 200, 208, 210, 200, 207, 240, 269, 260, 263
            });
            var expectedResult = 5;

            var actualResult = sonar.GetIncreasesCount();

            actualResult.Should().Be(expectedResult);
        }

        [Test]
        public void GetIncreasesCount_WithSequentialMeasurements_ReturnsCoutnOfIncreases()
        {
            var measurements = new List<int> { 1, 2, 3, 4, 5, 6 };
            var sonar = new Sonar2(measurements);
            var expectedResult = measurements.Count - 3;

            var actualResult = sonar.GetIncreasesCount();

            actualResult.Should().Be(expectedResult);
        }
    }
}
