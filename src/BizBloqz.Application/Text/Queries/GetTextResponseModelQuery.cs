using BizBloqz.Application.Text.Models;
using MediatR;

namespace BizBloqz.Application.Text.Queries
{
    public class GetTextResponseModelQuery : IRequest<TextResponseModel>{}
}
