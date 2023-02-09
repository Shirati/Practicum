using Common.DTOs;


using Microsoft.Extensions.DependencyInjection;
using MyDbContext;
using Repositories;
using Services.entities;
using Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public static class Extension
    {
        public static IServiceCollection AddService(this IServiceCollection services)
        {
            services.AddRepositories();
            services.AddScoped<IService<UserDTO>, UserService>();
            services.AddScoped<IService<ChildDTO>, ChildService>();
           services.AddSingleton<Icontex,Context>();

            services.AddAutoMapper(typeof(MappingProfile));
            return services;
        }
    }
}
