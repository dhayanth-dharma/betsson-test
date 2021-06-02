using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using Game.Library.Components;
using System.Linq;

namespace Game.Main.ConfigReader
{
    public class FileReader
    {
        private static FileReader file_reader;
        private FileReader() { }
        public static FileReader GetInstance()
        {
               return file_reader ?? (file_reader = new FileReader());
        }


        public GameSettings GetGameSettings()
        {
            GameSettings game_settings = new GameSettings();
            var setting_text = File.ReadAllLines("GameSettings.txt");
  
            var grid_size_string = setting_text[0].Split(' ');
            int.TryParse(grid_size_string[0], out var sizeX);
            int.TryParse(grid_size_string[1], out var sizeY);
            game_settings.size= new GridPoint(sizeX, sizeY);

            var mine_position_string = setting_text[1].Split(' ');


            //for (int i = 0; i < mine_position_string.Length; i++)
            foreach (string text in mine_position_string)
            {
                var mine_point = text.Split(',');
                int.TryParse(mine_point[0], out var mineX);
                int.TryParse(mine_point[1], out var mineY);
                game_settings.mines.Add(new GridPoint(mineX, mineY));
            }
                
            var exit_point_string = setting_text[2].Split(' ');
            int.TryParse(exit_point_string[0], out var exitX);
            int.TryParse(exit_point_string[1], out var exitY);
            game_settings.exit= new GridPoint(exitX, exitY);
            
            var start_point_string = setting_text[3].Split(' ');
            int.TryParse(start_point_string[0], out var startX);
            int.TryParse(start_point_string[1], out var startY);
            game_settings.start = new GridPoint(startX, startY);
            game_settings.start_direction = start_point_string[2];

            game_settings.instruction= setting_text.Skip(4).ToArray();
             
            return game_settings;
        }

        
    }
}
