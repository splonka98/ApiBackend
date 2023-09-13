using System.ComponentModel.DataAnnotations;

namespace AccountMicroServisApi.Dtos
{
    public class RegisterUserDto
    {
        [Required]
        public string Email { get; set; }
        [Required]
        [MinLength(5)]
        public string Password { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }

        public int RoleId { get; set; }
    }
}
