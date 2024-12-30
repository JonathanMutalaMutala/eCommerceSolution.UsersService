﻿using eCommerce.Core.RepositoryContracts;
using eCommerce.Infrastructure.DbContext;
using eCommerce.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;


namespace eCommerce.Infrastructure
{
    public  static class DependencyInjection
    {
        /// <summary>
        /// Extension method to add Infrastructure services to the dependency injection Container
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddSingleton<IUSersRepository, UsersRepository>();

            services.AddTransient<DapperDbContext>();

            return services; 
        }
    }
}
