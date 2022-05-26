using HamsterWarsWebAssembly.Shared.Models;

namespace HamsterWarsWebAssembly.Client.Services.BattleService
{
    public interface IBattleService
    {
        List<JoinModel> Fighters { get; set; }
        Task<int> AddGame();
        Task GetGame(int id);
        Task AddFighter(HamsterGame hamster);
    }
}
