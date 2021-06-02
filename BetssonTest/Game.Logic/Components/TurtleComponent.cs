using System;
using System.Collections.Generic;
using System.Text;
using Game.Library.Components.ComponentEnum;
using Game.Library.Components.Enums;

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

        public Direction direction { get; set; }

        /*
         MOVE TURTLE 
         */
        public void MoveTurlte( )
        {   
            switch (direction)
            {
                case Direction.N:
                    turtle.Position = new GridPoint (turtle.Position.X - 1, turtle.Position.Y );
                    break;
                case Direction.S:
                    turtle.Position = new GridPoint ( turtle.Position.X + 1, turtle.Position.Y );
                    break;
                case Direction.E:
                    turtle.Position = new GridPoint ( turtle.Position.X, turtle.Position.Y + 1 );
                    break;
                case Direction.W:
                    turtle.Position = new GridPoint (turtle.Position.X, turtle.Position.Y - 1 );
                    break;
            }
        }

        /*
         TURN TURTLE 
         */
        public void RotateTurtle(Rotation rotate_direction)
        {
            if (direction == Direction.N && rotate_direction == Rotation.L)
                direction = Direction.W;
            else if (direction == Direction.N && rotate_direction == Rotation.R)
                direction = Direction.E;

            else if (direction == Direction.E && rotate_direction == Rotation.L)
                direction = Direction.N;
            else if (direction == Direction.E && rotate_direction == Rotation.R)
                direction = Direction.S;

            else if (direction == Direction.S && rotate_direction == Rotation.L)
                direction = Direction.E;
            else if (direction == Direction.S && rotate_direction == Rotation.R)
                direction = Direction.W;

            else if (direction == Direction.W && rotate_direction == Rotation.L)
                direction = Direction.S;
            else if (direction == Direction.W && rotate_direction == Rotation.R)
                direction = Direction.N;
        }
    }
}
