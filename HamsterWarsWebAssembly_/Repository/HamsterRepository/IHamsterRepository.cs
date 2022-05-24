using HamsterWarsWebAssembly.Shared.Models;

namespace Repository.HamsterRepository
{
    public interface IHamsterRepository 
    {
        Task<List<Hamster>> GetHamsters();
        Task<Hamster> GetHamster(int id);
        Task AddHamster(Hamster hamster);
        Task<Hamster> UpdateHamster(Hamster hamster, int id);
        Task<Hamster> DeleteHamster(int id);
    }
}
