using System;
using System.Runtime.Serialization;

namespace NPublisher.Exceptions
{
    public class NPublisherException : Exception
    {
        public NPublisherException(string errorMessage) : base(errorMessage)
        {
        }
    }
}