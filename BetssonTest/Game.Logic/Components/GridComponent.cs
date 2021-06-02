using System;
using System.Collections.Generic;
using System.Text;

namespace Game.Library.Components
{
    public class GridComponent
    {

        private GridCell[][] grid_cells;
        public int width{ get; private set; }
        public int height{ get; private set; }
        
        /*
         * Represents grid field with columnans and rows. 
          Args: Width, Height   
         */ 
        public GridComponent(int x, int y)
        {
            width = y;
            height = x;

            grid_cells = new GridCell[x][];
            for (int i = 0; i < x; i++){
                grid_cells[i] = new GridCell[y];
                for (int j = 0; j < y; j++){
                    //grid_cells[i][j] = new GridCell() { Position = new GridPoint{ X = i, Y = j } };                    
                    grid_cells[i][j] = new GridCell() { Position = new GridPoint(i,  j ) };
                }
            }
        }
        
        //public GridCell this[int index1, int index2]
        //{
        //    get { return grid_cells[index1][index2]; }
        //    set { grid_cells[index1][index2] = value; }
        //}

        public GridCell this[GridPoint p]
        {
            get { return grid_cells[p.X][p.Y]; }
            set { grid_cells[p.X][p.Y] = value; }
        }

    }
}
