using Application.Features.Products;
using Microsoft.Extensions.DependencyInjection;

namespace Application
{
    public static partial class DependencyInjection
    {
        public static IServiceCollection ConfigureApplicationLayer(this IServiceCollection services)
        {
            services.AddScoped<IProductService, ProductService>();

            return services;
        }
    }
}
