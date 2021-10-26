using System.Linq;
using PickUpSticks;
using Shouldly;
using Xunit;
using Xunit.Abstractions;

namespace PickUpSticksTests
{
    public class GameMessagePanelTests
    {
        private readonly ITestOutputHelper _outputHelper;

        public GameMessagePanelTests(ITestOutputHelper outputHelper)
        {
            _outputHelper = outputHelper;
        }
        
        [Fact]
        public void Should_Create_A_Game_Message_Panel()
        {
            var messagePanel = new GameMessagePanel();

            messagePanel.ShouldNotBeNull();
        }

        [Fact]
        public void Should_Collect_Messages()
        {
            var messagePanel = new GameMessagePanel();
            var messages = messagePanel.Messages;
            
            // user message
            var userMessage = "this is a message from user";
            messagePanel.Collect(userMessage, GameMessageType.User);
            
            messages.Count.ShouldBe(1);
            messages.ElementAt(0).Content.ShouldBe(userMessage);
            messages.ElementAt(0).GameMessageType.ShouldBe(GameMessageType.User);
            
            // system message
            var systemMessage = "this is a message from system";
            messagePanel.Collect(systemMessage, GameMessageType.System);
            
            messages.Count.ShouldBe(2);
            messages.ElementAt(1).Content.ShouldBe(systemMessage);
            messages.ElementAt(1).GameMessageType.ShouldBe(GameMessageType.System);
        }

        [Fact]
        public void Should_Render_Message()
        {
            var messagePanel = new GameMessagePanel();
            messagePanel.Collect("this is a message from user", GameMessageType.User);
            
            // should see message output in test explorer
            messagePanel.RenderMessages(new OutputHelperGameMessageRender(_outputHelper));
        }
    }
}