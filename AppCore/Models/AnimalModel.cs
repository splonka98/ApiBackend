using DogCalApi.Models.ModelEnums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DogCalApi.Models
{
    [Table("Animals")]
    public abstract class AnimalModel
    {
        [Column("ID")]
        [Key]
        public int animalId { get; set; }

        [Column ("Name")]
        [Required]
        [StringLength(25)]
        public string name { get; set; }

        [Column("Age")]
        [Required]
        public int age { get; set; }

        [Column("Gender")]
        [Required]
        [StringLength(6)]
        public string gender { get; set; }

        [Column("Weight")]
        [Required]
        public double weight { get; set; }

        [Column("Activity Factor")]
        public double activityFactor { get; set; }

    }
}