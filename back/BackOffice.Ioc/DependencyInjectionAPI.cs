using BackOffice.Aplicacao.Profiles;
using BackOffice.Aplicacao.Services;
using BackOffice.Aplicacao.Services.Interfaces;
using BackOffice.Dominio.Interfaces;
using BackOffice.Infra.Context;
using BackOffice.Infra.Repositories;
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

            services.AddScoped<IDepartamentoRepository, DepartamentoRepository>();
            services.AddScoped<IPessoaRepository, PessoaRepository>();

            services.AddScoped<IPessoaService, PessoaService>();
            services.AddScoped<IDepartamentoService, DepartamentoService>();

            services.AddAutoMapper(typeof(MappingProfile));

            return services;
        }
    }
}
