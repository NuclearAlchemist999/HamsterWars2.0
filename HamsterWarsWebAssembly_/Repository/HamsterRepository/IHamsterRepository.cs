using HamsterWarsWebAssembly.Shared.Models;

namespace Repository.HamsterRepository
{
    public interface IHamsterRepository 
    {
        Task<List<Hamster>> GetHamsters();
        Task<Hamster> GetHamster(int id);
        Task AddHamster(Hamster hamster);
        Task UpdateHamster(UpdateHamsterRequest request);
        Task<Hamster> DeleteHamster(int id);
        Task<List<Hamster>> GetTwoRandomHamsters();
        Task<int> AddGame();
        Task AddFighter(int hamsterId, int gameId, string winStat);

    }
}
