﻿using HamsterWarsWebAssembly.Shared.Models;
using System.Net.Http.Json;
using System.Text.Json;

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
            await _http.PostAsJsonAsync("api/hamsters", hamster);
        }

        public async Task DeleteHamster(int id)
        {
            await _http.DeleteAsync($"api/hamsters/{id}");
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

        public async Task UpdateHamster(HamsterGame request, int id)
        {
             await _http.PutAsJsonAsync($"api/hamsters/{id}", request);
          
        }
        public async Task GetRandomHamsters()
        {
            var result = await _http.GetFromJsonAsync<List<Hamster>>("api/hamsters/random");
            if (result != null)
                Hamsters = result;
        }
       
    }
}
