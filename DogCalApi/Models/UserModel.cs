namespace DogCalApi.Models
{
    public class UserModel
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public List<DogModel> Dog { get; set; }
    }
}
