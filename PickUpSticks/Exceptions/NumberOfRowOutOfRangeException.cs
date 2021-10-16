using System;

namespace PickUpSticks.Exceptions
{
    [Serializable]
    public class NumberOfRowOutOfRangeException : Exception
    {
        public NumberOfRowOutOfRangeException()
        {
        }

        public NumberOfRowOutOfRangeException(string message)
            : base(message)
        {
        }

        public NumberOfRowOutOfRangeException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}