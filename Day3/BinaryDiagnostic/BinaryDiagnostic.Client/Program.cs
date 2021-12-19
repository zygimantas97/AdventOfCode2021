using System;
using System.IO;
using System.Linq;

namespace BinaryDiagnostic.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            var reportData = File.ReadAllLines("data.txt").ToList();

            var report = new Report2(reportData);

            var lifeSupportRate = report.GetLifeSupportRate();

            Console.WriteLine("Result: " + lifeSupportRate);
        }
    }
}
