using AppCore.Models;
using AppCore.Models.ModelEnums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCore.Interfaces.DogService
{
    internal interface IDogService
    {
        public Dog AddAnimal(string name, int age, string gender, double weight, DogActivity activity );
        public int CalculateAnimalCalories(double weight, double activityFactor);
        public double ChoseDogActivityFactor(DogActivity dogActivity);
    }
}
