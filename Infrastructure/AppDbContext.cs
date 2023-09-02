using Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class AppDbContext : DbContext
    {
        private string _connectionString =
            "Server=(localdb)\\mssqllocaldb;Database=DogCalDb;Trusted_Connection=True;";
        public DbSet<DogEntity> Dogs { get; set; }
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<AddressEntity> Address { get; set; }
        public DbSet<RoleEntity> Roles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<DogEntity>()
                .Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(25);
            modelBuilder.Entity<DogEntity>()
                .Property(e => e.Age)
                .IsRequired();
            modelBuilder.Entity<DogEntity>()
                .Property(e => e.Gender)
                .IsRequired();
            modelBuilder.Entity<DogEntity>()
                .Property(e => e.Weight)
                .IsRequired();
            modelBuilder.Entity<DogEntity>()
                .Property(e => e.ActivityFactor)
                .IsRequired();
            modelBuilder.Entity<DogEntity>()
                .Property(e => e.OwnerId);

            modelBuilder.Entity<AddressEntity>()
                .Property(e => e.City)
                .IsRequired()
                .HasMaxLength(25);
            modelBuilder.Entity<AddressEntity>()
                .Property(e => e.Street)
                .IsRequired()
                .HasMaxLength(25);
            modelBuilder.Entity<AddressEntity>()
                .Property(e => e.HouseNumber)
                .IsRequired();
            modelBuilder.Entity<AddressEntity>()
                .Property(e => e.PostalCode)
                .IsRequired();
            modelBuilder.Entity<AddressEntity>()
                .Property(e => e.Id)
                .IsRequired();

            modelBuilder.Entity<UserEntity>()
                .Property(u => u.FirstName)
                .IsRequired()
                .HasMaxLength(25);
            modelBuilder.Entity<UserEntity>()
                .Property(u => u.LastName)
                .IsRequired()
                .HasMaxLength(25);
            modelBuilder.Entity<UserEntity>()
                .Property(u => u.Email)
                .IsRequired();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }
    }
}
