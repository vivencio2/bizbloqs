using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BizBloqz.Domain.Interfaces
{
    public interface IGenericRepository<T>
    {
        Task<IEnumerable<T>> GetAsync(CancellationToken cancellationToken);
        Task<bool> AddAsync(T data, CancellationToken cancellationToken);
    }
}
