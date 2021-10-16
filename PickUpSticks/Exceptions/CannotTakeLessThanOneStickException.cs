using System;

namespace PickUpSticks.Exceptions
{
    [Serializable]
    public class CannotTakeLessThanOneStickException : Exception
    {
        public CannotTakeLessThanOneStickException()
        {
        }

        public CannotTakeLessThanOneStickException(string message)
            : base(message)
        {
        }

        public CannotTakeLessThanOneStickException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}