using AppCore.Models;
using AppCore.Models.ModelEnums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCore.Interfaces.DogService
{
    public interface IDogService
    {
        public Dog AddDog(string name, int age, string gender, double weight, int activity , int ownerId);
        public int CalculateAnimalCalories(double weight, double activityFactor);
        public double ChoseDogActivityFactor(DogActivity dogActivity);
    }
}
