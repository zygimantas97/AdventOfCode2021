using System;
using System.Collections.Generic;
using System.Text;

namespace Dive
{
    public class Submarine2 : Submarine1
    {
        public int Aim { get; protected set; }

        public override void Move(List<Command> commands)
        {
            foreach(var command in commands)
            {
                switch (command.Direction)
                {
                    case Direction.Forward:
                        HorizontalPosition += command.Distance;
                        VerticalPosition += Aim * command.Distance;
                        break;
                    case Direction.Down:
                        Aim += command.Distance;
                        break;
                    case Direction.Up:
                        Aim -= command.Distance;
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
