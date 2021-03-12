using BizBloqz.Domain.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
namespace BizBloqz.Application.Text.Commands
{
    public class CreateTextCommandHandler : IRequestHandler<CreateTextCommand, bool>
    {
        private IGenericRepository<Domain.Text> _textRepository;
        public CreateTextCommandHandler(IGenericRepository<Domain.Text> textRepository)
        {
            _textRepository = textRepository;
        }
        public async Task<bool> Handle(CreateTextCommand request, CancellationToken cancellationToken)
        {
            try
            {
                return await _textRepository.AddAsync(new Domain.Text(request.TextValue), cancellationToken);
            }
            catch(Exception ex)
            {
                //this can be custom exception but for simplicity for now I'm using generic exception
                throw ex;
            }
            
        }
    }
}
