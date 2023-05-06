using DogCalApi.Models.ModelEnums;

namespace DogCalApi.Services
{
    public class DogService 
    {
        public void AddAnimal()
        {

        }
        public void CalculateAnimalCalories()
        {

        }
        public double ChoseDogActivityLevel(DogActivity dogActivity)
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
