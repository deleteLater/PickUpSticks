using PickUpSticks;

var littleBob = new Player("little bob");
var littleTom = new Player("little tom");

var panel = new SticksRowPanel();
panel.CreateRow(3);
panel.CreateRow(5);
panel.CreateRow(7);

var game = new Game(littleBob, littleTom, panel);
game.Run();