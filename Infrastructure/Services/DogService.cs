﻿using AppCore.Models.ModelEnums;
using AppCore.Models;

namespace DogCalApi.Services
{
    public class DogService
    {
        
        public bool AddAnimal(string name, int age, string gender, double weight, DogActivity activityLevel)
        {
            try
            {
                Dog newDog = new Dog();
                newDog.ActivityFactor=ChoseDogActivityFactor(activityLevel);
            }
            catch 
            {
                return false;
            }
            return true;
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
    }
}
