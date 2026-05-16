using Microsoft.Extensions.DependencyInjection;

namespace CatalogService.Mapper
{
    public static class Registiration 
    {
        public static void AddCustomMapper(this IServiceCollection services)
        {
            services.AddSingleton<Application.Interfaces.AutoMapper.IMapper, AutoMapper.Mapper>();
        }

    }
}
