using AppCore.Models.ModelEnums;
using AppCore.Models;
using Infrastructure.Entities;
using AppCore.Interfaces.DogService;
using System.Diagnostics;

namespace DogCalApi.Services
{
    public class DogService: IDogService

    {
        private double factor;

        public DogEntity AddAnimal(Dog dog)
        {
            return new DogEntity()
            {
                Name = dog.Name,
                Age = dog.Age,
                Gender = dog.Gender,
                Weight = dog.Weight,
                ActivityFactor = dog.ActivityFactor,
            };
        }

        public Dog AddDog(string name, int age, string gender, double weight, int activity, int ownerId)
        {
            return new Dog()
            {
                Name = name,
                Age = age,
                Gender = gender,
                Weight = weight,
                ActivityLevel = activity,
                ActivityFactor = ChoseDogActivityFactor(GetActivityFromInt(activity)),
                CaloricNeed = CalculateAnimalCalories(weight, ChoseDogActivityFactor(GetActivityFromInt(activity))),
                OwnerId = ownerId
            };
        }

        public int CalculateAnimalCalories(double weight, double activityFactor)
        {
            return (int)(70 * Math.Pow(weight,0.75)*activityFactor);
        }
        public double ChoseDogActivityFactor(DogActivity dogActivity)
        {
            switch (dogActivity)
            {
                case DogActivity.unneuteredAdult_Or_PregnancyFirstTwoTrimesters_Or_AdultUnneutered:
                    return 1.8;
                case DogActivity.neuteredAdult:
                    return 1.6;
                case DogActivity.overweightLowActivity:
                    return 1.4;
                case DogActivity.obesityTreatment_Or_IntensiveNutritionTherapy:
                    return 1.0;
                case DogActivity.weightGainRecovery:
                    return 1.2;
                case DogActivity.workingTrainingLight:
                    return 2.0;
                case DogActivity.pregnancyLastTrimester_Or_LactationOnePuppy_Or_WorkingTrainingModerate_Or_GrowthFourToFiveMonths:
                    return 3.0;
                case DogActivity.lactationTwoPuppies:
                    return 3.5;
                case DogActivity.lactationThreeToFourPuppies_Or_WorkingTrainingHeavy:
                    return 4.0;
                case DogActivity.lactationFiveToSixPuppies:
                    return 5.0;
                case DogActivity.lactationSevenToEightPuppies:
                    return 5.5;
                case DogActivity.lactationNineOrMorePuppies:
                    return 6.0;
                case DogActivity.growthEightToTwelveMonths:
                    return 2.5;
                default:
                    return 1;
            }
        }
        private DogActivity GetActivityFromInt(int activity)
    {
            switch (activity)
            {
                case 0:
                    return DogActivity.unneuteredAdult_Or_PregnancyFirstTwoTrimesters_Or_AdultUnneutered;
                case 1:
                    return DogActivity.neuteredAdult;
                case 2:
                    return DogActivity.overweightLowActivity;
                case 3:
                    return DogActivity.obesityTreatment_Or_IntensiveNutritionTherapy;
                case 4:
                    return DogActivity.weightGainRecovery;
                case 5:
                    return DogActivity.workingTrainingLight;
                case 6:
                    return DogActivity.pregnancyLastTrimester_Or_LactationOnePuppy_Or_WorkingTrainingModerate_Or_GrowthFourToFiveMonths;
                case 7:
                    return DogActivity.lactationTwoPuppies;
                case 8:
                    return DogActivity.lactationThreeToFourPuppies_Or_WorkingTrainingHeavy;
                case 9:
                    return DogActivity.lactationFiveToSixPuppies;
                case 10:
                    return DogActivity.lactationSevenToEightPuppies;
                case 11:
                    return DogActivity.lactationNineOrMorePuppies;
                case 12:
                    return DogActivity.growthEightToTwelveMonths;
                default:
                    return DogActivity.overweightLowActivity;
            }
        }
    }
}
