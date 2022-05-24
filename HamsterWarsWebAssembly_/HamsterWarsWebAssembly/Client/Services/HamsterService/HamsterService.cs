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

        public async Task AddHamster(Hamster hamster)
        {
            var result = await _http.PostAsJsonAsync("api/hamsters", hamster);
            await SetHamsters(result);
        }

        public async Task DeleteHamster(int id)
        {
            var result = await _http.DeleteAsync($"api/hamsters/{id}");
            await SetHamsters(result);
        }

        private async Task SetHamsters(HttpResponseMessage result)
        {
            var response = await result.Content.ReadFromJsonAsync<List<Hamster>>();
            Hamsters = response;
        }

        public async Task<Hamster> GetHamster(int id)
        {
            var result = await _http.GetFromJsonAsync<Hamster>($"api/hamsters/{id}");
            if (result != null)
                return result;
            throw new Exception("Hamster not found.");
        }

        public async Task GetHamsters()
        {
            var result = await _http.GetFromJsonAsync<List<Hamster>>("api/hamsters");
            if (result != null)
                Hamsters = result;
        }

        public async Task UpdateHamster(UpdateHamsterRequest request)
        {
            await _http.PutAsJsonAsync($"api/hamsters", request);
        }

        public async Task GetRandomHamsters()
        {
            var result = await _http.GetFromJsonAsync<List<Hamster>>("api/hamsters/random");
            if (result != null)
                Hamsters = result;
        }
    }
}
