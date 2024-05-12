using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyRecipeBook.Domain.Repositories;
using MyRecipeBook.Domain.Repositories.User;
using MyRecipeBook.Infraestruture.DataAcess;
using MyRecipeBook.Infraestruture.DataAcess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRecipeBook.Infraestruture
{
    public static class DependencyInjectionExtension
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            AddRepository(services);
            AddDbContext(services, configuration);
        }

        private static void AddDbContext(IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("Connection");
            var serverVersion = new MySqlServerVersion(new Version(8,0,36));

            services.AddDbContext<MyRecipeBookDbContext>(dbContextOptions =>
            {
                dbContextOptions.UseMySql(connectionString, serverVersion);
            });
        }

        private static void AddRepository(IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();  

            services.AddScoped<IUserWriteOnlyRepository, UserRepository>();
            services.AddScoped<IUserReadOnlyRepository, UserRepository>();
        }
    }
}
