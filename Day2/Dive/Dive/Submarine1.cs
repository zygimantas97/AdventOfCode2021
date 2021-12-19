using System;
using System.Collections.Generic;
using System.Text;

namespace Dive
{
    public class Submarine1
    {
        public int HorizontalPosition { get; protected set; }

        public int VerticalPosition { get; protected set; }

        public virtual void Move(List<Command> commands)
        {
            foreach(var command in commands)
            {
                switch (command.Direction)
                {
                    case Direction.Forward:
                        HorizontalPosition += command.Distance;
                        break;
                    case Direction.Down:
                        VerticalPosition += command.Distance;
                        break;
                    case Direction.Up:
                        VerticalPosition -= command.Distance;
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
