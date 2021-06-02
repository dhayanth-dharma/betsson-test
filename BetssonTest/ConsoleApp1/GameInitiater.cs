using Game.Library.Components;
using Game.Library.Components.ComponentEnum;
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


        public void Start()
        {

            var instructions = game_settings.instruction;
            var turtle = grid[turtle_start_point] as TurtleComponent;
            System.Enum.TryParse<Direction>(game_settings.start_direction, out var dir);
            turtle.direction = dir;
            foreach (string instruction in instructions)
            {
                //Each(instruction.Split(' ').ToList(), i => play_game(i, turtle));
                foreach (string move in instruction.Split(' '))
                {
                    if (move == "R") turtle.RotateTurtle(Rotation.R);
                    else if (move == "L") turtle.RotateTurtle(Rotation.L);
                    else if (move == "M") turtle.MoveTurlte();
                    var current_state = status_indicator.GetCurrentStatus(turtle.Position);

                    if (current_state == TurtleStatus.MineHit)
                    {
                        Console.WriteLine("Turtle land on a mine");
                        break;
                    }
                    else if (current_state == TurtleStatus.OutOfGrid)
                    {
                        Console.WriteLine("Turtle went out of grid");

                    }
                    else if (current_state == TurtleStatus.Success)
                    {
                        Console.WriteLine("Turtle successfully reached the ");
                        break;
                    }
                    else if (current_state == TurtleStatus.NearToMine)
                    {
                        Console.WriteLine("Turtle is near to mine");
                    }
                    else if (current_state == TurtleStatus.StillInDanger)
                    {
                        Console.WriteLine("Turtle Still In Danger");
                    }
                }
            }

        }
        private void play_game(string instruction, TurtleComponent turtle)
        {
            if (instruction == "R") turtle.RotateTurtle(Rotation.R);
            else if (instruction == "L") turtle.RotateTurtle(Rotation.L);
            else if (instruction == "M") turtle.MoveTurlte();
            var current_state = status_indicator.GetCurrentStatus(turtle.Position);

            if (current_state == TurtleStatus.MineHit)
            {
                Console.WriteLine("Turtle land on a mine");
            }
            else if (current_state == TurtleStatus.OutOfGrid)
            {
                Console.WriteLine("Turtle went out of grid");

            }
            else if (current_state == TurtleStatus.Success)
            {
                Console.WriteLine("Turtle successfully reached the ");

            }
            else if (current_state == TurtleStatus.NearToMine)
            {
                Console.WriteLine("Turtle is near to mine");
            }
            else if (current_state == TurtleStatus.StillInDanger)
            {
                Console.WriteLine("Turtle Still In Danger");
            }
        }

        public void Each<T>(IEnumerable<T> items, Action<T> action)
        {
            foreach (var item in items)
                action(item);
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
