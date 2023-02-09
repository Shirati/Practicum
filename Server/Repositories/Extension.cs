using Microsoft.Extensions.DependencyInjection;
using Repositories.entities;
using Repositories.Interface;
using Repositories.repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public static class Extension
    {
        public static void AddRepositories(this IServiceCollection service)
        {
            service.AddScoped<Ientity<User>, UserRepository>();
            service.AddScoped<Ientity<Child>, ChildRepository>();
        }
    }
}
