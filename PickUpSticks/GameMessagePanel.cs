using System.Collections.Generic;

namespace PickUpSticks
{
    public class GameMessagePanel
    {
        private readonly List<GameMessage> _messages = new();

        public IReadOnlyCollection<GameMessage> Messages => _messages.AsReadOnly();

        public void Collect(string content, GameMessageType gameMessageType)
        {
            var gameMessage = new GameMessage(content, gameMessageType);

            _messages.Add(gameMessage);
        }

        public void RenderMessages(GameMessageRender messageRender) =>
            _messages.ForEach(messageRender.Render);
    }
}