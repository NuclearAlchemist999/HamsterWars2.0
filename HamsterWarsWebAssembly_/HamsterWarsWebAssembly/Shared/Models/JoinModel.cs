

namespace HamsterWarsWebAssembly.Shared.Models
{
    public class JoinModel
    {
        public int GameId { get; set; }
        public DateTime TimeStamp { get; set; }
        public int HamsterId { get; set; }
        public string? HamsterName { get; set; }
        public string? WinStatus { get; set; }
        public int Wins { get; set; }
        public int Losses { get; set; }
        public int Games { get; set; }   
        public string? ImgName { get; set; }
        
    }
}
