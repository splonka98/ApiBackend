using AppCore.Models;
using AppCore.Models.ModelEnums;

namespace DogCalApi.Dto
{
    public class DogDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }

        public string Gender { get; set; }

        public double Weight { get; set; }

        public double ActivityFactor { get; set; }

        public int OwnerId { get; set; }
        public DogActivity ActivityLevel { get; set; }
        public static DogDto of(Dog dog)
        {
            return new DogDto()
            {
                Id = dog.Id,
                Name = dog.Name,
                Age = dog.Age,
                Gender = dog.Gender,
                ActivityLevel = dog.ActivityLevel,
                ActivityFactor = dog.ActivityFactor,
                OwnerId = dog.OwnerId,
            };
        }
    }

}
