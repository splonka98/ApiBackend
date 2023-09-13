using Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class ApiDbContext : DbContext
    {
        public DbSet<UserEntitie> Users { get; set; }
        public DbSet<RoleEntitie> Roles { get; set; }
        public ApiDbContext(DbContextOptions<ApiDbContext> option) : base(option)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserEntitie>()
                .Property(d => d.Email)
                .IsRequired()
                .HasMaxLength(25);
            modelBuilder.Entity<RoleEntitie>()
                .Property(r => r.RoleId)
                .IsRequired();
        }
    }
}
