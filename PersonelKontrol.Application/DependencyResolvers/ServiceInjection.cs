using Microsoft.Extensions.DependencyInjection;
using PersonelKontrol.Application.Mapping;

namespace PersonelKontrol.Application.DependencyResolvers
{
    public static class ServiceInjection
    {
        public static void AddApplicationLayerInjections(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(MapProfile));
        }
    }
}
