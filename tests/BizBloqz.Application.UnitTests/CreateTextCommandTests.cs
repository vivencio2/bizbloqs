using BizBloqz.Application.Text.Commands;
using BizBloqz.Domain.Interfaces;
using NSubstitute;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace BizBloqz.Application.UnitTests
{
    public class CreateTextCommandTests
    {
        private IGenericRepository<Domain.Text> _textRepository;
        public CreateTextCommandTests()
        {
            _textRepository = Substitute.For<IGenericRepository<Domain.Text>>();
        }
        [Fact]
        public async Task CreateTextCommand_Successful()
        {
            _textRepository.AddAsync(Arg.Any<Domain.Text>(), CancellationToken.None).Returns(true);
            var handler = new CreateTextCommandHandler(_textRepository);
            var request = new CreateTextCommand("JR test");
            var result = await handler.Handle(request, CancellationToken.None);
            Assert.True(result);
        }
        [Fact]
        public async Task CreateTextCommand_Fail()
        {
            _textRepository.AddAsync(Arg.Any<Domain.Text>(), CancellationToken.None).Returns(false);
            var handler = new CreateTextCommandHandler(_textRepository);
            var request = new CreateTextCommand("JR test");
            var result = await handler.Handle(request, CancellationToken.None);
            Assert.False(result);
        }
        [Fact]
        public async Task CreateTextCommand_Validator_Successful()
        {
            var validator = new CreateTextCommandValidator();
            var request = new CreateTextCommand("JR test");
            var result = await validator.ValidateAsync(request);
            Assert.True(result.IsValid);
        }

        [Fact]
        public async Task CreateTextCommand_Validator_Fail()
        {
            var validator = new CreateTextCommandValidator();
            var request = new CreateTextCommand("JR test long test more than 20 characters another character to make it long");
            var result = await validator.ValidateAsync(request);
            Assert.False(result.IsValid);
        }
    }
}
