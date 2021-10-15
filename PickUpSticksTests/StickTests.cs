using PickUpSticks;
using Shouldly;
using Xunit;

namespace PickUpSticksTests
{
    public class StickTests
    {
        [Fact]
        public void Should_Create_Stick()
        {
            var stick = new Stick();

            stick.ShouldNotBeNull();
        }
    }
}