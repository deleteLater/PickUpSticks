using System;
using PickUpSticks;

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
gameMessagePanel.RenderMessages(new ConsoleGameMessageRender());