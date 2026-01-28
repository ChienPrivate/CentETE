using CentETE.Application.Interfaces;
using CentETE.Application.Interfaces.Store;
using CentETE.Infrastructure.Persistence.DbContext;
using CentETE.Infrastructure.Repositories;
using CentETE.Infrastructure.Repositories.Store;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CentETE.Infrastructure.DependencyInjection
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"), b => b.MigrationsAssembly("CentETE.WebApi")));

            // Register repositories
            // services.AddScoped<IUserRepository, UserRepository>();

            services.AddScoped<IStoreWriteRepository, StoreWriteRepository>();
            services.AddScoped<IStoreReadRepository, StoreReadRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}
