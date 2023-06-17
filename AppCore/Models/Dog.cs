using DogCalApi.Models.ModelEnums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DogCalApi.Models
{
    public class Dog : AnimalModel
    {
        public DogActivity activityLevel { get; set; }
        
    }
}
