namespace PickUpSticks
{
    public class Game
    {
        private readonly Player _playerA;
        private readonly Player _playerB;
        private readonly SticksRowPanel _sticksRowPanel;

        public Game(Player playerA, Player playerB, SticksRowPanel sticksRowPanel)
        {
            _playerA = playerA;
            _playerB = playerB;
            _sticksRowPanel = sticksRowPanel;
        }

        public void Run()
        {
            var playerAPickSuccess = false;
            var playerBPickSuccess = false;
            
            while (_sticksRowPanel.HasStick)
            {
                playerAPickSuccess = _playerA.PickUpSticksRandomly(_sticksRowPanel);
                playerBPickSuccess = _playerB.PickUpSticksRandomly(_sticksRowPanel);
            }

            if (playerBPickSuccess)
            {
                GameLogger.PanelLog($"{_playerA.Name} win the game!");
            }
            else if (playerAPickSuccess)
            {
                GameLogger.PanelLog($"{_playerB.Name} win the game!");
            }
        }
    }
}