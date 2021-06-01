using System;
using System.Collections.Generic;
using System.Text;

namespace Game.Library.Components
{
    public class GridCell
    {   
        public GridPoint Position { get; set; }
    }
     public class GridPoint
     {
        public int X { get; set; }
        public int Y { get; set; }

        public GridPoint(int x, int y)
        {
            X = x;
            Y = y;
        }
     }
}
