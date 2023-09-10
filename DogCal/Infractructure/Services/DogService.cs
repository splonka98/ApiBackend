using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppCore.Interfaces;
using AppCore.Models;
using AppCore.Models.Enums;

namespace Infractructure.Services
{
    public class DogService : IDogService
    {
        public Dog AddOrEditDog(int dogId, string name, int weight, int activityLevel, int ownerId)
        {
            return new Dog()
            {
                Id = dogId,
                Name = name,
                Weight = weight,
                ActivityLevel = activityLevel,
                OwnerId = ownerId
            };
        }

        public void CalculateCalories(Dog dog)
        {
            dog.CalorieNeed = (int)(70 * Math.Pow(dog.Weight, 0.75) * ChoseDogActivityFactor(GetActivityFromInt(dog.ActivityLevel)));
        }
        private double ChoseDogActivityFactor(DogActivity dogActivity)
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
