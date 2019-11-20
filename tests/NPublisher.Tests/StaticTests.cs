using System.Threading.Tasks;
using FluentAssertions;
using NPublisher.Tests.Messages;
using NUnit.Framework;

namespace NPublisher.Tests
{
    public class StaticTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task NPubilsher_Static_Should_SubscribeTypeOfMessage()
        {
            var ts = new TaskCompletionSource<TestMessage>();
            var ok = false;
            var subscription = NPublisher.SubscribeIt<TestMessage>(x =>
            {
                ok = true;
                ts.SetResult(x);
            });
            
            NPublisher.PublishIt<TestMessage>();

            await ts.Task;

            ok.Should().BeTrue();
        }
        
        [Test]
        public async Task NPubilsher_Static_Should_SubscribeTypeOfMessageWithContent()
        {
            var ts = new TaskCompletionSource<TestMessageWithContent>();
            var ok = false;
            var message = new TestMessageWithContent("sample_data");
            var subscription = NPublisher.SubscribeIt<TestMessageWithContent>(x =>
            {
                ok = true;
                ts.SetResult(x);
                x.Should().Be(message);
            });
            
            NPublisher.PublishIt(message);

            var result = await ts.Task;

            result.Content.Should().Be(message.Content);
            result.Should().Be(message);
        }
    }
}