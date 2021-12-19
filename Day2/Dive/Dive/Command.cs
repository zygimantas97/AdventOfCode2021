using System;
using System.Collections.Generic;
using System.Text;

namespace Dive
{
    public class Command
    {
        public Direction Direction { get; set; }
        public int Distance { get; set; }

        public static Command Parse(string command)
        {
            var parts = command.Split(" ");
            return new Command
            {
                Direction = Enum.Parse<Direction>(parts[0], true),
                Distance = Int32.Parse(parts[1])
            };
        }
    }
}
