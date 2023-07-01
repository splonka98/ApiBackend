namespace AppCore.Models
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int AdressId { get; set; }
        public Address Address { get; set; }
        public List<Dog> Dogs { get; set; }
    }
}
