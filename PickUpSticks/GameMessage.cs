using PickUpSticks.Exceptions;

namespace PickUpSticks
{
    public class GameMessage
    {
        public string Content { get; }
        public GameMessageType GameMessageType { get; }

        public GameMessage(string content, GameMessageType gameMessageType)
        {
            if (string.IsNullOrWhiteSpace(content))
            {
                throw new MessageContentNotValidException("the message content cannot be null or empty.");
            }
            
            Content = content;
            GameMessageType = gameMessageType;
        }
    }
}