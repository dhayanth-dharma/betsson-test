# Betsson-Test

## About the Project

This project demonstrates a turtle game. 

# Application overview 
 This solution consist of three main projects.  
    
> ## **Game Library**
>
> found in `Game.Library` project  
>   
>  This project contains all game component models and enums

> ## **Game Main**
>
> found in `Game.Main` project
>   
>  This project contains GameInitiator class that reads settings from `Settings.txt` and initiate the game grid, turtle, exit point and mines within the grid

> ## **Test Project**
>
> found in `Game.UnitTests` project  
>   

>  This project contains [Unit-Test] Class and methods to test the application. 



## How to get started with the Project
 
 1. Open the project with Visual Studio
 2. Edit the `GameSettings.txt` in `Game.Main` project 
	* The first line should define the board size
    * The second line should contain a list of mines (i.e. list of co-ordinates separated by a space)
    * The third line of the file should contain the exit point.
	* The fourth line of the file should contain the starting position of the turtle
	* The fifth line to the end of the file should contain a series of moves.
	* R = Rotate 90 degrees to the right, L = Rotate 90 degrees to the left, N = North direction, S = South direction, W = West direction, E = East direction, M = Move
 3. Edit `PrintExtensionMethod.cs` function to for custom print messages. [Note: This method used as an extention method. Return _True_ when the game should end ]
 3. Run the `Game.Main` project 

## Stack
* C#
