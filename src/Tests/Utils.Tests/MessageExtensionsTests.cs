using Spoofi.FreudBot.Utils.Extensions;
using Telegram.Bot.Types;
using Xunit;

namespace Spoofi.FreudBot.Utils.Tests
{
    public class MessageExtensionsTests
    {
        private readonly Message _textMessage = new Message {Text = "string1 string2"};
        private readonly Message _commandMessage = new Message {Text = "/cmd 1 2"};

        [Fact]
        public void IsTextTest()
        {
            Assert.True(_textMessage.IsText());
            Assert.False(_commandMessage.IsText());
        }

        [Fact]
        public void IsCommandTest()
        {
            Assert.False(_textMessage.IsCommand());
            Assert.True(_commandMessage.IsCommand());
        }

        [Fact]
        public void GetCommandTest()
        {
            Assert.Equal(_commandMessage.GetCommand(), "/cmd");
            Assert.Equal(_textMessage.GetCommand(), null);
        }
    }
}
