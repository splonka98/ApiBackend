using Microsoft.EntityFrameworkCore;
using AppCore.Models;
namespace Infractructure
{
    public class ApiDbContext : DbContext
    {
        //private string _connectionString = "DogDbConnection";
        public DbSet<Dog> Dogs { get; set; }
        public ApiDbContext(DbContextOptions<ApiDbContext> option) :base(option)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Dog>()
                .Property(d => d.Name)
                .IsRequired()
                .HasMaxLength(25);
        }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(_connectionString);
        //}
    }
}
