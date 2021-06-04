using Game.Library.Components.Enums;
using System;

namespace Game.Main
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Starting the game");

            //Extention method. Print messages can be modified without changing Game library
            var printer = new PrintExtensionMethod();
            Func<TurtleStatus,bool > printer_method= printer.PrintTurtleStatus;
            
            var game_initiated = GameInitiater.CreateNewGame();
            game_initiated.Start(printer_method);

        }
        
    }
}
