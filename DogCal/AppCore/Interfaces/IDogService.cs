using AppCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCore.Interfaces
{
    public interface IDogService
    {
        public Dog AddOrEditDog(int dogId, string name, int weight, int activityLevel, int ownerId);
        public void CalculateCalories(Dog dog);
    }
}
