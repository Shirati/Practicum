using Microsoft.EntityFrameworkCore;
using Repositories.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public interface Icontex
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Child> Children { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken));
    }
}
