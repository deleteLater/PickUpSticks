using System;

namespace PickUpSticks
{
    public class GameLogger
    {
        public static void PanelLog(string message)
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Log(message);
        }
        
        public static void PlayerLog(string message)
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Log(message);
        }

        static void Log(string message)
        {
            Console.WriteLine(message);
        }
    }
}