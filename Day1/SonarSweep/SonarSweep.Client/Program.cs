using System;
using System.IO;
using System.Linq;

namespace SonarSweep.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            var measurements = File.ReadAllLines("data.txt").Select(x => Int32.Parse(x.Trim())).ToList();
            var sonar = new Sonar2(measurements);

            var answer = sonar.GetIncreasesCount();

            Console.WriteLine("Answer: " + answer);
        }
    }
}
