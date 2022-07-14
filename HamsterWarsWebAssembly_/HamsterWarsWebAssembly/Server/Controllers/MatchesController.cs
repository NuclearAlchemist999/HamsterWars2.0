using HamsterWarsWebAssembly.Server.Repositories.BattleRepository;
using HamsterWarsWebAssembly.Shared.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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

        [HttpPost("game")]
        public async Task<IActionResult> AddGame()
        {
            var id = await _battleRepo.AddGame();
            return Ok(id);
        }
        [HttpPost]
        public async Task<IActionResult> AddFighterAndGame(HamsterGame request)
        {
            var hamsterAndGame = await _battleRepo.AddFighterAndGame(request);
            return Ok(hamsterAndGame);
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
                return NotFound("No game here.");
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
