

namespace HamsterWarsWebAssembly.Shared.Models
{
    public class PercentModel
    {
        public string? Name { get; set; }
        public double WinPercentRate { get; set; }
        public double LossPercentRate { get; set; }
        public string? ImgName { get; set; }
        public int Wins { get; set; }
        public int Losses { get; set; }
        public int Games { get; set; }
    }
}
