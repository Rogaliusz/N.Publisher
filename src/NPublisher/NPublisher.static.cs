using System;

namespace NPublisher
{
    public partial class NPublisher
    {
        private static readonly object _createLock = new object();
        
        private static NPublisher _instance;

        public static void PublishIt<TMessage>(TMessage message = null)
            where TMessage : NMessage
            => Create().Publish(message);

        public static NSubscription SubscribeIt<TMessage>(Action<TMessage> action)
            => Create().Subscribe(action);

        public static void UnsubscribeIt(NSubscription subscriptionToRemove)
            => Create().Unsubscribe(subscriptionToRemove);
        
        public static NPublisher Create()
        {
            if (_instance == null)
            {
                lock (_createLock)
                {
                    if (_instance == null)
                    {
                        _instance = new NPublisher();
                    }
                }
            }

            return _instance;
        }
        
        
    }
}