using System.Collections.Generic;
using System.Threading.Tasks;

namespace BizBloqz.Domain.Interfaces
{
    public interface IProcessDataManager<A, B>
    {
        Task<B> ProcessDataAsync(IEnumerable<A> data);
    }
}
