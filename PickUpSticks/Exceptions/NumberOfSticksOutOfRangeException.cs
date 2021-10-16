using System;

namespace PickUpSticks.Exceptions
{
    [Serializable]
    public class NumberOfSticksOutOfRangeException : Exception
    {
        public NumberOfSticksOutOfRangeException()
        {
        }

        public NumberOfSticksOutOfRangeException(string message)
            : base(message)
        {
        }

        public NumberOfSticksOutOfRangeException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}