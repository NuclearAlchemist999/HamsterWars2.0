using HamsterWarsWebAssembly.Shared.Models;

namespace Repository.BattleRepository
{
    public interface IBattleRepository
    {
        Task<int> AddGame();
        Task<List<JoinModel>> GetFighters(int id);
        Task AddFighter(HamsterGame hamster);
    }
}
