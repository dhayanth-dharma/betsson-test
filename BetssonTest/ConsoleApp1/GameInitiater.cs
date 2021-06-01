using Game.Library.Components;
using Game.Library.Components.ComponentEnum;
using Game.Main.ConfigReader;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game.Main
{
    public class GameInitiater
    {
        private GridPoint turtle_start_point;
        private FileReader file_reader;
        private GameSettings game_settings;
        private GridComponent grid;

        #region Factory method

        private GameInitiater()
        {
            file_reader = FileReader.GetInstance();
            game_settings= file_reader.GetGameSettings();
            turtle_start_point = game_settings.start;
            grid = new GridComponent(game_settings.size.Y, game_settings.size.X);
            SetTurtle(turtle_start_point);
            SetExit(game_settings.exit);
            SetMines(game_settings.mines);
        }

        public static GameInitiater CreateNewGame()
        {
            return new GameInitiater();
        }
        #endregion


       public void Start()
        {
            var moves = game_settings.moves;
            var turtle = grid[turtle_start_point] as TurtleComponent;
            System.Enum.TryParse<Direction>(game_settings.start_direction, out var dir);
            turtle.Direction = dir;
            
        }


        /*
         *Setup Mines in the grid
         */
        private void SetMines(List<GridPoint> mines)
        {
            foreach (var mine_position in mines)
            {
                try
                {
                    grid[mine_position] = new MineComponent() { Position = mine_position };
                }
                catch
                {
                    throw new Exception("Mine creation error");
                }
            }
        }

        /*
         *Setup Exit point in the grid
         */
        private void SetExit(GridPoint exit_point)
        {
            try
            {
                grid[exit_point] = new ExitComponent() { Position = exit_point };
            }
            catch
            {/*ignore*/}
        }


        /*
         *Setup Turlte and its position in the grid
         */
        private void SetTurtle(GridPoint turtlePosition)
        {
            try
            {
                grid[turtlePosition] = TurtleComponent.Instance(turtlePosition);
            }
            catch
            {/*ignore*/}
        }
    }
}
