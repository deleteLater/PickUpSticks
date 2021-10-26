using System;
using PickUpSticks;
using Shouldly;
using Xunit;
using Xunit.Abstractions;

namespace PickUpSticksTests
{
    public class GameTests
    {
        private readonly ITestOutputHelper _outputHelper;

        public GameTests(ITestOutputHelper outputHelper)
        {
            _outputHelper = outputHelper;
        }

        [Fact]
        public void Should_Create_A_New_Game()
        {
            var playerA = new Player("playerA");
            var playerB = new Player("playerB");
            var sticksRowPanel = new SticksRowPanel();

            var game = new Game(playerA, playerB, sticksRowPanel);

            game.ShouldNotBeNull();
        }

        [Fact]
        public void Should_Run_The_Game()
        {
            // player
            var littleBob = new Player("little bob");
            var littleTom = new Player("little tom");

            // game board
            var sticksRowPanel = new SticksRowPanel();
            sticksRowPanel.CreateRowAndPutSticks(3);
            sticksRowPanel.CreateRowAndPutSticks(5);
            sticksRowPanel.CreateRowAndPutSticks(7);

            // the game
            var game = new Game(littleBob, littleTom, sticksRowPanel);

            // message panel
            var gameMessagePanel = new GameMessagePanel();

            EventHandler<StickPickedEventArgs> PlayerPickupStick(GameMessagePanel messagePanel)
            {
                return (_, args) =>
                {
                    var content = $"{args.PlayerName} chose row {args.RowNumber}, take {args.NumberOfSticks} sticks.";
                    messagePanel.Collect(content, GameMessageType.User);
                };
            }

            littleBob.StickPicked += PlayerPickupStick(gameMessagePanel);
            littleTom.StickPicked += PlayerPickupStick(gameMessagePanel);

            sticksRowPanel.StickRemoved += (_, args) =>
            {
                var content =
                    $"-- row {args.RowNumber} remove {args.NumberOfSticksToRemove} sticks, remain {args.RemainedSticks} sticks.";
                gameMessagePanel.Collect(content, GameMessageType.System);
            };

            game.GameRunning += (_, args) => gameMessagePanel.Collect(args, GameMessageType.System);

            // run the game
            game.Run();

            // show game messages
            gameMessagePanel.RenderMessages(new OutputHelperGameMessageRender(_outputHelper));
        }
    }
}