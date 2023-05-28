using System.ComponentModel.DataAnnotations;

namespace notificacion.Models
{
    public class RegisterUserDto
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
        public string  Role { get; set; }
    }
}
