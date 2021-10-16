using System.Collections.Generic;
using System.Linq;
using PickUpSticks.Exceptions;

namespace PickUpSticks
{
    public class SticksRow
    {
        private readonly List<Stick> _sticks;
        public int RowNumber { get; }
        public SticksRow(int rowNumber, int numberOfSticks)
        {
            RowNumber = rowNumber;
            _sticks = Enumerable.Repeat(new Stick(), numberOfSticks).ToList();
        }

        public bool HasStick => _sticks.Any();
        public int StickCount => _sticks.Count;

        public void RemoveSticks(int numberOfSticks)
        {
            if (numberOfSticks < 0 || numberOfSticks > StickCount)
            {
                throw new NumberOfSticksOutOfRangeException(
                    $"cannot remove {numberOfSticks} sticks from row, this row has {StickCount} sticks only."
                );
            }

            GameLogger.PanelLog($"-- row {RowNumber} remove {numberOfSticks} sticks, remain {StickCount - numberOfSticks} sticks.");
            
            _sticks.RemoveRange(0, numberOfSticks);
        }
    }
}