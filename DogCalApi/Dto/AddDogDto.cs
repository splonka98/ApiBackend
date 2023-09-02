using AppCore.Models;

namespace DogCalApi.Dto
{
    public class AddDogDto
    {

        public int Id { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }

        public string Gender { get; set; }

        public double Weight { get; set; }

        public int OwnerId { get; set; }
        public int ActivityLevel { get; set; }

        public AddDogDto of(Dog dog)
        {
            return new AddDogDto()
            {
                Id = dog.Id,
                Name = dog.Name,
                Age = dog.Age,
                Gender = dog.Gender,
                Weight = dog.Weight,
                OwnerId = dog.OwnerId,
                ActivityLevel = dog.ActivityLevel
            };
        }
        public Dog of(AddDogDto addingDog)
        {
            return new Dog()
            {
                Id = addingDog.Id,
                Age = addingDog.Age,
                Name = addingDog.Name,
                Gender = addingDog.Gender,
                Weight = addingDog.Weight,
                OwnerId = addingDog.OwnerId,
                ActivityLevel = addingDog.ActivityLevel
            };
        }
    }
}
