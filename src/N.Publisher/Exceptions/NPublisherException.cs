using System;
using System.Runtime.Serialization;

namespace N.Publisher.Exceptions
{
    public class NPublisherException : Exception
    {
        public NPublisherException(string errorMessage) : base(errorMessage)
        {
        }
    }
}