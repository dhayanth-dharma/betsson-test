using Game.Library.Components;
using Game.Library.Components.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Game.Main
{

    /*
    * Indicate the current status of the turtle based on each move
    */
    public class StatusIndicator
    {
        private int width;
        private int height;
        private GridComponent grid;

        public StatusIndicator(GridComponent grid)
        {
            width = grid.width;
            height = grid.height;
            this.grid = grid;
        }

        /*
         * Get Current Turtle positions
         * Args: GridPoint
         * Return: TurtleStatus 
         */
        public TurtleStatus GetCurrentStatus(GridPoint current_position)
        {
            if (current_position.X < 0 || current_position.Y >= width || current_position.X >= height || current_position.Y < 0) return TurtleStatus.OutOfGrid;
            else if (grid[current_position] is ExitComponent) return TurtleStatus.Success;
            else if (grid[current_position] is MineComponent) return TurtleStatus.MineHit;
            else if  (GetSurroudingCells(current_position).Any(x => grid[x] is MineComponent)) return TurtleStatus.NearToMine;
            else return TurtleStatus.StillInDanger;
        }

        /*
         * Get nearby cells
         * Args: GridPoint
         * Return: List of neighbour cells
         */
        private List<GridPoint> GetSurroudingCells(GridPoint position)
        {
            var list = new List<GridPoint>();

            if (position.X - 1 >= 0) list.Add(new GridPoint (  position.X - 1, position.Y ));
            if (position.X - 1 >= 0 && position.Y - 1 >= 0) list.Add(new GridPoint (position.X - 1, position.Y - 1 ));
            if (position.X - 1 >= 0 && position.Y + 1 < width) list.Add(new GridPoint ( position.X - 1, position.Y + 1 ));
            if (position.X + 1 < height) list.Add(new GridPoint (  position.X + 1,  position.Y ));
            if (position.X + 1 < height && position.Y - 1 >= 0) list.Add(new GridPoint ( position.X + 1, position.Y - 1 ));
            if (position.X + 1 < height && position.Y + 1 < width) list.Add(new GridPoint ( position.X + 1,  position.Y + 1 ));
            if (position.Y - 1 >= 0) list.Add(new GridPoint (position.X, position.Y - 1 ));
            if (position.Y + 1 < width) list.Add(new GridPoint (  position.X,  position.Y + 1 ));
            return list;
        }

    }
}
