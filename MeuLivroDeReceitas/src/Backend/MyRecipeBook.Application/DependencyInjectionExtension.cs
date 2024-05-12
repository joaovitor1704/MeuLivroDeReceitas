using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyRecipeBook.Application.Services.AutoMapper;
using MyRecipeBook.Application.Services.Cryptography;
using MyRecipeBook.Application.UseCases.User.Register;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRecipeBook.Application
{
    public static class DependencyInjectionExtension
    {
        public static void AddApplication(this IServiceCollection services, IConfiguration configuration)
        {
            AddAutoMapper(services);
            AddUseCases(services);
            AddPasswordEncipter(services, configuration);
        }

        private static void AddAutoMapper(IServiceCollection services)
        {
            var autoMapper = new AutoMapper.MapperConfiguration(options =>
            {
                options.AddProfile(new AutoMapping());
            }).CreateMapper();

            services.AddScoped(option => autoMapper);
        }

        private static void AddUseCases(IServiceCollection services)
        {
            services.AddScoped<IRegisterUserUseCase, RegisterUserUseCase>();
        }

        private static void AddPasswordEncipter(IServiceCollection services, IConfiguration configuration)
        {
            var additionalKey = configuration.GetValue<string>("Settings:Password:AdditionalKey");

            services.AddScoped(option => new PasswordEncripter(additionalKey!));
        }
    }
}
