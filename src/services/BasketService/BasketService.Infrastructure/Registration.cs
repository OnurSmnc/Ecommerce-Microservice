using BasketService.Application.Services;
using BasketService.Infrastructure.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasketService.Infrastructure
{
    public static class Registration
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            var redisConnectionString =
            configuration.GetConnectionString("RedisConnection")
            ?? "basket.db:6379";

            services.AddSingleton<IConnectionMultiplexer>(sp =>
            {
                var config = ConfigurationOptions.Parse(redisConnectionString, true);
                return ConnectionMultiplexer.Connect(config);
            });

            services.AddScoped<IBasketItemService, BasketItemService>();

            return services;
        }
    }
}
