using Application.Repositories;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;
using Persistence.Repositories.Products;
using Persistence.Repositories;
using Api.Middlewares;
using Infrastructure.Configuration.RedisConfiguration;

namespace Api.Extensions
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApi(this IServiceCollection services,ConfigurationManager configuration)
        {
            services.AddDbContext<AppDbContext>(opt => opt.UseSqlServer(configuration.GetConnectionString("DevConnection")));
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            services.AddTransient<GlobalExceptionMiddleware>();  

            return services;
        }
    }
}
