using System.ComponentModel.DataAnnotations;

namespace notificacion.Models
{
    public class UserDto
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
