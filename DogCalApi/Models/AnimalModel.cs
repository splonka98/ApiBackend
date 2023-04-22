using DogCalApi.Models.ModelEnums;

namespace DogCalApi.Models
{
    public class AnimalModel
    {
        string name;
        int age;
        string gender;
        double weight;
        DogActivity activityLevel;
        double activityFactor;

        void printInfo()
        {
            Console.WriteLine($"Name: {name}");
            Console.WriteLine($"Age: {age}");
            Console.WriteLine($"Gender: {gender}");
            Console.WriteLine($"Weight: {weight}");
        }
    }
}