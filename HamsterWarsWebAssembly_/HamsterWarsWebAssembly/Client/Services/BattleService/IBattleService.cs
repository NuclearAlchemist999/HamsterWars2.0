using HamsterWarsWebAssembly.Shared.Models;

namespace HamsterWarsWebAssembly.Client.Services.BattleService
{
    public interface IBattleService
    {
        List<JoinModel> Fighters { get; set; }
        List<PercentModel> PercentWin { get; set; }
        Task<int> AddGame();
        Task GetGame(int id);
        Task AddFighter(HamsterGame hamster);
        Task BattleWinner(int id);
        Task BattleHistory();
        Task DeleteGame(int id);
        Task TopFive();
    }
}
