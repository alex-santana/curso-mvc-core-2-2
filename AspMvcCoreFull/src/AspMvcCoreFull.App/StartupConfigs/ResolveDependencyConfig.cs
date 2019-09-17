using AspMvcCoreFull.App.Data;
using AspMvcCoreFull.Business.Interfaces;
using AspMvcCoreFull.Data.Context;
using AspMvcCoreFull.Data.Repository;
using AutoMapper;
using AutoMapper.Configuration;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspMvcCoreFull.App.StartupConfigs
{
    public static class ResolveDependencyConfig
    {
        public static IServiceCollection DependencyInjectionConfig(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(Startup));

            services.AddMvc(options =>
                        options.ModelBindingMessageProvider.SetValueMustBeANumberAccessor(x => "O campo deve ser numérico")
            ).SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddScoped<MeuDbContext>();
            services.AddScoped<IProdutoRepository, ProdutoRepository>();
            services.AddScoped<IFornecedorRepository, FornecedorRepository>();
            services.AddScoped<IEnderecoRepository, EnderecoRepository>();

            return services;
        }

        public static IServiceCollection IdentityConfig(this IServiceCollection services, Microsoft.Extensions.Configuration.IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("DefaultConnection")));

            services.AddDbContext<MeuDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.AddDefaultIdentity<IdentityUser>()
                .AddDefaultUI(UIFramework.Bootstrap4)
                .AddEntityFrameworkStores<ApplicationDbContext>();

            return services;
        }
    }
}
