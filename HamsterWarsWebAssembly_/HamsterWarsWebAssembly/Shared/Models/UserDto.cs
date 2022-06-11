using System.ComponentModel.DataAnnotations;

namespace HamsterWarsWebAssembly.Shared.Models
{
    public class UserDto
    {
        [Required(ErrorMessage = "Enter username.")]
        [MinLength(5, ErrorMessage = "At least five characters.")]
        public string Username { get; set; } = string.Empty;
        [Required(ErrorMessage = "Enter password.")]
        public string Password { get; set; } = string.Empty;
    }
}
