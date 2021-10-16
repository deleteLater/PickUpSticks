using System.Collections.Generic;
using System.Linq;

namespace PickUpSticks
{
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

        public SticksRow CreateRow(int numberOfSticks)
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

        public void RemoveSticks(int rowNumber, int numberOfSticks)
        {
            var row = _rows.FirstOrDefault(x => x.RowNumber == rowNumber);
            if (row == null)
            {
                throw new NumberOfRowOutOfRangeException(
                    $"panel does not exist a row with rowNumber {rowNumber}"
                );
            }

            row.RemoveSticks(numberOfSticks);
        }
    }
}