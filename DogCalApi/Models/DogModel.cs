using DogCalApi.Models.ModelEnums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DogCalApi.Models
{
    [Table("Dogs")]
    public class DogModel : AnimalModel
    {
        [Column("Activity Level")]
        [Required]
        public DogActivity activityLevel { get; set; }

        public DogModel(string name, int age, string gender, double weight, DogActivity activityLevel)
        {
            // Ustawienie wartości przelicznika dla danej aktywności
            this.name = name;
            this.age = age;
            this.weight = weight;
            this.gender = gender;
            this.activityLevel = activityLevel;
        }
    }
}
