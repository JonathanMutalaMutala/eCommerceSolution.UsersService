﻿using eCommerce.Core.Mappers;
using eCommerce.Core.ServiceContracts;
using eCommerce.Core.Services;
using eCommerce.Core.Validators;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace eCommerce.Core
{
    public static class DependencyInjection
    {
        /// <summary>
        /// Extension method to add Core services to the dependency injection Container
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddCore(this IServiceCollection services)
        {
            services.AddTransient<IUserService,UserService>();
            services.AddAutoMapper(typeof(ApplicationUserMappingProfile).Assembly);
            services.AddValidatorsFromAssemblyContaining<LoginRequestValidator>(); 

            return services;
        }
    }
}
