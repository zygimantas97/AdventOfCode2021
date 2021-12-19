using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace BinaryDiagnostic.Tests
{
    [TestFixture]
    class Report2Tests
    {
        [Test]
        public void GetOxygenGeneratorRate_WithNullReferenceReportData_ThrowsArgumentNullException()
        {
            List<string> reportData = null;
            var report = new Report2(reportData);

            Action action = () => report.GetOxygenGeneratorRate();

            action.Should().Throw<ArgumentNullException>();
        }

        [Test]
        public void GetOxygenGeneratorRate_WithEmptyReportDataList_ThrowsArgumentOutOfRangeException()
        {
            var reportData = new List<string>();
            var report = new Report2(reportData);

            Action action = () => report.GetOxygenGeneratorRate();

            action.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Test]
        public void GetOxygenGeneratorRate_WithWrongFormatReportDataEntry_ThrowsFormatException()
        {
            var reportDataEntry = "012";
            var reportData = new List<string>() { reportDataEntry, reportDataEntry };
            var report = new Report2(reportData);

            Action action = () => report.GetCO2ScrubberRate();

            action.Should().Throw<FormatException>().WithMessage("Report data entry is not of binnary format");
        }

        [Test]
        public void GetOxygenGeneratorRate_WithOneReportDataEntry_ReturnsOxygenGeneratorRate()
        {
            var reportDataEntry = "010";
            var reportData = new List<string>() { reportDataEntry };
            var report = new Report2(reportData);
            var expectedResult = "010";

            var actualResult = report.GetOxygenGeneratorRate();

            actualResult.Should().Be(expectedResult);
        }

        [Test]
        public void GetOxygenGeneratorRate_WithThreeReportDataEntries_ReturnsOxygenGeneratorRate()
        {
            var reportDataEntry1 = "010";
            var reportDataEntry2 = "100";
            var reportDataEntry3 = "111";
            var reportData = new List<string>() { reportDataEntry1, reportDataEntry2, reportDataEntry3 };
            var report = new Report2(reportData);
            var expectedResult = "111";

            var actualResult = report.GetOxygenGeneratorRate();

            actualResult.Should().Be(expectedResult);
        }

        [Test]
        public void GetCO2ScrubberRate_WithNullReferenceReportData_ThrowsArgumentNullException()
        {
            List<string> reportData = null;
            var report = new Report2(reportData);

            Action action = () => report.GetCO2ScrubberRate();

            action.Should().Throw<ArgumentNullException>();
        }

        [Test]
        public void GetCO2ScrubberRate_WithEmptyReportDataList_ThrowsArgumentOutOfRangeException()
        {
            var reportData = new List<string>();
            var report = new Report2(reportData);

            Action action = () => report.GetCO2ScrubberRate();

            action.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Test]
        public void GetCO2ScrubberRate_WithWrongFormatReportDataEntry_ThrowsFormatException()
        {
            var reportDataEntry = "012";
            var reportData = new List<string>() { reportDataEntry, reportDataEntry };
            var report = new Report2(reportData);

            Action action = () => report.GetCO2ScrubberRate();

            action.Should().Throw<FormatException>().WithMessage("Report data entry is not of binnary format");
        }

        [Test]
        public void GetCO2ScrubberRate_WithOneReportDataEntry_ReturnsCO2ScrubberRate()
        {
            var reportDataEntry = "010";
            var reportData = new List<string>() { reportDataEntry };
            var report = new Report2(reportData);
            var expectedResult = "010";

            var actualResult = report.GetCO2ScrubberRate();

            actualResult.Should().Be(expectedResult);
        }

        [Test]
        public void GetCO2ScrubberRate_WithThreeReportDataEntries_ReturnsCO2ScrubberRate()
        {
            var reportDataEntry1 = "010";
            var reportDataEntry2 = "100";
            var reportDataEntry3 = "111";
            var reportData = new List<string>() { reportDataEntry1, reportDataEntry2, reportDataEntry3 };
            var report = new Report2(reportData);
            var expectedResult = "010";

            var actualResult = report.GetCO2ScrubberRate();

            actualResult.Should().Be(expectedResult);
        }
        
        [Test]
        public void GetLifeSupportRate_WithOneReportDataEntry_ReturnsOxygenGeneratorRateMultipliedByEpsilonCO2ScrubberRate()
        {
            var reportDataEntry = "010";
            var reportData = new List<string>() { reportDataEntry };
            var report = new Report2(reportData);
            var oxygenGeneratorRate = Convert.ToInt32(report.GetOxygenGeneratorRate(), 2);
            var CO2ScrubberRate = Convert.ToInt32(report.GetCO2ScrubberRate(), 2);
            var expectedResult = oxygenGeneratorRate * CO2ScrubberRate;

            var actualResult = report.GetLifeSupportRate();

            actualResult.Should().Be(expectedResult);
        }

        [Test]
        public void GetLifeSupportRate_WithOneWrongFormatReportDataEntry_ThrowsFormatException()
        {
            var reportDataEntry = "012";
            var reportData = new List<string>() { reportDataEntry };
            var report = new Report2(reportData);

            Action action = () => report.GetLifeSupportRate();

            action.Should().Throw<FormatException>();
        }

        [Test]
        public void GetLifeSupportRate_WithThreeReportDataEntries_ReturnsGammaRateMultipliedByCO2ScrubberRate()
        {
            var reportDataEntry1 = "010";
            var reportDataEntry2 = "100";
            var reportDataEntry3 = "111";
            var reportData = new List<string>() { reportDataEntry1, reportDataEntry2, reportDataEntry3 };
            var report = new Report2(reportData);
            var oxygenGeneratorRate = Convert.ToInt32(report.GetOxygenGeneratorRate(), 2);
            var CO2ScrubberRate = Convert.ToInt32(report.GetCO2ScrubberRate(), 2);
            var expectedResult = oxygenGeneratorRate * CO2ScrubberRate;

            var actualResult = report.GetLifeSupportRate();

            actualResult.Should().Be(expectedResult);
        }
    }
}
