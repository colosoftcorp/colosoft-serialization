using System;
using System.Runtime.Serialization;

namespace Colosoft.Serialization.IO
{
    [Serializable]
    public class CompactSerializationException : Exception
    {
        public CompactSerializationException()
        {
        }

        public CompactSerializationException(string message)
            : base(message)
        {
        }

        protected CompactSerializationException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        public CompactSerializationException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
