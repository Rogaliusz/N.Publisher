using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NPublisher.Exceptions;

namespace NPublisher
{

    public partial class NPublisher
    {
        private readonly IDictionary<Type, Queue<NSubscription>> _subscriptions = new Dictionary<Type, Queue<NSubscription>>();
        
        public void Publish<TMessage>(TMessage message = null)
            where TMessage : NMessage
        {
            if (!_subscriptions.ContainsKey(typeof(TMessage)))
            {
                return;
            }

            message = message ?? CreateMessage(typeof(TMessage)) as TMessage;

            var subscriptions = _subscriptions[typeof(TMessage)];
            foreach (var subscription in subscriptions)
            {
                subscription.Action.Invoke(message);
            }
        }
        
        public NSubscription Subscribe<TMessage>(Action<TMessage> action)
        {
            if (action == null)
                throw new NPublisherException("Action must be not null.");
            
            var subscription = new NSubscription(this, Convert(action));

            if (!_subscriptions.ContainsKey(typeof(TMessage)))
            {
                _subscriptions.Add(typeof(TMessage), new Queue<NSubscription>());
            }
            
            _subscriptions[typeof(TMessage)].Enqueue((subscription));
            
            return subscription;
        }

        public void Unsubscribe(NSubscription subscriptionToRemove)
        {
            var subscriptions = _subscriptions.Values.FirstOrDefault(x => x.Contains(subscriptionToRemove));
            if (subscriptions == null)
            {
                return;
            }

            var queueCopy = new Queue<NSubscription>();
            
            while (subscriptions.Any())
            {
                queueCopy.Enqueue(subscriptions.Dequeue());
            }

            while (queueCopy.Any())
            {
                var sub = queueCopy.Dequeue();
                if (sub == subscriptionToRemove)
                {
                    continue;
                }
                
                subscriptions.Enqueue(sub);
            }


        }

        private Action<object> Convert<T>(Action<T> myActionT)
        {
            return myActionT == null 
                ? null 
                : new Action<object>(o => myActionT((T)o));
        }
        
        private object CreateMessage(Type type)
        {
            return Activator.CreateInstance(type);
        }
        
    }
}