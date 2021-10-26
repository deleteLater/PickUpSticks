using System;
using System.Linq;
using PickUpSticks.Exceptions;

namespace PickUpSticks
{
    public class StickPickedEventArgs : EventArgs
    {
        public string PlayerName { get; set; }
        public int RowNumber { get; set; }
        public int NumberOfSticks { get; set; }
    }

    public class Player
    {
        public string Name { get; }

        public Player(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new PlayerNameNotValidException("player name cannot be empty or null.");
            }

            Name = name;
        }

        public event EventHandler<StickPickedEventArgs> StickPicked;
        protected virtual void OnStickPicked(int rowNumber, int numberOfSticks)
        {
            var eventArgs = new StickPickedEventArgs
            {
                PlayerName = Name,
                RowNumber = rowNumber,
                NumberOfSticks = numberOfSticks
            };

            StickPicked?.Invoke(this, eventArgs);
        }

        public void PickupSticks(SticksRowPanel panel, int rowNumber, int numberOfSticks)
        {
            if (numberOfSticks < 1)
            {
                throw new CannotTakeLessThanOneStickException("cannot take less than one stick at one time.");
            }

            OnStickPicked(rowNumber, numberOfSticks);
            
            panel.RemoveSticks(rowNumber, numberOfSticks);
        }

        public bool PickUpSticksRandomly(SticksRowPanel panel)
        {
            if (!panel.HasStick)
            {
                return false;
            }

            // 1. get a random row that has sticks
            // 2. pickup a random number of sticks based on the random row
            var random = new Random();

            var rowsHasStick = panel.CurrentRows
                .Where(x => x.HasStick)
                .ToArray();
            var randomRow = rowsHasStick.ElementAt(random.Next(rowsHasStick.Length));
            var randomRowNumber = randomRow.RowNumber;
            var randomNumberOfSticks = random.Next(1, randomRow.StickCount);

            PickupSticks(panel, randomRowNumber, randomNumberOfSticks);

            return true;
        }
    }
}