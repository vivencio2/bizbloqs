using BizBloqz.Domain;
using BizBloqz.Domain.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using RepoDb;

namespace BizBloqz.Infrastructure.SqlServer.Configuration
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services, IConfiguration configuration)
        {
            RepoDbConfigInit();
            services.Configure<SqlServerOptions>(options => options.ConnectionString = configuration.GetConnectionString("BizBloqzDB"));
            services.AddScoped<IGenericRepository<Text>, TextRepository>();
            return services;
        }

        private static void RepoDbConfigInit()
        {
            FluentMapper.Entity<Text>()
                .Table("[dbo].[Texts]")
                .Primary(e => e.Id)
                .Identity(e => e.Id)
                .Column(e => e.Value, "[TextValue]");
            SqlServerBootstrap.Initialize();
        }
    }
}
