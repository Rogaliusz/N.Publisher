using System;

namespace N.Publisher
{
    public class NSubscription : IDisposable
    {
        public NPublisher Current { get; }
        
        internal Action<object> Action { get; }

        internal NSubscription(
            NPublisher current,
            Action<object> action)
        {
            Action = action;
            Current = current;
        }

        public void Unsubscribe()
        {
            Current.Unsubscribe(this);
        }

        public void Dispose()
        {
        }
    }
}