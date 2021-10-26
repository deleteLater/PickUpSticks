using System;

namespace PickUpSticks.Exceptions
{
    [Serializable]
    public class MessageContentNotValidException : Exception
    {
        public MessageContentNotValidException()
        {
        }

        public MessageContentNotValidException(string message)
            : base(message)
        {
        }

        public MessageContentNotValidException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}