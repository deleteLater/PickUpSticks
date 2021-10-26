using System;

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

        public event EventHandler<string> GameRunning;
        protected virtual void OnGameRunning(string message)
            => GameRunning?.Invoke(this, message);

        public void Run()
        {
            OnGameRunning("the game begins");

            var playerAPickSuccess = false;
            var playerBPickSuccess = false;

            while (_sticksRowPanel.HasStick)
            {
                playerAPickSuccess = _playerA.PickUpSticksRandomly(_sticksRowPanel);
                playerBPickSuccess = _playerB.PickUpSticksRandomly(_sticksRowPanel);
            }

            if (playerBPickSuccess)
            {
                OnGameRunning($"{_playerA.Name} win the game!");
            }
            else if (playerAPickSuccess)
            {
                OnGameRunning($"{_playerB.Name} win the game!");
            }
        }
    }
}