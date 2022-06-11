﻿using HamsterWarsWebAssembly.Shared.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository.BattleRepository;

namespace HamsterWarsWebAssembly.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MatchesController : ControllerBase
    {
        private readonly IBattleRepository _battleRepo;
        public MatchesController(IBattleRepository battleRepo)
        {
            _battleRepo = battleRepo;
        }

        [HttpPost]
        public async Task<IActionResult> AddGame()
        {
            var id = await _battleRepo.AddGame();
            return Ok(id);
        }
        [HttpPost("Fighter")]
        public async Task<IActionResult> AddFighter(HamsterGame hamster)
        {
            await _battleRepo.AddFighter(hamster);
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> BattleHistory()
        {
            var games = await _battleRepo.BattleHistory();
            return Ok(games);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetGame(int id)
        {
            var game = await _battleRepo.GetFighters(id);
            if (game.Count == 0)
                return NotFound();
            return Ok(game);
        }

        [HttpDelete("{id}"), Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteGame(int id)
        {
            var game = await _battleRepo.DeleteGame(id);
            if (game == null)
                return NotFound();

            return Ok(game);
        }

       
    }
}
