using DogCalApi.Models.ModelEnums;

namespace DogCalApi.Models
{
    public class Dog : AnimalModel
    {
        public string name { get; set; }
        public int age;
        public string gender;
        public double weight;
        public DogActivity activityLevel;
        public double activityFactor;

        Dog(string name, int age, string gender, double weight, DogActivity activityLevel) {
            // Ustawienie wartości przelicznika dla danej aktywności
            this.name = name;
            this.age = age;
            this.weight = weight;
            this.gender = gender;
            this.activityLevel = activityLevel;

            switch (activityLevel)
            {
                case DogActivity.unneuteredAdult_Or_PregnancyFirstTwoTrimesters_Or_AdultUnneutered:
                    this.activityFactor = 1.8;
                    break;
                case DogActivity.neuteredAdult:
                    this.activityFactor = 1.6;
                    break;
                case DogActivity.overweightLowActivity:
                    this.activityFactor = 1.4;
                    break;
                case DogActivity.obesityTreatment_Or_IntensiveNutritionTherapy:
                    this.activityFactor = 1.0;
                    break;
                case DogActivity.weightGainRecovery:
                    this.activityFactor = 1.2;
                    break;
                case DogActivity.workingTrainingLight:
                    this.activityFactor = 2.0;
                    break;
                case DogActivity.pregnancyLastTrimester_Or_LactationOnePuppy_Or_WorkingTrainingModerate_Or_GrowthFourToFiveMonths:
                    this.activityFactor = 3.0;
                    break;
                case DogActivity.lactationTwoPuppies:
                    this.activityFactor = 3.5;
                    break;
                case DogActivity.lactationThreeToFourPuppies_Or_WorkingTrainingHeavy:
                    this.activityFactor = 4.0;
                    break;
                case DogActivity.lactationFiveToSixPuppies:
                    this.activityFactor = 5.0;
                    break;
                case DogActivity.lactationSevenToEightPuppies:
                    this.activityFactor = 5.5;
                    break;
                case DogActivity.lactationNineOrMorePuppies:
                    this.activityFactor = 6.0;
                    break;
                case DogActivity.growthEightToTwelveMonths:
                    this.activityFactor = 2.5;
                    break;
            }
        }
    }
}
