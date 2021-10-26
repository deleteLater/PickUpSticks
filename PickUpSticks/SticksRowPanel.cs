using System;
using System.Collections.Generic;
using System.Linq;
using PickUpSticks.Exceptions;

namespace PickUpSticks
{
    public class StickRemovedEventArgs : EventArgs
    {
        public int RowNumber { get; set; }
        public int NumberOfSticksToRemove { get; set; }
        public int RemainedSticks { get; set; }
    }
    
    public class SticksRowPanel
    {
        private readonly List<SticksRow> _rows;

        public SticksRowPanel()
        {
            _rows = new List<SticksRow>();
        }

        public int RowsCount => _rows.Count;
        public IEnumerable<SticksRow> CurrentRows => _rows.AsEnumerable();
        public bool HasStick => _rows.Any(x => x.HasStick);

        public SticksRow CreateRowAndPutSticks(int numberOfSticks)
        {
            var rowNumber = _rows.Count + 1;
            var sticksRow = new SticksRow(rowNumber, numberOfSticks);

            _rows.Add(sticksRow);

            return sticksRow;
        }

        public SticksRow GetRow(int rowNumber)
        {
            var sticksRow = _rows.FirstOrDefault(x => x.RowNumber == rowNumber);

            return sticksRow;
        }

        public event EventHandler<StickRemovedEventArgs> StickRemoved;
        public void RemoveSticks(int rowNumber, int numberOfSticksToRemove)
        {
            var row = _rows.FirstOrDefault(x => x.RowNumber == rowNumber);
            if (row == null)
            {
                throw new NumberOfRowOutOfRangeException(
                    $"panel does not exist a row with rowNumber {rowNumber}"
                );
            }
            
            OnStickRemoved(row, numberOfSticksToRemove);

            row.RemoveSticks(numberOfSticksToRemove);
        }

        protected virtual void OnStickRemoved(SticksRow row, int numberOfSticksToRemove)
        {
            var eventArgs = new StickRemovedEventArgs
            {
                RowNumber = row.RowNumber,
                NumberOfSticksToRemove = numberOfSticksToRemove, 
                RemainedSticks = row.StickCount - numberOfSticksToRemove
            };
            
            StickRemoved?.Invoke(this, eventArgs);
        }
    }
}