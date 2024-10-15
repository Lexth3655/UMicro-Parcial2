using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using UMicro.Domain.Interfaces;
using UMicro.Persistence.Data;
using UMicro.Persistence.Mapper;
using UMicro.Persistence.Repository;
using UMicro.Persistence.Unit;

namespace UMicro.Persistence
{
    public static class Extension
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services)
        {
        
            var serviceProvider = services.BuildServiceProvider();
            var configuration = serviceProvider.GetService<IConfiguration>();
            services.AddDbContext<ApplicationDbContext>(opt => opt.UseSqlServer(configuration["sql:cnx"]));
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddAutoMapper(config =>
            {
                config.AddProfile<MapperProfile>();
            });
            return services;
        }
    }
}
