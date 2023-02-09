using Microsoft.EntityFrameworkCore;
using Repositories;
using Repositories.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using static DBcontextt.Contex;

namespace DBcontextt
{
    public class Contex
    {
        public class Context : DbContext, Icontex
        {
            public DbSet<User> Users { get; set ; }
            public DbSet<Child> Children { get; set ; }

            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                optionsBuilder.UseSqlServer(@"Data Source=sqlsrv;Initial Catalog='------PracShiratiHod';Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            }
           
        }
    }
}
