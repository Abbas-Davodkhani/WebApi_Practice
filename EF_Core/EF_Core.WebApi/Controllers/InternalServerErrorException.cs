using System.Runtime.Serialization;

namespace EF_Core.WebApi.Controllers
{
    [Serializable]
    internal class InternalServerErrorException : Exception
    {
        public InternalServerErrorException()
        {
        }

        public InternalServerErrorException(string? message) : base(message)
        {
        }

        public InternalServerErrorException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected InternalServerErrorException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}