using AppCore.Models;

namespace DogCalApi.Dto
{
    public class UserDto
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int AdressId { get; set; }
        public Address Address { get; set; }
        public List<Dog> Dogs { get; set; }
        public static UserDto of(User user)
        {
            return new UserDto()
            {
                Id = user.Id,
                UserName = user.UserName,
                Password = user.Password,
                AdressId = user.AdressId,
                Address = user.Address,
                Dogs = user.Dogs
            };
        }
    }
}
