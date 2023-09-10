using Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Seeders
{
    public class AccountSeeder
    {
        private readonly ApiDbContext _dbContext;

        public AccountSeeder(ApiDbContext dbContext)
        {
            _dbContext = dbContext; 
        }
        public void Seed()
        {
            if (_dbContext.Database.CanConnect())
            {
                var pendingMigrations = _dbContext.Database.GetPendingMigrations();
                if (pendingMigrations != null && pendingMigrations.Any())
                {
                    _dbContext.Database.Migrate();
                }

                if (!_dbContext.Roles.Any())
                {
                    IEnumerable<Role> roles = GetRoles();
                    _dbContext.Roles.AddRange(roles);
                    _dbContext.SaveChanges();
                }

                if (!_dbContext.Users.Any())
                {
                    var users = GetUsers();
                    _dbContext.Users.AddRange(users);
                    _dbContext.SaveChanges();
                }
            }
        }
        private IEnumerable<Role> GetRoles()
        {
            var roles = new List<Role>()
            {
                new Role()
                {
                    Name = "Admin"
                },
                new Role()
                {
                    Name = "User"
                },
            };

            return roles;
        }
        private IEnumerable<User> GetUsers()
        {
            var users = new List<User>()
            {
                new User()
                {
                    
                    Email="test1@gmail.com",
                    FirstName="Szymon",
                    LastName="Plonka",
                    Password="Admin123",
                    RoleId=0

    },
                new User()
                {
                   
                    Email="test2@gmail.com",
                    FirstName="Pymon",
                    LastName="Szonka",
                    Password="User123",
                    RoleId=1
                }
            };

            return users;
        }
    }
}
