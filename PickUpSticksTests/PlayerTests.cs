using PickUpSticks;
using Shouldly;
using Xunit;

namespace PickUpSticksTests
{
    public class PlayerTests
    {
        [Fact]
        public void Should_Create_Player_With_NotNull_NotWhiteSpace_Name()
        {
            var player = new Player("little bob");
            player.Name.ShouldBe("little bob");

            Should.Throw<PlayerNameNotValidException>(() => new Player(null));
            Should.Throw<PlayerNameNotValidException>(() => new Player(""));
            Should.Throw<PlayerNameNotValidException>(() => new Player(" "));
        }

        [Fact]
        public void Should_PickUp_Sticks()
        {
            var player = new Player("little bob");
            var panel = new SticksRowPanel();
            panel.CreateRow(3);

            player.PickUpSticks(panel, 1, 3);

            var row1 = panel.GetRow(1);
            row1.StickCount.ShouldBe(0);
        }

        [Fact]
        public void Should_Throw_Exception_When_Number_Of_Row_Or_Number_Of_Sticks_Out_Of_Range()
        {
            var player = new Player("little bob");
            var panel = new SticksRowPanel();
            panel.CreateRow(3);

            Should.Throw<NumberOfRowOutOfRangeException>(() => player.PickUpSticks(panel, 2, 3));
            Should.Throw<NumberOfSticksOutOfRangeException>(() => player.PickUpSticks(panel, 1, 4));
        }

        [Fact]
        public void Should_Throw_Exception_When_Player_Take_Less_Than_One_Stick()
        {
            var player = new Player("little bob");
            var panel = new SticksRowPanel();
            panel.CreateRow(3);
            
            Should.Throw<CannotTakeLessThanOneStickException>(() => player.PickUpSticks(panel, 1, 0));
            Should.Throw<CannotTakeLessThanOneStickException>(() => player.PickUpSticks(panel, 1, -1));
        }

        [Fact]
        public void Should_PickUp_Sticks_Randomly()
        {
            var player = new Player("little bob");
            var panel = new SticksRowPanel();
            panel.CreateRow(3);

            var pickUpResult = player.PickUpSticksRandomly(panel);
            pickUpResult.ShouldBeTrue();
            panel.GetRow(1).StickCount.ShouldBeLessThan(3);
        }
    }
}