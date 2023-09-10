using AppCore.Models;
using System.ComponentModel.DataAnnotations;

namespace DogCalApi.Dtos
{
    public class AddEditDogDto
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [MaxLength(25)]
        public string Name { get; set; }
        [Required]
        public int Weight { get; set; }
        [Required]
        public int ActivityLevel { get; set; }

        [Required]
        public int OwnerId { get; set; }
       
    }
}
