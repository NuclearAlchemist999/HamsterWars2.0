using HamsterWarsWebAssembly.Shared.Models;
using System.Net.Http.Json;

namespace HamsterWarsWebAssembly.Client.Services.BattleService
{
    public class BattleService : IBattleService
    {
        private readonly HttpClient _http;

        public BattleService(HttpClient http)
        {
            _http = http;
        }
        public List<JoinModel> Fighters { get; set; } = new List<JoinModel>();

        public async Task<int> AddGame()
        {
            var response =  await _http.PostAsJsonAsync("api/matches", new {});
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<int>();

            }
            throw new Exception("No game");
        }

        public async Task GetGame(int id)
        {
            var result = await _http.GetFromJsonAsync<List<JoinModel>>($"api/matches/{id}");
            if (result != null)
                Fighters = result;
        }
    }
}
