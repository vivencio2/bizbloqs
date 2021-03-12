using BizBloqz.Application.Text.Models;
using BizBloqz.Domain;
using BizBloqz.Domain.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace BizBloqz.Services.Configuration
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddManagers(this IServiceCollection services)
        {
            //services.AddScoped<IProcessDataManager<Text, TextResponseModel>, ProcessManager>();
            services.AddScoped<IProcessDataManager<Text,TextResponseModel>, ProcessManagerLite>();
            return services;
        }
    }
}
