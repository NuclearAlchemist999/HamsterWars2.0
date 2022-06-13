using HamsterWarsWebAssembly.Shared.Models;

namespace HamsterWarsWebAssembly.Client.Services.BattleService
{
    public interface IBattleService
    {
        List<JoinModel> Fighters { get; set; }
        List<PercentModel> PercentWin { get; set; }
        List<PercentModel> PercentLoss { get; set; }
        Task<int> AddGame();
        Task GetGame(int id);
        Task AddFighterAndGame(HamsterGame request);
        Task BattleWinner(int id);
        Task BattleHistory();
        Task DeleteGame(int id);
        Task TopFive();
        Task BottomFive();
    }
}
