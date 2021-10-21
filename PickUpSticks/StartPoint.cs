using PickUpSticks;

var littleBob = new Player("little bob");
var littleTom = new Player("little tom");

var panel = new SticksRowPanel();
panel.CreateRowAndPutSticks(3);
panel.CreateRowAndPutSticks(5);
panel.CreateRowAndPutSticks(7);

var game = new Game(littleBob, littleTom, panel);
game.Run();