using System.Threading.Tasks;

namespace NPublisher
{
    public interface IPublisher
    {
        void Publish<TMessage>()
            where TMessage : NMessage;
        
        Task PublishAsync<TMessage>()
            where TMessage : NMessage;
        
        
    }
    
    public class Publisher
    {
        
    }
}