using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace BizBloqz.Services.UnitTests
{
    public class ProcessManagerLiteTests
    {
        [Fact]
        public async Task ProcessManagerLiteTest_SuccessfulVowelCountSimple()
        {
            var textList = new List<Domain.Text>();
            textList.Add(new Domain.Text("abcdef1"));
            var processManager = new ProcessManagerLite();
            var result = await processManager.ProcessDataAsync(textList);
            Assert.Equal(2, result.VowelCount);
        }
        [Fact]
        public async Task ProcessManagerLiteTest_SuccessfulVowelCountWithSpaceAndSpecialChars()
        {
            var textList = new List<Domain.Text>();
            textList.Add(new Domain.Text("%aeiou# 12345"));
            var processManager = new ProcessManagerLite();
            var result = await processManager.ProcessDataAsync(textList);
            Assert.Equal(5, result.VowelCount);
        }
        [Fact]
        public async Task ProcessManagerLiteTest_SuccessfulVowelCountMultipleTexts()
        {
            var textList = new List<Domain.Text>();
            textList.Add(new Domain.Text("%aeiou# 12345"));
            textList.Add(new Domain.Text("aeiou 12345"));
            var processManager = new ProcessManagerLite();
            var result = await processManager.ProcessDataAsync(textList);
            Assert.Equal(10, result.VowelCount);
        }
        [Fact]
        public async Task ProcessManagerLiteTest_SuccessfulVowelCountWithEmptyString()
        {
            var textList = new List<Domain.Text>();
            textList.Add(new Domain.Text(""));
            var processManager = new ProcessManagerLite();
            var result = await processManager.ProcessDataAsync(textList);
            Assert.Equal(0, result.VowelCount);
        }
        [Fact]
        public async Task ProcessManagerLiteTest_FailVowelCountSimple()
        {
            var textList = new List<Domain.Text>();
            textList.Add(new Domain.Text("abcdef1"));
            var processManager = new ProcessManagerLite();
            var result = await processManager.ProcessDataAsync(textList);
            Assert.NotEqual(3, result.VowelCount);
        }
        [Fact]
        public async Task ProcessManagerLiteTest_FailVowelCountWithSpaceAndSpecialChars()
        {
            var textList = new List<Domain.Text>();
            textList.Add(new Domain.Text("%aeiou# 12345"));
            var processManager = new ProcessManagerLite();
            var result = await processManager.ProcessDataAsync(textList);
            Assert.NotEqual(6, result.VowelCount);
        }
        [Fact]
        public async Task ProcessManagerLiteTest_FailVowelCountMultipleTexts()
        {
            var textList = new List<Domain.Text>();
            textList.Add(new Domain.Text("%aeiou# 12345"));
            textList.Add(new Domain.Text("aeiou 12345"));
            var processManager = new ProcessManagerLite();
            var result = await processManager.ProcessDataAsync(textList);
            Assert.NotEqual(11, result.VowelCount);
        }
    }
}
