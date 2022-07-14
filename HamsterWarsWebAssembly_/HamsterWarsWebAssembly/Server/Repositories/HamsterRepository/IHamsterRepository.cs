using HamsterWarsWebAssembly.Shared.Models;

namespace HamsterWarsWebAssembly.Server.Repositories.HamsterRepository
{
    public interface IHamsterRepository
    {
        Task<List<Hamster>> GetHamsters();
        Task<Hamster> GetHamster(int id);
        Task<Hamster> AddHamster(Hamster hamster);
        Task<Hamster> UpdateHamster(HamsterGame request, int id);
        Task<Hamster> DeleteHamster(int id);
        Task<List<Hamster>> GetRandomHamsters(int number);
        Task<Hamster> UpdateWholeHamster(Hamster request, int id);
        Task<Hamster> GetRandomHamster();
    }
}
