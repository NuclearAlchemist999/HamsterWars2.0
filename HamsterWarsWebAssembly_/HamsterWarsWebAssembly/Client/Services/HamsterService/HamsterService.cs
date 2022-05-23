using HamsterWarsWebAssembly.Shared.Models;
using System.Net.Http.Json;

namespace HamsterWarsWebAssembly.Client.Services.HamsterService
{
    public class HamsterService : IHamsterService
    {
        private readonly HttpClient _http;

        public HamsterService(HttpClient http)
        {
            _http = http;
        }
        public List<Hamster> Hamsters { get; set; } = new List<Hamster>();

        public Task<Hamster> GetHamster(int id)
        {
            throw new NotImplementedException();
        }

        public async Task GetHamsters()
        {
            var result = await _http.GetFromJsonAsync<List<Hamster>>("api/hamsters");
            if (result != null)
                Hamsters = result;
        }
    }
}
