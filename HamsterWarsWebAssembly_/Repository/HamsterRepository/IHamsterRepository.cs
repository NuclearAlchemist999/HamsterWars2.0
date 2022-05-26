using HamsterWarsWebAssembly.Shared.Models;

namespace Repository.HamsterRepository
{
    public interface IHamsterRepository 
    {
        Task<List<Hamster>> GetHamsters();
        Task<Hamster> GetHamster(int id);
        Task AddHamster(Hamster hamster);
        Task<Hamster> UpdateHamster(HamsterGame request, int id);
        Task<Hamster> DeleteHamster(int id);
        Task<List<Hamster>> GetTwoRandomHamsters();

    }
}
