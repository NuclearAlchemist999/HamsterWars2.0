using HamsterWarsWebAssembly.Shared.Models;
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
        [HttpGet("{id}")]
        public async Task<IActionResult> GetGame(int id)
        {
            var game = await _battleRepo.GetFighters(id);
            return Ok(game);
        }
       
    }
}
