using Spoofi.FreudBot.Utils.Extensions;
using Telegram.Bot.Types;
using Xunit;

namespace Spoofi.FreudBot.Utils.Tests
{
    public class MessageExtensionsTests
    {
        private readonly Message _textMessage = new Message {Text = "string1 string2"};
        private readonly Message _commandMessage = new Message {Text = "/cmd 0 1 2"};

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

        [Fact]
        public void GetCommandParamsTest()
        {
            Assert.Equal(_textMessage.GetCommandParams().Length, 0);
            var parameters = _commandMessage.GetCommandParams();
            Assert.Equal(parameters.Length, 3);
            for (var i = 0; i < 3; i++)
                Assert.Equal(parameters[i], i.ToString());
        }
    }
}
