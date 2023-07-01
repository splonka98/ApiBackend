using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCore.Interfaces.UserService
{
    public interface IUserService
    {
        public void CreateAccount();

        public void AddDog();

        public void EditDog();

        public void RemoveDog();
    }
}
