using PickUpSticks;
using Shouldly;
using Xunit;

namespace PickUpSticksTests
{
    public class SticksRowTests
    {
        [Fact]
        public void Should_Create_SticksRow()
        {
            var sticksRow = new SticksRow(1, 3);

            sticksRow.ShouldNotBeNull();
            sticksRow.RowNumber.ShouldBe(1);
            sticksRow.StickCount.ShouldBe(3);
        }

        [Fact]
        public void Should_Remove_Sticks_From_Row()
        {
            var sticksRow = new SticksRow(1, 3);

            sticksRow.RemoveSticks(2);
            sticksRow.StickCount.ShouldBe(1);
            
            sticksRow.RemoveSticks(1);
            sticksRow.StickCount.ShouldBe(0);
        }

        [Fact]
        public void Should_Throw_Exception_When_Number_Of_Sticks_Out_Of_Range()
        {
            var sticksRow = new SticksRow(1, 3);

            Should.Throw<NumberOfSticksOutOfRangeException>(() => sticksRow.RemoveSticks(-1));
            Should.Throw<NumberOfSticksOutOfRangeException>(() => sticksRow.RemoveSticks(4));
        }
    }
}