using Game.Library.Components;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game.Main.ConfigReader
{
    public class GameSettings
    {
        public GridPoint size { get; set; }
        public GridPoint start{ get; set; }
        public GridPoint exit{ get; set; }
        public List<GridPoint> mines { get; set; } = new List<GridPoint>();
        public string start_direction { get; set; }
        public string[] moves { get; set; }

        public GameSettings()
        {

        }
        public GameSettings(GridPoint size, GridPoint start, GridPoint exit, List<GridPoint> mines, string direction, string[] moves)
        {
            this.size = size;
            this.start = start;
            this.exit = exit;
            this.mines = mines;
            this.start_direction = direction;
            this.moves = moves;

        }
    }
}
