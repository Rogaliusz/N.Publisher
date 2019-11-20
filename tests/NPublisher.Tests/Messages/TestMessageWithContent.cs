using NUnit.Framework.Internal;

namespace NPublisher.Tests.Messages
{
    public class TestMessageWithContent : NMessage
    {
        public string Content { get; }

        public TestMessageWithContent()
        {
            
        }
        
        public TestMessageWithContent(string content)
        {
            Content = content;
        }
    }
}