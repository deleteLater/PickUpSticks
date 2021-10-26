using PickUpSticks;
using PickUpSticks.Exceptions;
using Shouldly;
using Xunit;

namespace PickUpSticksTests
{
    public class GameMessageTests
    {
        [Fact]
        public void Should_Create_A_Game_Message_With_Content_And_Type()
        {
            var gameMessage = new GameMessage("user login", GameMessageType.System);

            gameMessage.ShouldNotBeNull();
            gameMessage.Content.ShouldBe("user login");
            gameMessage.GameMessageType.ShouldBe(GameMessageType.System);
        }

        [Fact]
        public void Game_Message_Content_Should_Not_Be_Null_Or_Empty()
        {
            Should.Throw<MessageContentNotValidException>(() => new GameMessage(null, default));
            Should.Throw<MessageContentNotValidException>(() => new GameMessage("", default));
            Should.Throw<MessageContentNotValidException>(() => new GameMessage(" ", default));
        }
    }
}