using PickUpSticks;
using Xunit.Abstractions;

namespace PickUpSticksTests
{
    public class OutputHelperGameMessageRender : GameMessageRender
    {
        private readonly ITestOutputHelper _outputHelper;

        public OutputHelperGameMessageRender(ITestOutputHelper outputHelper)
        {
            _outputHelper = outputHelper;
        }
        
        public override void Render(GameMessage message)
        {
            _outputHelper.WriteLine(message.Content);
        }
    }
}