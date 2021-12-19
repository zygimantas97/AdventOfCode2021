using System;
using System.IO;
using System.Linq;

namespace Dive.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            var commands = File.ReadAllLines("data.txt").Select(s => Command.Parse(s)).ToList();
            var submarine = new Submarine2();

            submarine.Move(commands);

            Console.WriteLine("Result: " + (submarine.HorizontalPosition * submarine.VerticalPosition));
        }
    }
}
