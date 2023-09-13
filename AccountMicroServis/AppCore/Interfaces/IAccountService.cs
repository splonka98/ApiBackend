using AppCore.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCore.Interfaces
{
    public interface IAccountService
    {
        User RegisterUser(string email, string password, string firstname, string lastName, int roleId);
        string GenerateJwt(string email, string password, User userEntitie, IConfiguration configuration);
    }
}
