using System;
using System.Collections.Generic;
using System.Linq;

namespace PickUpSticks
{
    public class SticksRow : IEquatable<SticksRow>
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

        public bool Equals(SticksRow other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return RowNumber == other.RowNumber && Equals(_sticks, other._sticks);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == GetType() && Equals((SticksRow)obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(RowNumber, _sticks);
        }

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