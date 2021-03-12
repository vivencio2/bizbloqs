using BizBloqz.Application.Text.Models;
using BizBloqz.Domain.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace BizBloqz.Application.Text.Queries
{
    public class GetTextResponseModelQueryHandler : IRequestHandler<GetTextResponseModelQuery, TextResponseModel>
    {
        private IProcessDataManager<Domain.Text, TextResponseModel> _processDataManager;
        private IGenericRepository<Domain.Text> _textRepository;
        public GetTextResponseModelQueryHandler(IProcessDataManager<Domain.Text, TextResponseModel> processDataManager, IGenericRepository<Domain.Text> textRepository)
        {
            _processDataManager = processDataManager;
            _textRepository = textRepository;
        }
        public async Task<TextResponseModel> Handle(GetTextResponseModelQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var texts = await _textRepository.GetAsync(cancellationToken);
                return await _processDataManager.ProcessDataAsync(texts);
            }
            catch(Exception ex)
            {
                //this can be custom exception but for simplicity for now I'm using generic exception
                throw ex;
            }
            
        }
    }
}
