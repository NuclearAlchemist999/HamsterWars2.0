

using System.ComponentModel.DataAnnotations;

namespace HamsterWarsWebAssembly.Shared.Models
{
    public class Hamster
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Enter a name.")]
        [MinLength(2, ErrorMessage = "At least two characters.")]
        public string? Name { get; set; }

        [Range(1, 5, ErrorMessage = "Age must be between 1 and 5.")]
        public int Age { get; set; }

        [Required(ErrorMessage = "Enter favourite food.")]
        [MinLength(3, ErrorMessage = "At least three characters.")]
        public string? FavFood { get; set; }

        [Required(ErrorMessage = "Enter favourite thing.")]
        [MinLength(3, ErrorMessage = "At least three characters.")]
        public string? FavThing { get; set; }
        [Required(ErrorMessage = "An image is required.")]
        [MinLength(5, ErrorMessage = "At least five characters.")]
        public string? ImgName { get; set; }
        [Range(0, 0, ErrorMessage = "Zero by default.")]
        public int Wins { get; set; } = 0;
        [Range(0, 0, ErrorMessage = "Zero by default.")]
        public int Losses { get; set; } = 0;
        [Range(0, 0, ErrorMessage = "Zero by default.")]
        public int Games { get; set; } = 0;
    }
}
