using AppCore.Models.ModelEnums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppCore.Models
{
    public class Dog
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }

        public string Gender { get; set; }

        public double Weight { get; set; }

        public double ActivityFactor { get; set; }

        public int OwnerId { get; set; }
        public DogActivity ActivityLevel { get; set; }
        
    }
}
