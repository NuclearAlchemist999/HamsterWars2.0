using HamsterWarsWebAssembly.Shared.Models;

namespace HamsterWarsWebAssembly.Client.Services.HamsterService
{
    public interface IHamsterService
    {
        List<Hamster> Hamsters { get; set; }
        Task GetHamsters();
        Task<Hamster> GetHamster(int id);
    }
}
