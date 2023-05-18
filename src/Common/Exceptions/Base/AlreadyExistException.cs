using System.Runtime.Serialization;

namespace Common.Exceptions.Base
{
    public class AlreadyExistException : Exception
    {
        public AlreadyExistException()
        {
        }

        public AlreadyExistException(string? message) : base(message)
        {
        }

        public AlreadyExistException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected AlreadyExistException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}