using Spoofi.FreudBot.Utils.Extensions;
using Xunit;

namespace Spoofi.FreudBot.Utils.Tests
{
    public class StringExtensionsTests
    {
        [Fact]
        public void HasValueTest()
        {
            Assert.False("".HasValue());
            Assert.False(" ".HasValue());
            Assert.False(((string)null).HasValue());
            Assert.True("string".HasValue());
        }
    }
}
