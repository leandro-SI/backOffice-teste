using BackOffice.Infra.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackOffice.Ioc
{
    public static class DependencyInjectionAPI
    {
        public static IServiceCollection AddInfraAPI(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<BackOfficeContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                b => b.MigrationsAssembly(typeof(BackOfficeContext).Assembly.FullName)));

            return services;
        }
    }
}
