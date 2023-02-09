using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using MyDbContext;
using Repositories;
using Repositories.entities;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDbContext
{
    public partial class Context : DbContext, Icontex
    {

        public Context()
        {
        }
        public Context(DbContextOptions<PracShiratiHodContext> options)
        : base(options)
        {
        }

        public virtual DbSet<Child> Children { get; set; }

        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
            => optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Initial Catalog=------PracShiratiHod;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
       
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Child>(entity =>
            {
                entity.HasKey(e => e.NumChild);

                entity.ToTable("Child");

                entity.Property(e => e.DateOfBirth).HasColumnType("date");
                entity.Property(e => e.Fullname).HasMaxLength(50);
                entity.Property(e => e.IdChild).HasMaxLength(50);

                entity.HasOne(d => d.Parent).WithMany(p => p.Children)
                    .HasForeignKey(d => d.ParentId)
                    .HasConstraintName("FK_Child_User");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.NumUser);

                entity.ToTable("User");

                entity.Property(e => e.Date).HasColumnType("date");
                entity.Property(e => e.FirstName)
                    .HasMaxLength(10)
                    .IsFixedLength();
                entity.Property(e => e.Hmo)
                    .HasMaxLength(10)
                    .IsFixedLength()
                    .HasColumnName("HMO");
                entity.Property(e => e.IdUser)
                    .HasMaxLength(10)
                    .IsFixedLength();
                entity.Property(e => e.LastName)
                    .HasMaxLength(10)
                    .IsFixedLength();
                entity.Property(e => e.MaleOrFemale)
                    .HasMaxLength(10)
                    .IsFixedLength();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
