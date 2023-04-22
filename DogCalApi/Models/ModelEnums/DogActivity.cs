namespace DogCalApi.Models.ModelEnums
{
    public enum DogActivity
    {
        unneuteredAdult_Or_PregnancyFirstTwoTrimesters_Or_AdultUnneutered, // niesterylizowany/niekastrowany po 8-12 miesiącach życia lub ciąża - pierwsze dwa trymestry (do ok. 6 tyg. ciąży)
        neuteredAdult, // sterylizowany/kastrowany
        overweightLowActivity, // mało aktywny z nadwagą
        obesityTreatment_Or_IntensiveNutritionTherapy, // leczenie otyłości lub odżywianie w intensywnej terapii
        weightGainRecovery, // odzyskanie masy ciała w okresie rekonwalescencji
        workingTrainingLight, // psy pracujące lub trenujące - lekko
        pregnancyLastTrimester_Or_LactationOnePuppy_Or_WorkingTrainingModerate_Or_GrowthFourToFiveMonths, // ciąża - ostatni trymestr lub laktacja - 1 szczenię lub psy pracujące lub trenujące - średnio lub wzrost - od 4-5 miesiąca życia
        lactationTwoPuppies, // laktacja - 2 szczenięta
        lactationThreeToFourPuppies_Or_WorkingTrainingHeavy, // laktacja - 3-4 szczenięta or psy pracujące lub trenujące - ciężko
        lactationFiveToSixPuppies, // laktacja - 5-6 szczeniąt
        lactationSevenToEightPuppies, // laktacja - 7-8 szczeniąt
        lactationNineOrMorePuppies, // laktacja - 9 szczeniąt lub więcej
        growthEightToTwelveMonths, // wzrost - od 8-12 miesiąca życia
    }
}
