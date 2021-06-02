using System;

namespace Game.Main
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Starting the game");
            var game_initiated = GameInitiater.CreateNewGame();
            game_initiated.Start();

        }
    }
}
