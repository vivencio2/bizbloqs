using System;
using System.Threading.Tasks;
using Xunit;

namespace BizBloqz.Domain.UnitTests
{
    public class TextTests
    {
        [Fact]
        public void TextValueTests_Successful()
        {
            var text = new Text("Test1");
            Assert.True(text.Value.Length == 5);
        }
        [Fact]
        public void TextIdTests_Successful()
        {
            var text = new Text("Test1");
            Assert.IsType<Guid>(text.Id);
        }
    }
}
