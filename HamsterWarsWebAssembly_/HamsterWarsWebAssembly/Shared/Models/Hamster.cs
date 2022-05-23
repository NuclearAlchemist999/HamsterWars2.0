

namespace HamsterWarsWebAssembly.Shared.Models
{
    public class Hamster
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int Age { get; set; }
        public string? FavFood { get; set; }
        public string? FavThing { get; set; }
        public string? ImgName { get; set; }
        public int Wins { get; set; }
        public int Losses { get; set; }
        public int Games { get; set; }
    }
}
