using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace BizBloqz.Services.UnitTests
{
    public class ProcessManagerTests
    {
        [Fact]
        public async Task ProcessManagerTest_SuccessfulVowelCountSimple()
        {
            var textList = new List<Domain.Text>();
            textList.Add(new Domain.Text("abcdef1"));
            var processManager = new ProcessManager();
            var result = await processManager.ProcessDataAsync(textList);
            Assert.Equal(2, result.VowelCount);
        }
        [Fact]
        public async Task ProcessManagerTest_SuccessfulVowelCountWithSpaceAndSpecialChars()
        {
            var textList = new List<Domain.Text>();
            textList.Add(new Domain.Text("%aeiou# 12345"));
            var processManager = new ProcessManager();
            var result = await processManager.ProcessDataAsync(textList);
            Assert.Equal(5, result.VowelCount);
        }
        [Fact]
        public async Task ProcessManagerTest_SuccessfulVowelCountMultipleTexts()
        {
            var textList = new List<Domain.Text>();
            textList.Add(new Domain.Text("%aeiou# 12345"));
            textList.Add(new Domain.Text("aeiou 12345"));
            var processManager = new ProcessManager();
            var result = await processManager.ProcessDataAsync(textList);
            Assert.Equal(10, result.VowelCount);
        }
        [Fact]
        public async Task ProcessManagerTest_SuccessfulVowelCountWithEmptyString()
        {
            var textList = new List<Domain.Text>();
            textList.Add(new Domain.Text(""));
            var processManager = new ProcessManager();
            var result = await processManager.ProcessDataAsync(textList);
            Assert.Equal(0, result.VowelCount);
        }
        [Fact]
        public async Task ProcessManagerTest_FailVowelCountSimple()
        {
            var textList = new List<Domain.Text>();
            textList.Add(new Domain.Text("abcdef1"));
            var processManager = new ProcessManager();
            var result = await processManager.ProcessDataAsync(textList);
            Assert.NotEqual(3, result.VowelCount);
        }
        [Fact]
        public async Task ProcessManagerTest_FailVowelCountWithSpaceAndSpecialChars()
        {
            var textList = new List<Domain.Text>();
            textList.Add(new Domain.Text("%aeiou# 12345"));
            var processManager = new ProcessManager();
            var result = await processManager.ProcessDataAsync(textList);
            Assert.NotEqual(6, result.VowelCount);
        }
        [Fact]
        public async Task ProcessManagerTest_FailVowelCountMultipleTexts()
        {
            var textList = new List<Domain.Text>();
            textList.Add(new Domain.Text("%aeiou# 12345"));
            textList.Add(new Domain.Text("aeiou 12345"));
            var processManager = new ProcessManager();
            var result = await processManager.ProcessDataAsync(textList);
            Assert.NotEqual(11, result.VowelCount);
        }
    }
}
