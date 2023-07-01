using DogCalApi.Models.ModelEnums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DogCalApi.Models
{
    public class Dog
    {
        public int animalId { get; set; }

        public string name { get; set; }

        public int age { get; set; }

        public string gender { get; set; }

        public double weight { get; set; }

        public double activityFactor { get; set; }

        public virtual int ownerId { get; set; }
        public DogActivity activityLevel { get; set; }
        
    }
}
