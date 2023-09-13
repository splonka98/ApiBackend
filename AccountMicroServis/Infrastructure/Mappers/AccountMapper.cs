using AppCore.Models;
using Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Mappers
{
    public class AccountMapper
    {
        public UserEntitie UserModelToEntity (User user)
        {
            return new UserEntitie()
            {
                UserId = user.Id,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Password = user.Password,
                AccessToken = user.AccessToken,
                RoleId = user.RoleId,
            };
        }
        public User UserEntityToModel(UserEntitie userEntitie)
        {
            return new User()
            {
                Id = userEntitie.RoleId,
                Email = userEntitie.Email,
                FirstName = userEntitie.FirstName,
                LastName = userEntitie.LastName,
                Password = userEntitie.Password,
                AccessToken = userEntitie.AccessToken,
                RoleId = userEntitie.RoleId,
            };
        }
    }
}
