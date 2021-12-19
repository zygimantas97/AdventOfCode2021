using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace BinaryDiagnostic.Tests
{
    [TestFixture]
    class Report1Tests
    {
        [Test]
        public void GetGammaRate_WithNullReferenceReportData_ThrowsNullReferenceException()
        {
            List<string> reportData = null;
            var report = new Report1(reportData);

            Action action = () => report.GetGammaRate();

            action.Should().Throw<NullReferenceException>();
        }

        [Test]
        public void GetGammaRate_WithEmptyReportDataList_ThrowsArgumentOutOfRangeException()
        {
            var reportData = new List<string>();
            var report = new Report1(reportData);

            Action action = () => report.GetGammaRate();

            action.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Test]
        public void GetGammaRate_WithNullReferenceReportDataEntry_ThrowsNullReferenceException()
        {
            string reportDataEntry = null;
            var reportData = new List<string>() { reportDataEntry };
            var report = new Report1(reportData);

            Action action = () => report.GetGammaRate();

            action.Should().Throw<NullReferenceException>();
        }

        [Test]
        public void GetGammaRate_WithWrongFormatReportDataEntry_ThrowsFormatException()
        {
            var reportDataEntry = "012";
            var reportData = new List<string>() { "012" };
            var report = new Report1(reportData);

            Action action = () => report.GetGammaRate();

            action.Should().Throw<FormatException>().WithMessage("Report data entry is not of binnary format");
        }

        [Test]
        public void GetGammaRate_WithOneReportDataEntry_ReturnsGammaRate()
        {
            var reportDataEntry = "010";
            var reportData = new List<string>() { reportDataEntry };
            var report = new Report1(reportData);
            var expectedResult = "010";

            var actualResult = report.GetGammaRate();

            actualResult.Should().Be(expectedResult);
        }

        [Test]
        public void GetGammaRate_WithThreeReportDataEntries_ReturnsGammaRate()
        {
            var reportDataEntry1 = "010";
            var reportDataEntry2 = "100";
            var reportDataEntry3 = "111";
            var reportData = new List<string>() { reportDataEntry1, reportDataEntry2, reportDataEntry3 };
            var report = new Report1(reportData);
            var expectedResult = "110";

            var actualResult = report.GetGammaRate();

            actualResult.Should().Be(expectedResult);
        }

        [Test]
        public void GetEpsilonRate_WithNullReferenceReportData_ThrowsNullReferenceException()
        {
            List<string> reportData = null;
            var report = new Report1(reportData);

            Action action = () => report.GetEpsilonRate();

            action.Should().Throw<NullReferenceException>();
        }

        [Test]
        public void GetEpsilonRate_WithEmptyReportDataList_ThrowsArgumentOutOfRangeException()
        {
            var reportData = new List<string>();
            var report = new Report1(reportData);

            Action action = () => report.GetEpsilonRate();

            action.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Test]
        public void GetEpsilonRate_WithNullReferenceReportDataEntry_ThrowsNullReferenceException()
        {
            string reportDataEntry = null;
            var reportData = new List<string>() { reportDataEntry };
            var report = new Report1(reportData);

            Action action = () => report.GetEpsilonRate();

            action.Should().Throw<NullReferenceException>();
        }

        [Test]
        public void GetEpsilonRate_WithWrongFormatReportDataEntry_ThrowsFormatException()
        {
            var reportDataEntry = "012";
            var reportData = new List<string>() { reportDataEntry };
            var report = new Report1(reportData);

            Action action = () => report.GetEpsilonRate();

            action.Should().Throw<FormatException>().WithMessage("Report data entry is not of binnary format");
        }

        [Test]
        public void GetEpsilonRate_WithOneReportDataEntry_ReturnsEpsilonRate()
        {
            var reportDataEntry = "010";
            var reportData = new List<string>() { reportDataEntry };
            var report = new Report1(reportData);
            var expectedResult = "101";

            var actualResult = report.GetEpsilonRate();

            actualResult.Should().Be(expectedResult);
        }

        [Test]
        public void GetEpsilonRate_WithThreeReportDataEntries_ReturnsEpsilonRate()
        {
            var reportDataEntry1 = "010";
            var reportDataEntry2 = "100";
            var reportDataEntry3 = "111";
            var reportData = new List<string>() { reportDataEntry1, reportDataEntry2, reportDataEntry3 };
            var report = new Report1(reportData);
            var expectedResult = "001";

            var actualResult = report.GetEpsilonRate();

            actualResult.Should().Be(expectedResult);
        }

        [Test]
        public void GetPowerConsumption_WithOneReportDataEntry_ReturnsGammaRateMultipliedByEpsilonRate()
        {
            var reportDataEntry = "010";
            var reportData = new List<string>() { reportDataEntry };
            var report = new Report1(reportData);
            var gammaRate = Convert.ToInt32(report.GetGammaRate(), 2);
            var epsilonRate = Convert.ToInt32(report.GetEpsilonRate(), 2);
            var expectedResult = gammaRate * epsilonRate;

            var actualResult = report.GetPowerConsumption();

            actualResult.Should().Be(expectedResult);
        }

        [Test]
        public void GetPowerConsumption_WithThreeReportDataEntries_ReturnsGammaRateMultipliedByEpsilonRate()
        {
            var reportDataEntry1 = "010";
            var reportDataEntry2 = "100";
            var reportDataEntry3 = "111";
            var reportData = new List<string>() { reportDataEntry1, reportDataEntry2, reportDataEntry3 };
            var report = new Report1(reportData);
            var gammaRate = Convert.ToInt32(report.GetGammaRate(), 2);
            var epsilonRate = Convert.ToInt32(report.GetEpsilonRate(), 2);
            var expectedResult = gammaRate * epsilonRate;

            var actualResult = report.GetPowerConsumption();

            actualResult.Should().Be(expectedResult);
        }
    }
}
