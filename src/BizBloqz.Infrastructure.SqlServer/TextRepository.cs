using BizBloqz.Domain;
using BizBloqz.Domain.Interfaces;
using BizBloqz.Infrastructure.SqlServer.Configuration;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;
using RepoDb;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace BizBloqz.Infrastructure.SqlServer
{
    public class TextRepository : IGenericRepository<Text>
    {
        private SqlServerOptions _configuration;
        public TextRepository(IOptions<SqlServerOptions> options)
        {
            _configuration = options.Value;
        }
        public async Task<bool> AddAsync(Text data, CancellationToken cancellationToken)
        {
            using(var connection = new SqlConnection(_configuration.ConnectionString))
            {
                await connection.InsertAsync<Text>(data).ConfigureAwait(false);
            }
            return true;
        }
        public async Task<IEnumerable<Text>> GetAsync(CancellationToken cancellationToken)
        {
            using (var connection = new SqlConnection(_configuration.ConnectionString))
            {
                return await connection.ExecuteQueryAsync<Text>("EXEC [dbo].[sp_GetEverySecondRowTexts]").ConfigureAwait(false);
            }
        }
    }
}
