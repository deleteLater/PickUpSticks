using System;

namespace PickUpSticks
{
    public class ConsoleGameMessageRender : GameMessageRender
    {
        public override void Render(GameMessage message)
        {
            switch (message.GameMessageType)
            {
                case GameMessageType.User:
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                case GameMessageType.System:
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.ForegroundColor = ConsoleColor.Black;
                    break;
            }

            Console.WriteLine(message.Content);
        }
    }
}