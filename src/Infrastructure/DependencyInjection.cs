using Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static partial class DependencyInjection
    {
        public static IServiceCollection ConfigureInfrastructureLayer(this IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(option =>
            {
                option.UseSqlServer("test");
            });

            return services;
        }
    }
}
