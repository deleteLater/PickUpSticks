using System;

namespace PickUpSticks
{
    [Serializable]
    public class PlayerNameNotValidException : Exception
    {
        public PlayerNameNotValidException()
        {
        }

        public PlayerNameNotValidException(string message)
            : base(message)
        {
        }

        public PlayerNameNotValidException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}