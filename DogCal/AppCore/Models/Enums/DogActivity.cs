using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCore.Models.Enums
{
    public enum DogActivity
    {
        unneuteredAdult_Or_PregnancyFirstTwoTrimesters_Or_AdultUnneutered,
        neuteredAdult,
        overweightLowActivity,
        obesityTreatment_Or_IntensiveNutritionTherapy,
        weightGainRecovery,
        workingTrainingLight,
        pregnancyLastTrimester_Or_LactationOnePuppy_Or_WorkingTrainingModerate_Or_GrowthFourToFiveMonths,
        lactationTwoPuppies,
        lactationThreeToFourPuppies_Or_WorkingTrainingHeavy,
        lactationFiveToSixPuppies,
        lactationSevenToEightPuppies,
        lactationNineOrMorePuppies,
        growthEightToTwelveMonths,
    }
}
