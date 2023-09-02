using AppCore.Models;

namespace DogCalApi.Dto
{
    public class AddUserDto
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int AdressId { get; set; }
        public Address Address { get; set; }
        public static User of(AddUserDto user)
        {
            return new User()
            {
                Id = user.Id,
                UserName = user.UserName,
                Password = user.Password,
                AdressId = user.AdressId,
                Address = user.Address
            };
        }
    }
}
