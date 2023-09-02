using AppCore.Models;
using AppCore.Models.ModelEnums;

namespace DogCalApi.Dto
{
    public class GetDogDto
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int CaloricNeed { get; set; }

        public int OwnerId { get; set; }
        public static GetDogDto of(Dog dog)
        {
            return new GetDogDto()
            {
                Id = dog.Id,
                Name = dog.Name,
                CaloricNeed = dog.CaloricNeed,
                OwnerId = dog.OwnerId,
            };
        }
    }

}
