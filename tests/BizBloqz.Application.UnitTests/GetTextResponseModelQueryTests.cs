using BizBloqz.Application.Text.Models;
using BizBloqz.Application.Text.Queries;
using BizBloqz.Domain.Interfaces;
using NSubstitute;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace BizBloqz.Application.UnitTests
{
    public class GetTextResponseModelQueryTests
    {
        private IGenericRepository<Domain.Text> _textRepository;
        private IProcessDataManager<Domain.Text, TextResponseModel> _processDataManager;
        public GetTextResponseModelQueryTests()
        {
            _textRepository = Substitute.For<IGenericRepository<Domain.Text>>();
            _processDataManager = Substitute.For<IProcessDataManager<Domain.Text, TextResponseModel>>();
        }
        [Fact]
        public async Task GetTextResponseModelQuery_Successful()
        {
            var textList = new List<Domain.Text>();
            textList.Add(new Domain.Text("Test1"));
            textList.Add(new Domain.Text("Test2"));
            _textRepository.GetAsync(CancellationToken.None).Returns(textList);
            _processDataManager.ProcessDataAsync(Arg.Any<IEnumerable<Domain.Text>>()).Returns(new TextResponseModel() { VowelCount = 2 });
            var handler = new GetTextResponseModelQueryHandler(_processDataManager, _textRepository);
            var request = new GetTextResponseModelQuery();
            var result = await handler.Handle(request, CancellationToken.None);
            Assert.True(result.VowelCount == 2);
        }
        [Fact]
        public async Task GetTextResponseModelQuery_Fail()
        {
            var textList = new List<Domain.Text>();
            textList.Add(new Domain.Text("Test1"));
            textList.Add(new Domain.Text("Test2"));
            _textRepository.GetAsync(CancellationToken.None).Returns(textList);
            _processDataManager.ProcessDataAsync(Arg.Any<IEnumerable<Domain.Text>>()).Returns(new TextResponseModel() { VowelCount = 0 });
            var handler = new GetTextResponseModelQueryHandler(_processDataManager, _textRepository);
            var request = new GetTextResponseModelQuery();
            var result = await handler.Handle(request, CancellationToken.None);
            Assert.False(result.VowelCount == 2);
        }
    }
}
