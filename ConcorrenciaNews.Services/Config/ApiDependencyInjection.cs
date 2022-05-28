using ConcorrenciaNews.AppDbContext;
using ConcorrenciaNews.Contracts.Repositories;
using ConcorrenciaNews.Data.Repositories;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StackExchange.Redis;
using System.Reflection;

namespace ConcorrenciaNews.Services.Config
{
    public static class ApiDependencyInjection
    {
        public static IServiceCollection AddApiServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddSingleton<IConnectionMultiplexer>(sp =>
                ConnectionMultiplexer.Connect(new ConfigurationOptions
                {
                    EndPoints = { config.GetConnectionString("RedisConnection") },
                    AbortOnConnectFail = false,
                }
            ));

            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddDbContext<MainDbContext>();
            services.AddScoped<INewsRepository, NewsRepository>();
            services.AddScoped<IQueryRepository, QueryRepository>();

            return services;
        }
    }
}