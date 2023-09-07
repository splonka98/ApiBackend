using Microsoft.EntityFrameworkCore;
using AppCore.Models;
namespace Infractructure
{
    public class ApiDbContext : DbContext
    {

        public DbSet<Dog> Dogs { get; set; }
        public ApiDbContext(DbContextOptions<ApiDbContext> option) :base(option)
        {

        }
    }
}
