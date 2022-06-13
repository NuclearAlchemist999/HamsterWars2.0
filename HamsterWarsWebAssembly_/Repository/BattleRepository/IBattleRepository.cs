using HamsterWarsWebAssembly.Shared.Models;

namespace Repository.BattleRepository
{
    public interface IBattleRepository
    {
        Task<int> AddGame();
        Task<List<JoinModel>> GetFighters(int id);
        Task<HamsterGame> AddFighterAndGame(HamsterGame request);
        Task<List<JoinModel>> BattleWinner(int id);
        Task<List<JoinModel>> BattleHistory();
        Task<Game> DeleteGame(int id);
        Task<List<PercentModel>> LoadTopFive();
        Task<List<PercentModel>> LoadBottomFive();
    }
}
