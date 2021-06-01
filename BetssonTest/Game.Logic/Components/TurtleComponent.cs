using System;
using System.Collections.Generic;
using System.Text;
using Game.Library.Components.ComponentEnum;
namespace Game.Library.Components
{
    public class TurtleComponent : GridCell
    {
        #region Singleton
        
        private static TurtleComponent turtle;
        private TurtleComponent(GridPoint position) { 
            Position = position; 
        }
        public static TurtleComponent Instance(GridPoint position)
        {
            return turtle ?? (turtle = new TurtleComponent(position));
        }
        #endregion

        public Direction Direction { get; set; }


        public void MoveTurlte()
        {   
            switch (Direction)
            {
                case Direction.North:
                    //Printer.Print(_turtle.Position, new Point { X = _turtle.Position.X - 1, Y = _turtle.Position.Y });
                    turtle.Position = new GridPoint { X = turtle.Position.X - 1, Y = turtle.Position.Y };
                    break;
                case Direction.South:
                    //Printer.Print(_turtle.Position, new Point { X = _turtle.Position.X + 1, Y = _turtle.Position.Y });
                    turtle.Position = new GridPoint { X = turtle.Position.X + 1, Y = turtle.Position.Y };
                    break;
                case Direction.East:
                    //Printer.Print(_turtle.Position, new Point { X = _turtle.Position.X, Y = _turtle.Position.Y + 1 });
                    turtle.Position = new GridPoint { X = turtle.Position.X, Y = turtle.Position.Y + 1 };
                    break;
                case Direction.West:
                    //Printer.Print(_turtle.Position, new Point { X = _turtle.Position.X, Y = _turtle.Position.Y - 1 });
                    turtle.Position = new GridPoint { X = turtle.Position.X, Y = turtle.Position.Y - 1 };
                    break;
            }
        }

        /// <summary>
        /// rotate turtle
        /// </summary>
        public void RotateTurtle()
        {
            switch (Direction)
            {
                case Direction.North:
                    Direction = Direction.East;
                    //Printer.Print(Direction);
                    break;
                case Direction.South:
                    Direction = Direction.West;
                    //Printer.Print(Direction);
                    break;
                case Direction.East:
                    Direction = Direction.South;
                    //Printer.Print(Direction);
                    break;
                case Direction.West:
                    Direction = Direction.North;
                    //Printer.Print(Direction);
                    break;
                default:
                    break;
            }
        }
    }
}
