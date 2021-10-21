using PickUpSticks;
using Shouldly;
using Xunit;

namespace PickUpSticksTests
{
    public class SticksRowPanelTests
    {
        [Fact]
        public void Should_Create_Empty_SticksRowPanel()
        {
            var sticksRowPanel = new SticksRowPanel();

            sticksRowPanel.RowsCount.ShouldBe(0);
            sticksRowPanel.HasStick.ShouldBeFalse();
        }

        [Fact]
        public void Should_Add_SticksRow_To_Panel()
        {
            var sticksRowPanel = new SticksRowPanel();
            
            var sticksRow = sticksRowPanel.CreateRowAndPutSticks(3);

            sticksRowPanel.RowsCount.ShouldBe(1);
            sticksRowPanel.HasStick.ShouldBeTrue();
            sticksRow.RowNumber.ShouldBe(1);
            sticksRow.StickCount.ShouldBe(3);
        }

        [Fact]
        public void Should_Get_SticksRow_From_Panel()
        {
            var sticksRowPanel = new SticksRowPanel();

            sticksRowPanel.CreateRowAndPutSticks(3);

            var sticksRow = sticksRowPanel.GetRow(1);
            sticksRow.ShouldNotBeNull();
            sticksRow.RowNumber.ShouldBe(1);
            sticksRow.StickCount.ShouldBe(3);
        }
    }
}