using System;
using System.Linq;

namespace PickUpSticks
{
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

        public void PickUpSticks(SticksRowPanel panel, int rowNumber, int numberOfSticks)
        {
            GameLogger.PlayerLog($"{Name} chose row {rowNumber}, take {numberOfSticks} sticks.");
            
            panel.RemoveSticks(rowNumber, numberOfSticks);
        }

        public bool PickUpSticksRandomly(SticksRowPanel panel)
        {
            if (!panel.HasStick)
            {
                return false;
            }

            // 1. get a random row that has sticks
            // 2. get a random number of sticks based on the random row
            var random = new Random();
            
            var rowsHasStick = panel.CurrentRows
                .Where(x => x.HasStick)
                .Select(x => x.RowNumber)
                .ToArray();
            
            var randomRowNumber = rowsHasStick[random.Next(rowsHasStick.Length)];
            var randomRow = panel.GetRow(randomRowNumber);
            var randomNumberOfSticks = random.Next(1, randomRow.StickCount);

            PickUpSticks(panel, randomRowNumber, randomNumberOfSticks);
            
            return true;
        }
    }
}