using NUnit.Framework.Internal;

namespace N.Publisher.Tests.Messages
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