
using Game.Library.Components;
using Game.Library.Components.Enums;
using Game.Main.ConfigReader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Game.Main
{
    public class GameInitiater
    {
        private GridPoint turtle_start_point;
        private FileReader file_reader;
        private GameSettings game_settings;
        private GridComponent grid;
        private StatusIndicator status_indicator;


        private GameInitiater()
        {
            file_reader = FileReader.GetInstance();
            game_settings= file_reader.GetGameSettings();
            turtle_start_point = game_settings.start;
            grid = new GridComponent(game_settings.size.Y, game_settings.size.X);
            SetTurtle(turtle_start_point);
            SetExit(game_settings.exit);
            SetMines(game_settings.mines);
            status_indicator = new StatusIndicator(grid);
        }

        public static GameInitiater CreateNewGame()
        {
            return new GameInitiater();
        }


        public void Start(Func<TurtleStatus,Boolean> printer)
        {

            var instructions = game_settings.instruction;
            var turtle = grid[turtle_start_point] as TurtleComponent;
            System.Enum.TryParse<Direction>(game_settings.start_direction, out var dir);
            turtle.direction = dir;
            bool break_loop = false;
            foreach (string instruction in instructions)
            {
                foreach (string move in instruction.Split(' '))
                {
                    if (move == "R") turtle.RotateTurtle(Rotation.R);
                    else if (move == "L") turtle.RotateTurtle(Rotation.L);
                    else if (move == "M") turtle.MoveTurlte();
                    var current_state = status_indicator.GetCurrentStatus(turtle.Position);
                    break_loop=printer(current_state);
                    if (break_loop) break;
                }
                if (break_loop) break;
            }
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
                catch (Exception ex)
                {
                    if (ex is IndexOutOfRangeException)
                        throw new IndexOutOfRangeException("Mine position is outside the grid");
                    throw ex;
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
            catch (Exception ex)
            {
                if(ex is IndexOutOfRangeException)
                    throw new IndexOutOfRangeException("Exit position is outside the grid");
                throw ex;

            }
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
            catch (Exception ex)
            {
                if (ex is IndexOutOfRangeException)
                    throw new IndexOutOfRangeException("Turtle position is outside the grid");
                throw ex;
            }
        }
    }
}
