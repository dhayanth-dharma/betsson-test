using Game.Library.Components.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game.Main
{
    public class PrintExtensionMethod
    {
        public bool PrintTurtleStatus(TurtleStatus status)
        {
            if (status == TurtleStatus.MineHit)
            {
                Console.WriteLine("Turtle land on a mine");
                return true;
               
            }
            else if (status == TurtleStatus.OutOfGrid)
            {
                Console.WriteLine("Turtle went out of grid");
                return false;
            }
            else if (status == TurtleStatus.Success)
            {
                Console.WriteLine("Turtle successfully reached the Exit point");
                return true;
            
            }
            else if (status == TurtleStatus.NearToMine)
            {
                Console.WriteLine("Turtle is near to mine");
                return false;
            }
            else if (status == TurtleStatus.StillInDanger)
            {
                Console.WriteLine("Turtle Still In Danger");
                return false;
            }
            else
            {
                Console.WriteLine("Turtle Still In Danger");
                return false;
            }
        }
    }
}
